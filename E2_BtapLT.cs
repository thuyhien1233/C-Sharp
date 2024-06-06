using System;

namespace TaiKhoanNganHang
{
    // Định nghĩa ngoại lệ tùy chỉnh cho trường hợp số dư không đủ
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("So du tai khoan khong du de thuc hien giao dich.")
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    // Định nghĩa ngoại lệ tùy chỉnh cho trường hợp số tiền âm
    public class NegativeAmountException : Exception
    {
        public NegativeAmountException() : base("So tien nop hoac rut khong the la so am.")
        {
        }

        public NegativeAmountException(string message) : base(message)
        {
        }

        public NegativeAmountException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    // Lớp BankAccount
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new NegativeAmountException("So du ban dau khung the la so am.");
            }
            balance = initialBalance;
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException();
            }
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException();
            }
            if (balance - amount < 0)
            {
                throw new InsufficientFundsException();
            }
            balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Nhap so du ban dau: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine());
                BankAccount account = new BankAccount(initialBalance);

                Console.WriteLine("Tai khoan duoc tao thanh cong.");
                Console.WriteLine($"So du hien tai: {account.Balance}");

                Console.Write("Nhap so tien muon nop: ");
                decimal depositAmount = decimal.Parse(Console.ReadLine());
                account.Deposit(depositAmount);
                Console.WriteLine($"Da nop {depositAmount}. So du hien tai: {account.Balance}");

                Console.Write("Nhap so tien muon rut: ");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                account.Withdraw(withdrawAmount);
                Console.WriteLine($" Da rut {withdrawAmount}. So du hien tai: {account.Balance}");
            }
            catch (NegativeAmountException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            catch (InsufficientFundsException ex)  
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap mot so thap phan hop le.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Da xay ra loi khong mong muon: {ex.Message}");
            }
        }
    }
}
