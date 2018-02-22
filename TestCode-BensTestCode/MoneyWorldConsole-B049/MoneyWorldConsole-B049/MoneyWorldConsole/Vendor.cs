using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace MoneyWorldConsole
{
    public class Vendor : WorldObject
    {
        internal string _name;
        internal List<CirculatingMoney> _myMoney;
        
        public string Name { get { return _name; } }

        public event ReceiptHandler TransactionCompleted;
        

        public Vendor(string name)
        {
            this._name = name;
        }

        internal void RaiseTransactionCompleted(Receipt receipt)
        {
            // The TransactionCompleted event is defined in this base class
            // and can only be raised from the same class, sub classes must
            // call this internal method to raise the event.
            TransactionCompleted(receipt);
        }

        internal void DepositMoney(List<CirculatingMoney> moneyIn)
        {
            // Calls the Generic List Collection classes InsertRange method to add 
            // the incoming collection of money to myMoney
            _myMoney.InsertRange(_myMoney.Count, moneyIn);
        }

        internal List<CirculatingMoney> WithdrawMoney(decimal amount)
        {
            List<CirculatingMoney> moneyOut = new List<CirculatingMoney>();
            decimal remainingAmount = amount;
            //_myMoney.Sort();   // CompareTo method not yet implemented in Money
            _myMoney.Reverse(); // Must be descending sort

            // After sorting _myMoney in descending order, 
            // walk all the items in the list 
            // and if the value of the currentMoneyItem 
            // is less than or equal to the remainingAmount variable,
            // then add the currentMoneyItem to the moneyOut list
            // and then subtract its value from the remainingAmount variable.
            foreach (CirculatingMoney currentMoneyItem in _myMoney)
            {
                if(currentMoneyItem.Value <= remainingAmount)
                {
                    moneyOut.Add(currentMoneyItem);
                    remainingAmount -= currentMoneyItem.Value;
                }

                // If the remainingBalance is zero, then exit the loop
                if(remainingAmount == 0)
                {
                    break;
                }
            }

            // If the remainingBalance is zero, which means that the
            // correctAmount was collected, then remove those collected items
            // from myMoney and return the moneyOut collection 
            // otherwise we will return an empty list
            if(remainingAmount == 0)
            {
                TransactionCompleted(new Receipt(this.Name, DateTime.Now, "Withdraw", -amount));
                return moneyOut;
            }
            else
            {
                return new List<CirculatingMoney>();
            }

            
        }

        internal decimal CountMoney(List<CirculatingMoney> money)
        {
            decimal result = 0m;
            foreach (CirculatingMoney m in money)
            {
                result += m.Value;
            }
            return result;
        }
    }
}
