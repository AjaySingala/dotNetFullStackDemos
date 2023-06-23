using BankingApp.BL;
using BankingApp.Entities;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace BankingApp.UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C-INB!");
            bool toExit = false;
            while (!toExit)
            {
                Console.WriteLine();
                Console.WriteLine("-------------");
                Console.WriteLine("Menu...");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Create Account");
                Console.WriteLine("3. List all customers");
                Console.WriteLine("4. Show customer details");
                Console.WriteLine("5. List all accounts for a customer");
                Console.WriteLine("6. Show account details");
                Console.WriteLine("7. Operate Account");
                Console.WriteLine("8. List All Transactions");
                Console.WriteLine("0. EXIT");
                Console.Write("What would you like to do? ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        toExit = true;
                        break;
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        CreateAccount();
                        break;
                    case "3":
                        var customers = GetAllCustomers();
                        PrintAllCustomers(customers);

                        break;
                    case "4":
                        var customer = GetCustomer();
                        if (customer == null)
                        {
                            Console.WriteLine($"Customer not found!");
                        }
                        else
                        {
                            PrintCustomer(customer);
                        }

                        break;
                    case "5":
                        var accounts = GetCustomerAccounts();
                        if(accounts == null || accounts.Count == 0)
                        {
                            Console.WriteLine("No accounts found...");
                            break;
                        }
                        PrintAllAccounts(accounts);
                        break;
                    case "6":
                        GetAccount();
                        break;
                    case "7":
                        OperateAccount();
                        break;
                    case "8":
                        ListAllTxns();
                        break;
                }
            }
        }

        static void ListAllTxns()
        {
            Console.WriteLine();
            Console.WriteLine("Listing all Transactions...");

            TransactionService svc = new TransactionService();
            var txns = svc.Get();
            foreach(var txn in txns)
            {
                Console.WriteLine(txn.ToString());
            }
        }

        static void OperateAccount()
        {
            Console.WriteLine();
            Console.WriteLine("Operate an Account...");

            var account = GetAccount();
            if (account == null || account.Id == 0)
            {
                Console.WriteLine("Account not found...");
                return;
            }

            string option = "";
            while (option != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Show Details");
                Console.WriteLine("5. Close");
                Console.WriteLine("0. Back to main menu");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        try
                        {
                            Deposit(account);
                        }catch(Exception ex)
                        { 
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        try
                        {
                            Withdraw(account);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Transfer(account);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        Console.Write(account.ToString());
                        break;
                    case "5":
                        break;
                }
            }
        }

        static void Transfer(Account account)
        {
            Console.WriteLine();
            Console.Write($"Transfer from" +
                $" {GetEnumDescription(account.GetAccountType())} Account" +
                $" number {account.Id} to which account? "
            );
            int toAccountId = Convert.ToInt32(Console.ReadLine());
            
            AccountService svc = new AccountService();
            var accountTo = svc.Get(toAccountId);
            if (accountTo == null || accountTo.Id == 0)
            {
                Console.WriteLine("Account not found...");
            }
            else
            {
                Console.WriteLine(accountTo.ToString());
            }

            Console.Write("Transfer how much? ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            bool isSuccess = false;
            try
            {
                accountTo.Deposit(amount);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isSuccess = false;
            }
            if (isSuccess)
            {
                try
                {
                    account.Withdraw(amount);
                    Console.Write($"Done Transfer of {amount} " +
                        $"from {account.Id} to {accountTo.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    accountTo.Withdraw(amount);
                }

                // Txn for the Withdraw.
                TransactionService txnSvc = new TransactionService();
                Transaction txnWithdraw = new Transaction
                {
                    AccountId = account.Id,
                    Amount = amount,
                    Balance = account.Balance,
                    CustomerId = account.CustomerId,
                    TransactionDate = DateTime.Now.Date,
                    TransactionType = TransactionType.Withdraw
                };
                txnSvc.Create(txnWithdraw);

                // Txn for the Deposit.
                Transaction txnDeposit = new Transaction
                {
                    AccountId = accountTo.Id,
                    Amount = amount,
                    Balance = accountTo.Balance,
                    CustomerId = accountTo.CustomerId,
                    TransactionDate = DateTime.Now.Date,
                    TransactionType = TransactionType.Deposit
                };
                txnSvc.Create(txnDeposit);
            }
        }

        static void Withdraw(Account account)
        {
            Console.WriteLine();
            Console.WriteLine($"Withdraw from" +
                $" {GetEnumDescription(account.GetAccountType())} Account" +
                $" number {account.Id}"
            );

            Console.Write("");
            Console.Write("Withdraw how much? ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(amount);

            TransactionService txnSvc = new TransactionService();
            Transaction txn = new Transaction
            {
                AccountId = account.Id,
                Amount = amount,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                TransactionDate = DateTime.Now.Date,
                TransactionType = TransactionType.Withdraw
            };
            txnSvc.Create(txn);

            Console.Write("");
            Console.WriteLine("Done! Account details post Withdraw...");
            Console.WriteLine(account.ToString());
        }

        static void Deposit(Account account)
        {
            Console.WriteLine();
            Console.WriteLine($"Deposit into" +
                $" {GetEnumDescription(account.GetAccountType())} Account" +
                $" number {account.Id}"
            );

            Console.Write("Deposit how much? ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            account.Deposit(amount);

            TransactionService txnSvc = new TransactionService();
            Transaction txn = new Transaction
            {
                AccountId = account.Id,
                Amount = amount,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                TransactionDate = DateTime.Now.Date,
                TransactionType = TransactionType.Deposit
            };
            txnSvc.Create(txn);


            Console.WriteLine("Done! Account details post Deposit...");
            Console.WriteLine(account.ToString());
        }

        static Account GetAccount()
        {
            Console.WriteLine();
            Console.WriteLine("Get an account's details...");

            var accounts = GetCustomerAccounts();
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No accounts found...");
                return null;
            }
            PrintAllAccounts(accounts);

            Console.WriteLine();
            Console.Write("Which account? ");
            var accountId = Convert.ToInt32(Console.ReadLine());

            AccountService svc = new AccountService();
            var account = svc.Get(accountId);
            if (account == null || account.Id == 0)
            {
                Console.WriteLine("Account not found...");
            }
            else
            {
                Console.WriteLine(account.ToString());
            }
            return account;
        }

        static List<Account> GetCustomerAccounts()
        {
            var customer = GetCustomer();
            if (customer == null)
            {
                Console.WriteLine($"Customer not found!");
                return null;
            }

            AccountService svc = new AccountService();
            var accounts = svc.GetByCustomerId(customer.Id);
            return accounts;
        }

        static void PrintAllAccounts(IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        static void CreateAccount()
        {
            bool toExit = false;
            while (!toExit)
            {
                Console.WriteLine();
                Console.WriteLine("Create which type of account...");
                Console.WriteLine("1. Savings Bank Account");
                Console.WriteLine("2. Current Account");
                Console.WriteLine("3. Fixed Deposit");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("What would you like to do? ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        toExit = true;
                        break;
                    case "1":
                        CreateAccount(AccountTypes.Savings);
                        break;
                    case "2":
                        CreateAccount(AccountTypes.Current);
                        break;
                    case "3":
                        CreateFixedDeposit();
                        break;
                }
            }
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        static void CreateAccount(AccountTypes accountType)
        {
            Console.WriteLine();
            Console.WriteLine("Creating Savings Bank Account...");
            var customers = GetAllCustomers();
            PrintAllCustomers(customers);
            var customer = GetCustomer();
            if (customer == null)
            {
                Console.WriteLine($"Customer not found!");
                return;
            }

            Console.Write("Initial deposit of? ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            var account = AccountFactory.Get(accountType);

            account.Customer = customer;
            account.CreatedOn = DateTime.Now.Date;
            account.Balance = amount;
            account.IsActive = true;

            AccountService svc = new AccountService();
            svc.Create(account);

            TransactionService txnSvc = new TransactionService();
            Transaction txn = new Transaction
            {
                AccountId = account.Id,
                Amount = amount,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                TransactionDate = DateTime.Now.Date,
                TransactionType = TransactionType.Create
            };
            txnSvc.Create(txn);

            customer.Accounts.Add(account);
            CustomerService customerSvc = new CustomerService();
            customerSvc.Update(customer);
        }

        static void CreateFixedDeposit()
        {
            Console.WriteLine();
            Console.WriteLine("Creating Fixed Deposit Account...");

            var customers = GetAllCustomers();
            PrintAllCustomers(customers);
            var customer = GetCustomer();
            if (customer == null)
            {
                Console.WriteLine($"Customer not found!");
                return;
            }

            Console.Write("FD Amount? ");
            var amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Interest Rate (%)? ");
            var interestRate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Tenure (in months)? ");
            var tenure = Convert.ToInt32(Console.ReadLine());

            var createdOn = DateTime.Now.Date;
            var maturesOn = createdOn.AddMonths(tenure);
            maturesOn = maturesOn.AddDays(-1);

            var account = new FixedDepositAccount
            {
                Customer = customer,
                CreatedOn = createdOn,
                Balance = amount,
                IsActive = true,
                InterestRate = interestRate,
                Tenure = tenure,
                MaturesOn = maturesOn
            };

            AccountService svc = new AccountService();
            svc.Create(account);

            TransactionService txnSvc = new TransactionService();
            Transaction txn = new Transaction
            {
                AccountId = account.Id,
                Amount = amount,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                TransactionDate = DateTime.Now.Date,
                TransactionType = TransactionType.Create
            };
            txnSvc.Create(txn);

            customer.Accounts.Add(account);
            CustomerService customerSvc = new CustomerService();
            customerSvc.Update(customer);
        }

        static Customer GetCustomer()
        {
            Console.WriteLine();
            Console.Write("Enter Customer Id: ");
            var id = Convert.ToInt32(Console.ReadLine());

            CustomerService svc = new CustomerService();
            var customer = svc.Get(id);

            return customer;
        }

        static List<Customer> GetAllCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("Listing all customers...");
            CustomerService svc = new CustomerService();
            var customers = svc.Get();

            return customers;
        }

        static void PrintAllCustomers(List<Customer> customers)
        {
            foreach (var cust in customers)
            {
                PrintCustomer(cust);
            }
        }
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"Customer Id: {customer.Id}" +
                $" | Customer Name: {customer.Lastname}, {customer.Firstname}");
        }

        static void CreateCustomer()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Creating a customer...");
                Console.Write("Customer Firstname: ");
                var fname = Console.ReadLine();
                Console.Write("Customer Lastname: ");
                var lname = Console.ReadLine();

                var customer = new Customer
                {
                    Firstname = fname,
                    Lastname = lname
                };

                CustomerService svc = new CustomerService();
                svc.Create(customer);

                Console.Write("Create another Customer y/n? ");
                var option = Console.ReadLine();
                if (option.ToLower() == "n")
                    break;
            }
        }
    }
}