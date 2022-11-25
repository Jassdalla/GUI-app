using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1._0
{
    class Livestock                                         //Super class for all other classes and setting constructors and parameters
    {
        public int id { get; set; }
        public double amtWater { get; set; }
        public double dailyCost { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public String color { get; set; }

        public Livestock(int id, double amtWater, double dailyCost, double weight, int age, string color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
        }
        public virtual double getProfit()            //virtual class that can be overridden by sub classes to show Polymorphism
        {                                            // Method to get the total profit per day.
            return 0;
        }
        public virtual string getID()
        {
            return id.ToString();
        }
        public virtual double getProfitForEachAnimal()
        {
            return 0;
        }
        public virtual double totalMilk()
        {
            return 0; 
        }
        public virtual double totalDailyCost()
        {
            return 0;
        }
        public virtual double totalDogCost()
        {
            return 0;
        }
        public virtual double TotalTaxPerMonth()                                            //Calculating total tax paid per month.
        {
            return 0;
        }
        public virtual double AverageAgeOfAnimals()
        {
            double AverageAge = age;
            return AverageAge;
        }
        public virtual double AverageProfit()
        {
            return 0;
        }
        public virtual double AverageProfitSheep()                                       // Calculating average profit for sheeps.
        {
            return 0;
        }
        public virtual double TotalTaxJerseyPerMonth()
        {
            return 0;

        }
        public virtual double TotalJerseyProfitPerMonth()
        {
            return 0;
        }
        public virtual string ColourRatio()
        {
            string Colour = color;
            return Colour;
        }
        public virtual int RatioAge()
        {
            int ageRatio = age;
            return ageRatio; 
        }
        public virtual string getString()
        {
            return "This is a Livestock " + id.ToString() + " " + amtWater.ToString() + " " + dailyCost.ToString()
            + " " + weight.ToString() + " " + age.ToString() + " " + color ;
        }
    }
}
