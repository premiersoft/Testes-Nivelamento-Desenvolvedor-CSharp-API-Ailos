namespace Questao1
{
    public class ContaBancaria
    {

        public int AccountNumber { get; private set; }
        public string AccountFullName { get; private set; }
        public double? InitialMoneyWithdrawal { get; private set; }
        public double AccountBalance { get; private set; }

        public ContaBancaria()
        {}

        public ContaBancaria(int accountNumber, string accountFullName)
        {
            AccountNumber = accountNumber;
            AccountFullName = accountFullName;
        }

        public ContaBancaria(int accountNumber, string accountFullName, double? initialMoneyWithdrawal)
        {
            AccountNumber = accountNumber;
            AccountFullName = accountFullName;
            InitialMoneyWithdrawal = initialMoneyWithdrawal;
            if (initialMoneyWithdrawal.HasValue)
                AccountBalance += initialMoneyWithdrawal.Value;
        }

        public override string ToString()
        { 
            return $"Conta {AccountNumber}, Titular: {AccountFullName}, Saldo: $ {AccountBalance}";

        }
        public void Deposito(double amount)
        { 
            AccountBalance += amount;
        }
        public void AlterarTitular(string name)
        { 
            AccountFullName = name;
        }
        public void Saque(double amount)
        {
            var tax = 3.5d;
            AccountBalance += ((amount + tax) * -1);
        }
    }
}
