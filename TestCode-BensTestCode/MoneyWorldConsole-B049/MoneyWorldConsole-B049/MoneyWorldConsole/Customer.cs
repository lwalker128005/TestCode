using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace MoneyWorldConsole
{
    public class Customer : WorldObject
    {
        private List<CirculatingMoney> _wallet = new List<CirculatingMoney>();
        private Dictionary<string, string> _accounts = new Dictionary<string, string>();
        private Dictionary<string, Receipt> _receipts = new Dictionary<string, Receipt>();
        private Vendor _currentVendor = null;

        public Customer(string name, List<CirculatingMoney> startupMoney)
        {
            this.Name = name;
            this._wallet.InsertRange(0, startupMoney); 
        }

        public string Name { get; private set; }

        private string GetBankAccountNumber(string vendor){
            return _accounts[vendor];
        }

        internal List<CirculatingMoney> GetMoneyFromWallet(decimal amount)
        {
            List<CirculatingMoney> tempMoney = new List<CirculatingMoney>();
            decimal remainingAmount = amount;
            //_wallet.Sort();
            foreach(CirculatingMoney m in _wallet)
            {
                if(m.Value <= remainingAmount)
                {
                    tempMoney.Add(m);
                    remainingAmount -= m.Value;
                }
            }

            if(remainingAmount == 0)
            {
                foreach(CirculatingMoney m in tempMoney)
                {
                    _wallet.Remove(m);
                }
                return tempMoney;
            }
            else
            {
                _wallet.InsertRange(_wallet.Count(), tempMoney);
                return new List<CirculatingMoney>();
            }
        }

        internal void DepositMoneyInBank(decimal amount)
        {
            if(_currentVendor is Bank tempBank)
            {
                PayVendor(amount);
            }
            else
            {
                throw new NotSupportedByVendor(String.Format("{0} does not support a bank deposit.", _currentVendor.Name));
            }
        }

        internal void PayVendor(decimal amount)
        {
            if (_currentVendor is Bank tempBank)
            {
                tempBank.DepositMoneyInAccount(_accounts[_currentVendor.Name], GetMoneyFromWallet(amount));
            }
            else
            {
                _currentVendor.DepositMoney(GetMoneyFromWallet(amount));
            }

        }

        public decimal HowMuchMoneyDoYouHave()
        {
            decimal walletTotal = 0.0m;
            foreach(CirculatingMoney m in _wallet)
            {
                walletTotal += m.Value;
            }
            return walletTotal;
        }

        internal void Enter(Vendor vendor)
        {
            if(_currentVendor is null)
            {
                _currentVendor = vendor;
                vendor.TransactionCompleted += MyReceiptHandler;
                if (vendor is Bank tempBank)
                {
                    tempBank.AccountCreated += MyNewAccountHandler;
                }
            }
            else
            {
                throw new MustExitCurrentVendor(String.Format("{0} is trying to enter {1}, but must exit {2} first.", this.Name, vendor.Name, _currentVendor.Name));
            }

        }

        internal void WithdrawMoneyFromBank(decimal amount)
        {
            if (_currentVendor is Bank tempBank)
            {
                GetMoneyFromVendor(tempBank.WithrawMoneyFromAccount(_accounts[_currentVendor.Name], amount));
            }
            else
            {
                throw new NotSupportedByVendor(String.Format("{0} does not support a withraw from Bank.", _currentVendor.Name));
            }
        }

        internal void GetMoneyFromVendor(List<CirculatingMoney> change)
        {
            _wallet.InsertRange(_wallet.Count, change);
        }

        internal void Exit()
        {
            if(!(_currentVendor is null))
            {
                _currentVendor.TransactionCompleted -= MyReceiptHandler;
                if (_currentVendor is Bank tempBank)
                {
                    tempBank.AccountCreated -= MyNewAccountHandler;
                }
                _currentVendor = null;
            }
            else
            {
                throw new MustEnterVendorBeforeExiting(String.Format("{0} is trying to exit a vendor, but is not currently using a vendor.",this.Name));
            }
        }

        private void MyReceiptHandler(Receipt myReceipt)
        {
            // Temp workaround for timestamp duplicates
            _receipts.Add(DateTime.Now.AddMilliseconds((double)myReceipt.Amount).ToString("o"), myReceipt);
            System.Console.WriteLine("New Receipt from {1} in the amount of {2} was received by {0}.", this.Name, myReceipt.VendorName, myReceipt.Amount);
        }

        private void MyNewAccountHandler(string vendorName, string accountNumber)
        {
            _accounts.Add(vendorName, accountNumber);
            System.Console.WriteLine("New Account for {0} with {1} was opened.  The account number is {2}.",this.Name, vendorName, accountNumber);
        }



    }
}
