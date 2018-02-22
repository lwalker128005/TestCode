using System;

namespace MoneyWorldConsole
{
    public class Receipt
    {
        public string VendorName { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string Comments { get; private set; }
        public decimal Amount { get; private set; }

        public Receipt(string vendor, DateTime datetime, string comments, decimal amount)
        {
            VendorName = vendor;
            TransactionDate = datetime;
            Comments = comments;
            Amount = amount;
        }

        public override string  ToString()
        {
            return String.Format("Receipt from {1} for {0} amount", Amount, VendorName);
        }
    }
}