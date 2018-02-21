using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace MoneyWorldConsole
{
    public class Store : Vendor
    {

        public Store(string name, List<MoneyLib.CirculatingMoney> startupMoney) : base(name)
        {
            this._myMoney = startupMoney;
        }
    }
}
