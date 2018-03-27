using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates.Callback;
using Delegates.Reusability;
namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates callbacks----------------------------------------------");
            Process proc = new Process();
            proc.RunBigProcess(CheckProgress);

            Console.WriteLine("Delegates reusability----------------------------------------------");
            Loan loan = new Loan();
            bool isApproved = loan.IsApproved(new Customer() { Name = "Victor", AnnualIncome = 100000, HasNoPaidLoans = true });
            Console.WriteLine("Victor's loan was approved? {0}", isApproved);
            isApproved = loan.IsApproved(CustomRules, new Customer() { Name = "Victor", AnnualIncome = 100000, HasNoPaidLoans = true });
            Console.WriteLine("Victor's loan with custom rules was approved? {0}", isApproved);

            Console.WriteLine("Delegates Action----------------------------------------------");
            Action<int, int> actionDel = (int x, int y) => { Console.WriteLine("this is an action {0} {1}", x,y); };
            actionDel.Invoke(5,12);

            Console.WriteLine("Delegates Function----------------------------------------------");
            Func<int, int, int> functionDel = (int x, int y) => { Console.WriteLine("this is Func {0} {1}", x,y ); return x*y; };
            int result = functionDel(10,11);
            Console.WriteLine("Result = {0}",result);

            Func<Customer, bool> approveRules = (Customer customer) =>
            {
                if (customer.AnnualIncome > 12000 && !customer.HasNoPaidLoans)
                {
                    return true;
                }
                return false;
            };

            isApproved = loan.IsApproved2(approveRules, new Customer() { Name = "Victor", AnnualIncome = 100000, HasNoPaidLoans = true });
            Console.WriteLine("Victor's loan with custom FUNCTION rules was approved? {0}", isApproved);

            Console.ReadKey();
        }

        private static bool CustomRules(Customer customer)
        {
            if (customer.AnnualIncome >= 25000)
            {
                return true;
            }
            return false;
        }

        private static void CheckProgress(int percent)
        {
            Console.WriteLine("Progress is {0} %",percent);
        }
    }
}
