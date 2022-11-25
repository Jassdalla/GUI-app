using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    class Goat: Livestock   //inherets from class Livestock
    {
        public double amtMilk { get; set; }

        public Goat(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtMilk) : base(id, amtWater,  dailyCost, weight, age, color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.amtMilk = amtMilk;
        }
        public override string getString()                          // Method to get the values associated with the particular animal.
        {
            return "This is a GOAT "+ "\r\n" + " ID: " + id.ToString() +"\r\n"  + " Amount of water: " + amtWater.ToString() + " Liters/Day " + "\r\n" + " Daily Cost: $" + dailyCost.ToString()
            + "\r\n" + " Weight(Kg): " + weight.ToString() + "\r\n" + " Age: " + age.ToString() + " Years " + "\r\n" + " Colour: " + color + "\r\n" + " Amount of milk: " + amtMilk.ToString() + " Liters/Day ";
        }
        public override string getID()
        {
            return id.ToString();
        }
        public override double getProfit()                              // Method to get the total profit per day.
        {
            double Profit = amtMilk * Prices.GoatMilkPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost) ;
            return Profit;
        }
        public override double totalMilk()
        {
            double totalMilk = amtMilk;
            return totalMilk;
        }
        public override double totalDailyCost()
        {
            double ratioGoat = dailyCost;
            return ratioGoat;
        }
        public override double TotalTaxPerMonth()                                            //Calculating total tax paid per month.
        {
            double tax = Prices.GovtTax * weight * (365.0/12) ;
            return tax;
        }
        public override double AverageProfit()
        {
            double AverageProfitGoat = amtMilk * Prices.GoatMilkPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost);    //Total profit = income - expenses.
            return AverageProfitGoat;
        }
        public override double getProfitForEachAnimal()
        {
            return getProfit();
        }
    }
}
