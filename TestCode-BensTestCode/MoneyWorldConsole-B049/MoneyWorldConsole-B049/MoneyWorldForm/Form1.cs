using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyWorldConsole;
using MoneyLib;

namespace MoneyWorldForm
{
    public partial class Form1 : Form
    {
        private Store _quickyMart;
        private VendingMachine _ccSnacks;
        private Bank _moneyMutual;
        private Customer _bob;

        public Form1()
        {
            InitializeComponent();

            MoneyWorld myworld = new MoneyWorld();
            Bob = new Customer("Bob", GetStartupMoney(100));
            txtWallet.Text = Bob.HowMuchMoneyDoYouHave().ToString();
            MoneyMutual = new Bank("Money Mutual", GetStartupMoney(10000));
            CCSnacks = new VendingMachine("City College Snacks", GetStartupMoney(10));
            QuickyMart = new Store("Quicky Mart", GetStartupMoney(1000));
        }



        public Customer Bob { get { return _bob; } set { _bob = value; } }
        public Bank MoneyMutual { get { return _moneyMutual; } set { _moneyMutual = value; } }
        public VendingMachine CCSnacks { get { return _ccSnacks; } set { _ccSnacks = value; } }
        public Store QuickyMart { get { return _quickyMart; } set { _quickyMart = value; } }

        public object HowMuchMoneyDoYouHave { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
           



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

        private void lbxReceipts_DoubleClick(object sender, EventArgs e)
        {
            lbxReceipts.Items.Add(new Receipt("MoneyMutual", DateTime.Now, "Test", 10.00m));
        }
    }
}
