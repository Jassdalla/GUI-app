using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    class Sheep: Livestock //inherets from class Livestock
    {
        public double amtWool { get; set;}
        public Sheep(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtWool): base (id,amtWater,dailyCost, weight,age,color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.amtWool = amtWool;
        }
        public override string getString()                                                       // Method to get the values associated with the particular animal.
        {
            return "This is a SHEEP " + "\r\n" + " ID: " + id.ToString() + "\r\n" + " Amount of water: " + amtWater.ToString() + " Liters/Day " + "\r\n" + " Daily Cost: $" + dailyCost.ToString()
            + "\r\n" + " Weight(Kg): " + weight.ToString() + "\r\n" + " Age: " + age.ToString() + " Years " + "\r\n" + " Colour: " + color + "\r\n" + " Amount of wool: " + amtWool.ToString() + " Kg/Day ";
        }
        public override double getProfit()                                                       // Method to get the total profit per day.
        {
            double Profit = amtWool * Prices.SheepWoolPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost);    //Total profit = income - expenses.
            return Profit;
        }
        public override double totalDailyCost()                                                 //Calculate daily cost for Sheeps
        {
            double ratioSheep = dailyCost;
            return ratioSheep;
        }
        public override double TotalTaxPerMonth()                                               //Calculating total tax paid per month.
        {
            double tax = Prices.GovtTax * weight * (365.0 / 12);
            return tax;
        }
        public override string getID()
        {
            return id.ToString();
        }
        public override double AverageProfitSheep()                                             // Calculating average profit for sheeps.
        {
            double AverageProfitShee = amtWool * Prices.SheepWoolPrice - (amtWater * Prices.WaterPrice + weight * Prices.GovtTax + dailyCost);
            return AverageProfitShee;
        }
        //-----------------
        public override double getProfitForEachAnimal()
        {
            return getProfit();
        }
    }
}
