using AnyReadOnline.BOL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
   public class SalesMonth
    {
        public string month { get; set; }
        public int TotalSales { get; set; }


        public void SetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    this.month = "January";
                    break;
                case 2:
                    this.month = "Febuary";
                    break;
                case 3:
                    this.month = "March";
                    break;
                case 4:
                    this.month = "April";
                    break;
                case 5:
                    this.month = "May";
                    break;
                case 6:
                    this.month = "June";
                    break;
                case 7:
                    this.month = "July";
                    break;
                case 8:
                    this.month = "August";
                    break;
                case 9:
                    this.month = "September";
                    break;
                case 10:
                    this.month = "October";
                    break;
                case 11:
                    this.month = "November";
                    break;
                case 12:
                    this.month = "December";
                    break;
                default:
                    this.month = "";
                    break;
            }
        }
    }
}
