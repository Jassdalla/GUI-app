using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    internal class JerseyCow : Cow                  //Jersey class that inherets from the cow class
    {
        public JerseyCow(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtMilk, bool isJersy) : base(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersy) { }
        
        public override string getString()
        {
            return "This is a Cow " + "\r\n" + " ID: " + id.ToString() + "\r\n" + " Amount of water: " + amtWater.ToString() + " Liters/Day " + "\r\n" + " Daily Cost: $" + dailyCost.ToString()
            + "\r\n" + " Weight(Kg): " + weight.ToString() + "\r\n" + " Age: " + age.ToString() + " Years " + "\r\n" + " Colour: " + color + "\r\n" + " Amount of milk: " + amtMilk.ToString() + " Liters/Day "+"\r\n" + " Is Jersey cow: " + isJersey.ToString();
        }
        public override double getProfit()
        {
            double Profit = amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice + ( Prices.GovtTax + Prices.JerseyTax) * weight + dailyCost);
            return Profit;
        }
        public override double totalMilk()                  //calculating total amount of milk
        {
            double totalMilk = amtMilk;
            return totalMilk;
        }
        public override double TotalTaxPerMonth()           //total tax per month for jersey cow 
        {
            double tax = (Prices.GovtTax * weight  + Prices.JerseyTax * weight) * (365.0 / 12);
            return tax;
        }
        public override double TotalTaxJerseyPerMonth()
        {
            double TotalTaxJersey = (Prices.JerseyTax * weight) * (365.0 / 12);
           return TotalTaxJersey;
        }
        public override double AverageProfit()                              //method to calculate average profit
        {
            double AverageProfitJersey= amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice + (Prices.GovtTax + Prices.JerseyTax) * weight + dailyCost);
            return AverageProfitJersey;
        }
        public override double TotalJerseyProfitPerMonth()
        {
            double Profit = amtMilk * Prices.CowMilkPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + (Prices.JerseyTax * weight)) + dailyCost;
            return Profit; 
        }
        public override double getProfitForEachAnimal()
        {
            return getProfit();
        }
    }
}
