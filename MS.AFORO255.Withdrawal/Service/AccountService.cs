using Microsoft.Extensions.Configuration;
using MS.AFORO255.Cross.Proxy.Proxy;
using MS.AFORO255.Withdrawal.DTO;
using MS.AFORO255.Withdrawal.Model;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.AFORO255.Withdrawal.Service
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly ITransactionService _transactionService;
        private readonly IHttpClient _httpClient;

        public AccountService(IConfiguration configuration,ITransactionService transactionService, IHttpClient httpClient)
        {
            _configuration = configuration;
            _transactionService = transactionService;
            _httpClient = httpClient;
        }

        public async Task<bool> WithdrawalAccount(AccountRequest request)
        {
            string uri = _configuration["proxy:urlAccountWithdrawal"];
            var response = await _httpClient.PostAsync(uri, request);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public bool WithdrawalReverse(Transaction request)
        {
            _transactionService.WithdrawalReverse(request);
            return true;
        }

        public bool Execute(Transaction request)
        {
            bool response = false;

            var circuitBreakerPolicy = Policy.Handle<Exception>().
                CircuitBreaker(3, TimeSpan.FromSeconds(15),
                onBreak: (ex, timespan, context) =>
                {
                    Console.WriteLine("El circuito entró en estado de falla");
                }, onReset: (context) =>
                {
                    Console.WriteLine("Circuito dejó estado de falla");
                });


            var retry = Policy.Handle<Exception>()
                    .WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300))
                    .Wrap(circuitBreakerPolicy);

            retry.Execute(() =>
            {
                //if (circuitBreakerPolicy.CircuitState != CircuitState.Open)
                if (circuitBreakerPolicy.CircuitState == CircuitState.Closed)
                {
                    circuitBreakerPolicy.Execute(() =>
                    {
                        AccountRequest account = new AccountRequest()
                        {
                            Amount = request.Amount,
                            IdAccount = request.AccountId
                        };
                        response = WithdrawalAccount(account).Result;
                        Console.WriteLine("Solicitud realizada con éxito");

                    });
                }

                if (circuitBreakerPolicy.CircuitState != CircuitState.Closed)
                {
                    Transaction transaction = new Transaction()
                    {
                        AccountId = request.AccountId,
                        Amount = request.Amount,
                        CreationDate = DateTime.Now.ToShortDateString(),
                        Type = "With R"
                    };
                    response = WithdrawalReverse(transaction);
                    response = false;
                }
            });

            return response;
        }

    }
}

