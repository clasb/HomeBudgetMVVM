using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace HomeBudgetMVVM.Models
{
    public class AccountEvent
    {
        public Account EventAccount
        { get { return App.Database.GetAccount(AccountID); }}

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String EventType { get; set; }
        public double EventBalance { get; set; }
        public String EventComment { get; set; }
        public DateTime Date { get; set; }
        public int AccountID { get; set; }
        public int CategoryID { get; set; }
    }
}
