using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Reusability
{
    public class Loan
    {
        public delegate bool ApprovedRules(Customer customer);
        /// <summary>
        /// Here our code is not re-usable because our Approved rules are hard coded in the method
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool IsApproved(Customer customer)
        {
            if (customer.HasNoPaidLoans)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Here our rules are passed, so can be different
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool IsApproved(ApprovedRules rules, Customer customer)
        {
            return rules(customer);
        }
        public bool IsApproved2(Func<Customer,bool> rules, Customer customer)
        {
            return rules(customer);
        }
    }
}
