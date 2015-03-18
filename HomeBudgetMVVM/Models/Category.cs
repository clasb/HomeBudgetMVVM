using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace HomeBudgetMVVM.Models
{
    public class Category
    {

        public Category()
        {
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return CategoryName;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryComment { get; set; }
        public DateTime Date { get; set; }
        public double CategoryBalance { get; set; }
    }
}
