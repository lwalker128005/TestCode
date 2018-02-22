using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MoneyLib;

namespace MoneyWorldConsole
{
    public delegate void AccountCreatedHandler(string vendorName, string accountNumber);
    public delegate void ReceiptHandler(Receipt transactionReceipt);

    [System.Serializable]
    class MustExitCurrentVendor : Exception
    {
        public MustExitCurrentVendor() { }
        public MustExitCurrentVendor(string message) : base(message) { }
        public MustExitCurrentVendor(string message, Exception inner) : base(message, inner) { }
        protected MustExitCurrentVendor(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [System.Serializable]
    class MustEnterVendorBeforeExiting : Exception
    {
        public MustEnterVendorBeforeExiting() { }
        public MustEnterVendorBeforeExiting(string message) : base(message) { }
        public MustEnterVendorBeforeExiting(string message, Exception inner) : base(message, inner) { }
        protected MustEnterVendorBeforeExiting(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [System.Serializable]
    class NotSupportedByVendor : Exception
    {
        public NotSupportedByVendor() { }
        public NotSupportedByVendor(string message) : base(message) { }
        public NotSupportedByVendor(string message, Exception inner) : base(message, inner) { }
        protected NotSupportedByVendor(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class MoneyWorld
    {
        private Customer _bob;
        private Bank _moneyMutual;
        private VendingMachine _ccSnacks;
        private Store _quickyMart;

        public Customer Bob { get { return _bob; } set { _bob = value; } }
        public Bank MoneyMutual { get { return _moneyMutual; } set { _moneyMutual = value; } }
        public VendingMachine CCSnacks { get { return _ccSnacks; } set { _ccSnacks = value; } }
        public Store QuickyMart { get { return _quickyMart; } set { _quickyMart = value; } }

        

        public MoneyWorld()
        {
            // Instantiate primary world objects that will be referenced in Use Cases.
            Bob = new Customer("Bob", GetStartupMoney(100));
            Console.WriteLine("Bob has {0} in his wallet.",Bob.HowMuchMoneyDoYouHave());
            MoneyMutual = new Bank("Money Mutual", GetStartupMoney(10000));
            CCSnacks = new VendingMachine("City College Snacks", GetStartupMoney(10));
            QuickyMart = new Store("Quicky Mart", GetStartupMoney(1000));
        }

        public void UseCaseBob01()
        {
            // Bob enters bank and makes a deposit
            Bob.Enter(MoneyMutual);
            MoneyMutual.OpenAccount(Bob);
            Bob.DepositMoneyInBank(1500.00m);
            Console.WriteLine("Bob has {0} in his wallet.", Bob.HowMuchMoneyDoYouHave());
            Bob.Exit();

            Bob.Enter(MoneyMutual);
            Bob.WithdrawMoneyFromBank(500.00m);
            Console.WriteLine("Bob has {0} in his wallet.", Bob.HowMuchMoneyDoYouHave());
            Bob.DepositMoneyInBank(25.00m);
            Console.WriteLine("Bob has {0} in his wallet.", Bob.HowMuchMoneyDoYouHave());
            Bob.Exit();
        }

        public void UseCaseBob02()
        {
            // add try catch and test custom exceptions

            // Bob enters bank and makes a withdrawal
            Bob.Enter(MoneyMutual);
            MoneyMutual.WithdrawMoney(103.35m);
            Bob.Exit();
        }

        public List<CirculatingMoney> GetStartupMoney(int count)
        {
            List<CirculatingMoney> tempMoney = new List<CirculatingMoney>();

            for (int i = 0; i < count; i++)
            {
                tempMoney.Add(new Penny());
                tempMoney.Add(new Nickel());
                tempMoney.Add(new Dime());
                tempMoney.Add(new Quarter());
                tempMoney.Add(new DollarBill());
                tempMoney.Add(new TwoDollarBill());
                tempMoney.Add(new FiveDollarBill());
                tempMoney.Add(new SilverDollar());
                tempMoney.Add(new TenDollarBill());
                tempMoney.Add(new TwentyDollarBill());
            }

            return tempMoney;
        }
    }
}
