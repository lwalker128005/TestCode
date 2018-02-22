using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace MoneyWorldConsole
{
   public class Program
    {
        static void Main(string[] args)
        {
            //Create Test Instance of MoneyWorld
            MoneyWorld BensWorld = new MoneyWorld();

            BensWorld.UseCaseBob01();

            System.Console.ReadLine();
        }

    }
}
