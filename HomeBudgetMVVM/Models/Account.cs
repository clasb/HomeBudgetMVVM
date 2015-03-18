using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace HomeBudgetMVVM.Models
{
    public class Account
    {


        public Account()
        {
            Date = DateTime.Now;
        }

        public Account(DateTime d)
        {
            Date = d;
        }

        public void AddEvent(AccountEvent ae)
        {
            
        }

        public void UpdateBalance()
        {
            
        }

        public override string ToString()
        {
            return AccountName;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String AccountName { get; set; }
        public String Number { get; set; }
        public double Balance { get; set; }
        public double StartBalance { get; set; }
        public String Bank { get; set; }
        public String Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
