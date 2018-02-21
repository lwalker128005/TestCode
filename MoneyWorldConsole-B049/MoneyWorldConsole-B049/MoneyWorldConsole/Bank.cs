using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace MoneyWorldConsole
{
   public class Bank : Vendor
    {
        private int _acctSeed = 20180000;
        private Dictionary<string, decimal> _accounts = new Dictionary<string, decimal>();

        public event AccountCreatedHandler AccountCreated;

        public Bank(string name, List<CirculatingMoney> startupMoney) : base(name)
        {
            this._myMoney = startupMoney;
        }

        public void OpenAccount(Customer cust)
        {
            string tempAcctNo = GetNewAccount();
            _accounts.Add(tempAcctNo, 0.00m);
            AccountCreated(_name, tempAcctNo);
        }

        public void DepositMoneyInAccount(string accountNumber, List<CirculatingMoney> money)
        {
            _accounts[accountNumber] += this.CountMoney(money);
            DepositMoney(money);
            // The TransactionCompleted event must be called from
            // the base Vendor class, so this calls an internal 
            // method of the base class to raise the event.
            RaiseTransactionCompleted(new Receipt(this.Name, DateTime.Now, "Deposited to " + accountNumber, CountMoney(money)));
        }

        public List<CirculatingMoney> WithrawMoneyFromAccount(string accountNumber, decimal amount)
        {
            if(_accounts[accountNumber] >= amount)
            {
                _accounts[accountNumber] -= amount;
                return this.WithdrawMoney(amount);
            }
            else
            {
                return new List<CirculatingMoney>();
            }
        }

        private string GetNewAccount()
        {
            return "1005-567-" + _acctSeed++;
        }
    }
}
