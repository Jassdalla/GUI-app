using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    class Dog: Livestock   //inherets from class Livestock
    {
        public Dog(int id, double amtWater, double dailyCost,  double weight, int age, string color) : base(id, amtWater, dailyCost, weight, age, color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.dailyCost = dailyCost;
        }
        public override string getString()                          // Method to get the values associated with the particular animal.
        {
            return "This is a DOG " + "\r\n" + " ID: " + id.ToString() + "\r\n" + " Amount of water: " + amtWater.ToString() + " Liters/Day " + "\r\n" + " Daily Cost: $" + dailyCost.ToString()
            + "\r\n" + " Weight(Kg): " + weight.ToString() + "\r\n" + " Age: " + age.ToString() + " Years " + "\r\n" + " Colour: " + color;
        }
        public override double getProfit()                              // Method to get the total profit per day.
        {
            double Profit = amtWater * Prices.WaterPrice + weight + dailyCost;    //Total profit = income - expenses.
            return Profit;
        }
        public override double totalDailyCost()
        {
            double ratioDog1 = dailyCost;
            return ratioDog1;
        }
        public override double totalDogCost()
        {
            double ratioDog = dailyCost;
            return ratioDog;
        }
        public override double TotalTaxPerMonth()                                            //Calculating total tax paid per month.
        {
            double tax = Prices.GovtTax * weight * (365.0 / 12);
            return tax;
        }
        public override string getID()
        {
            return id.ToString();
        }
        public override double getProfitForEachAnimal()
        {
            return getProfit();
        }
    }
}
