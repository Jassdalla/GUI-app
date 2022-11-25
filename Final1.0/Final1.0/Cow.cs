using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    class Cow: Livestock                             //inherets from class Livestock
    {
        public double amtMilk { get; set; }
       public bool isJersey;
        public Cow(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtMilk, bool isJersey) : base(id, amtWater,  dailyCost, weight, age, color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.amtMilk = amtMilk;
            this.isJersey = isJersey;
        }
        public override string getString()                                  // Method to get the values associated with the particular animal.
        {
            return "This is a COW " + "\r\n" + " ID: " + id.ToString() + "\r\n" + " Amount of water: " + amtWater.ToString() + " Liters/Day " + "\r\n" + " Daily Cost: $" + dailyCost.ToString()
            + "\r\n" + " Weight(Kg): " + weight.ToString() + "\r\n" + " Age: " + age.ToString() + " Years " + "\r\n" + " Colour: " + color + "\r\n" + " Amount of milk: " + amtMilk.ToString() + " Liters/Day "  +"\r\n" + " Is Jersey cow: " + isJersey.ToString();
        }
        public override double getProfit()                          // Method to get the total profit per day.
        {
            double Profit = amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost);
            return Profit;
        }
        public override double totalMilk()
        {

            double totalMilk = amtMilk;
            return totalMilk;
        }
        public override double totalDailyCost()
        {
            double ratioCow = dailyCost;
            return ratioCow;
        }
        public override double TotalTaxPerMonth()                                            //Calculating total tax paid per month.
        {
            double tax = Prices.GovtTax * weight * (365 / 12);
            return tax;
        }
        
        //------ Average profit for Cows VS sheeps--------
        public override double AverageProfit()
        {
            double AverageProfitCow = amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost);    //Total profit = income - expenses.
            return AverageProfitCow;
        }
        //----- Tax paid for jersey cows per month--------------
        public override double TotalTaxJerseyPerMonth()
        {
            double TotalTaxJersey = (Prices.JerseyTax * weight) * (365 / 12);
            return TotalTaxJersey;
        }
        //-----------------------------
        public override string getID()
        {
            return id.ToString();
        }
        //------
        public override double TotalJerseyProfitPerMonth()
        {
            double Profit = amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice) + (weight * Prices.GovtTax) + dailyCost;
            return Profit;
        }
        //-----------------------------
        public override double getProfitForEachAnimal()
        {
            return getProfit();
        }
    }
}
