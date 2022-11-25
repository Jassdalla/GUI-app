using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Final1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //---- Creating a Dictionary to retrieve all the data from tables of access database------------
        internal class Variables
        {
            public static Dictionary<int, Livestock> Animals = new Dictionary<int, Livestock>();            //Empty dictionary
        }
        public static void checkConn()
        {
            String q = " Select * From Dogs";                                                               //Query commands to retrieve data from each table
            String q1 = " Select * From Goat";
            String q2 = " Select * From Sheep";
            String q3 = "Select * From Cow";
            String q4 = "Select * From Prices";
            try
            {
                OleDbConnection connection = new OleDbConnection();                                       //creating a new connection.
                connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\jassd\Desktop\Semester 4\App Deve\FInalFarm.accdb;Persist Security Info = False";   //File path
                connection.Open();
                OleDbCommand cmd1 = new OleDbCommand(q1, connection);
                using (OleDbDataReader reader = cmd1.ExecuteReader())
                    while (reader.Read())                                                                   //using query to read the Goat's table
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        double amtWater = Convert.ToDouble(reader[1].ToString());
                        double dailyCost = Convert.ToDouble(reader[2].ToString());
                        double weight = Convert.ToDouble(reader[3].ToString());
                        int age = Convert.ToInt32(reader[4].ToString());
                        string color = reader[5].ToString();
                        double amtMilk = Convert.ToDouble(reader[6].ToString());
                        if ((amtMilk < 0) == true)                                                          //Error handling for Negative Milk value.
                        {                                                                                   // If Milk or Wool value is negative, it will show a message box and application will stop.   
                            MessageBox.Show("Milk amount can not be negative. Check the value in access database file.");
                            Application.Exit();
                        }
                        Livestock p = new Goat(id, amtWater, dailyCost, weight, age, color, amtMilk);
                        Variables.Animals.Add(id, p);
                    }
                connection.Close();
                connection.Open();
                OleDbCommand cmd2 = new OleDbCommand(q2, connection);
                using (OleDbDataReader reader = cmd2.ExecuteReader())
                    while (reader.Read())                                                                   //using query to read the Sheep's table
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        double amtWater = Convert.ToDouble(reader[1].ToString());
                        double dailyCost = Convert.ToDouble(reader[2].ToString());
                        double weight = Convert.ToDouble(reader[3].ToString());
                        int age = Convert.ToInt32(reader[4].ToString());
                        string color = reader[5].ToString();
                        double amtWool = Convert.ToDouble(reader[6].ToString());
                        if ((amtWool < 0) == true)                                                          //Error handling for Negative Milk value.
                        {                                                                                   // If Milk or Wool value is negative, it will show a message box and application will stop.   
                            MessageBox.Show("Wool amount can not be negative. Check the value in access database file.");
                            Application.Exit();
                        }
                        Livestock p = new Sheep(id, amtWater, dailyCost, weight, age, color, amtWool);
                        Variables.Animals.Add(id, p);
                    }
                connection.Close();
                connection.Open();
                OleDbCommand cmd3 = new OleDbCommand(q3, connection);
                using (OleDbDataReader reader = cmd3.ExecuteReader())
                    while (reader.Read())                                                                   //using query to read the Cow's table
                    {
                        bool Jersey = false;
                        if (Jersey != true)
                        {
                            int id = Convert.ToInt32(reader[0].ToString());
                            double amtWater = Convert.ToDouble(reader[1].ToString());
                            double dailyCost = Convert.ToDouble(reader[2].ToString());
                            double weight = Convert.ToDouble(reader[3].ToString());
                            int age = Convert.ToInt32(reader[4].ToString());
                            string color = reader[5].ToString();
                            double amtMilk = Convert.ToDouble(reader[6].ToString());
                            if((amtMilk < 0)== true)                                                        //Error handling for Negative Milk value.
                            {                                                                               // If Milk or Wool value is negative, it will show a message box and application will stop.            
                                MessageBox.Show("Milk amount can not be negative. Check the value in access database file.");
                                Application.Exit();
                            }
                            bool isJersey = Convert.ToBoolean(reader[7].ToString());
                            Livestock p = new Cow(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersey);
                            Variables.Animals.Add(id, p);
                        }
                        else
                        {
                            int id = Convert.ToInt32(reader[0].ToString());
                            double amtWater = Convert.ToDouble(reader[1].ToString());
                            double dailyCost = Convert.ToDouble(reader[2].ToString());
                            double weight = Convert.ToDouble(reader[3].ToString());
                            int age = Convert.ToInt32(reader[4].ToString());
                            string color = reader[5].ToString();
                            double amtMilk = Convert.ToDouble(reader[6].ToString());
                            if ((amtMilk < 0) == true)                                                          //Error handling for Negative Milk value.
                            {                                                                                   // If Milk or Wool value is negative, it will show a message box and application will stop.   
                                MessageBox.Show("Milk amount can not be negative. Check the value in access database file.");
                                Application.Exit();
                            }
                            bool isJersey = Convert.ToBoolean(reader[7].ToString());
                            Livestock p = new JerseyCow(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersey);
                            Variables.Animals.Add(id, p);
                        }
                    }
                connection.Close();
                connection.Open();                                                                             //opening connection
                OleDbCommand cmd = new OleDbCommand(q, connection);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())                                                                      //using query to read the Dog's table
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        double amtWater = Convert.ToDouble(reader[1].ToString());
                        double weight = Convert.ToDouble(reader[2].ToString());
                        int age = Convert.ToInt32(reader[3].ToString());
                        string color = reader[4].ToString();
                        double dailyCost = Convert.ToDouble(reader[5].ToString());
                        Livestock p = new Dog(id, amtWater, dailyCost, weight, age, color);
                        Variables.Animals.Add(id, p);                                                          //Adding the data to the dictionary.
                    }
                connection.Close();
                //----  Quering the access database to get the values from Prices table and assigning them to static variable in Price class -----------
                connection.Open();
                OleDbCommand cmd4 = new OleDbCommand(q4, connection);
                using (OleDbDataReader reader = cmd4.ExecuteReader())
                    while (reader.Read())                                                                       //retrieving data from the Prices table.
                    {
                        string rates = reader[0].ToString();
                        double amount = Convert.ToDouble(reader[1].ToString());
                        if(rates == "Goat milk price")                                                          //adding the amount to the static class (Prices) variables.
                        {
                            Prices.GoatMilkPrice = amount;
                        }
                        if(rates == "Sheep wool price")
                        {
                            Prices.SheepWoolPrice = amount;
                        }
                        if (rates == "Water price")
                        {
                            Prices.WaterPrice = amount;
                        }
                        if (rates == "Government tax per kg")
                        {
                            Prices.GovtTax = amount;
                        }
                        if (rates == "Jersy cow tax")
                        {
                            Prices.JerseyTax = amount;
                        }
                        if (rates == "Cow milk price")
                        {
                            Prices.CowMilkPrice = amount;
                        }
                    }
                connection.Close();                                                                             //Connection closed after each query 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);                                                                  //if there is any Exception error message, it will be displayed in the Message box. 
            }
        }
        //-----Method to retrive details of the particular animal using ID------------------
        public string SearchByID()
        {
            string str3 = " ";                                         
            try
            {
                int id = Convert.ToInt32(textBox3.Text);                                                      // asking user to enter an ID 
                foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)                               //Look for the matching ID in the dictionary
                {
                    if (Variables.Animals.ContainsKey(id))                                                    //condition to check if the dictionary contains that key
                    {
                        Livestock ani1 = Variables.Animals[id];                                               //storing the ID in a variable ani1
                        str3 = ani1.getString();
                    }
                    else
                    {
                        str3 = "No match found" + "\r\n" + "Please enter the ID again.";                      //condition to check and display the message if no matching key found
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter an ID");
            }
            return str3;
        }
        //-------Calculate total profitibility per day for all animals-----------------------------
        private double CalculateProfit()
        {
            double total = 0.0;
            foreach (KeyValuePair<int, Livestock> ele1 in Variables.Animals)
            {
                total += ele1.Value.getProfit();
            }
            return total;
        }
        //-------Method to return the total amount of Milk per day(for Goats and Cows)----------
        private double TotalMilkPerDay()
        {
            double totalMilk = 0.0;
            foreach (KeyValuePair<int, Livestock> ele1 in Variables.Animals)
            {
                totalMilk += ele1.Value.totalMilk();
            }
            return totalMilk;
        }
        //-------------------Calculate total tax per month----------------------
        private double TotalTaxMonth()                                                      
        {
            double TotalTax = 0.0;
            foreach(KeyValuePair<int, Livestock> ele1 in Variables.Animals)
            {
                TotalTax += ele1.Value.TotalTaxPerMonth();
            }
            return TotalTax;
        }
        //--------------------------------------------------------------------------
        private double totalDailyCost()                                                     // Method to calculate total daily cost for all animals
        {
            double totalCost = 0.0;
            foreach (KeyValuePair<int, Livestock> ele1 in Variables.Animals)
            {
                totalCost += ele1.Value.totalDailyCost();
            }
            return totalCost;
        }
        private double totalDogCost()                                                       //Method to calculate total daily cost for Dogs only
        {
            double DogCost = 0.0;
            foreach (KeyValuePair<int, Livestock> ele1 in Variables.Animals)
            {
                DogCost += ele1.Value.totalDogCost();
            }
            return DogCost;
        }
        private double DogVsTotalRatio()                                                    //Method to find the ratio between Total daily cost and Dog's daily cost
        {
            double ratio = 0.0;
            ratio =  totalDogCost() / totalDailyCost() * 100;
            return ratio;
        }
        //----------------Average age of animals-------------------------
        private double AverageAge()
        {
            double avg = 0.0;
            foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                avg += ele.Value.AverageAgeOfAnimals() / (Variables.Animals.Count - 3);
            }
            return avg;
        }
        //------Average profit (goat and cows VS Sheeps)-------------------------
        private double AvgProfitVS()
        {
            double avgProf1 = 0.0;
            foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                avgProf1 += ele.Value.AverageProfit();
            }
            return avgProf1;
        }
        private double AvgProfitSheep()
        {
            double avgProf2 = 0.0;
            foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                avgProf2 += ele.Value.AverageProfitSheep();
            }
            return avgProf2;
        }
        //----- Total tax paid for Jersey Cows Per Month-----------------
        private double TotalJerseyTaxPerMonth()
        {
            double TotalJerseyTax = 0.0;
            foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                TotalJerseyTax += ele.Value.TotalTaxJerseyPerMonth();
            }
            return TotalJerseyTax;
        }
        //-------Calculating Total profit for Jersey cows per month-----------------
        private double TotalJerseyProfit()
        {
            double TotalJerseyProfit = 0.0;
            foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                TotalJerseyProfit += ele.Value.TotalJerseyProfitPerMonth();
            }
            return TotalJerseyProfit;
        }
        //-------Calculating Ratio of Red Animal's------------------
        private double RatioRed()
        {
            double count = 0;
            foreach(KeyValuePair<int, Livestock> ele in Variables.Animals)
            {
                if (ele.Value.ColourRatio() == "Red")
                {
                    count++;
                }
            }
            double ratio = count / Variables.Animals.Count * 100;
            return ratio;
        }
        //-------- Calculating the ratio of number of Animals above the threshold age ----------
        private double AgeThreshold()
        {
            double num = 0.0;
            try
            {
                int age = Convert.ToInt32(textBox13.Text);
                foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
                {
                    if (ele.Value.RatioAge() > age)
                    {
                        num++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter threshold age");
            }
            double ratioOfAnimal = (num / Variables.Animals.Count) * 100.0;
            return ratioOfAnimal;
        }
        //----------------Method to write Id's to a file -----------------------------------------------------------------------------------------
        private void WriteToFile()
        {
            string writeID = " ";
            double total = 0.0;
                using (StreamWriter writer = new StreamWriter(@"C:\Users\jassd\Desktop\Semester 4\App Deve\UNSortedID.txt"))
            {
                foreach (KeyValuePair<int, Livestock> ele in Variables.Animals)
                {
                    total = ele.Value.getProfitForEachAnimal();
                    writeID = ele.Value.getID();
                    writer.WriteLine(writeID +","+ total.ToString("0"));
                }   
            }
        }
        //--- Bubble sort to sort the profit into decending order----------------
        static void bubbleSrt(int[] array)
        {
            int num = array.Length;
            for (int i = 0; i < num - 1; i++)
                for (int j = 0; j < num - i - 1; j++)
                    if (array[j] < array[j + 1])
                    {
                        int tmp = array[j];                     // swap tmp and arr[i]
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
        }
        //------------ Printing the sorted array into the file-------------------
        static void printIt(int[] array)
        {
            string writeID = " ";
            int n = array.Length;
            
                using (StreamWriter writer = new StreamWriter(@"C:\Users\jassd\Desktop\Semester 4\App Deve\SortedID.txt"))
                {
                for (int i = 0; i < n; i++)
                     writer.WriteLine(array[i] + " "+ writeID);
                }
        }

        //-------calling method to search details by ID ----------------
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Connection Status: Successfully";
            string a = SearchByID();
            textBox1.Text = " " + a;
        }
        //---Added checkConn method to the Main method-------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            checkConn();
            WriteToFile();
            //----Creating list and sorting the array in decending order-----------------------------
            var list = new List<int>();
            string filepath = @"C:\Users\jassd\Desktop\Semester 4\App Deve\UNSortedID.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                int profit = int.Parse(entries[1]);
                list.Add(profit);
            }
            int[] array = list.ToArray();
            //------------------------------------------
            bubbleSrt(array);
            printIt(array);
        }
        //-----------------------------------------------All Buttons below to call methods-------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            double a = CalculateProfit();                                           //calling method in the button to display answers.
            textBox4.Text = "$"+ "" + a.ToString("0.00"); 
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        //----Calculating the total milk for Goats and cows per day----------
        private void button3_Click(object sender, EventArgs e)
        {
            double a = TotalMilkPerDay();
            textBox2.Text = " " + a.ToString("0.00") + " Liters";
        }
        //--Calculating the ratio of Dogs cost VS Total cost----------------
        private void button4_Click(object sender, EventArgs e)
        {
            double a = DogVsTotalRatio();
            textBox5.Text = " " + a.ToString("0.00") + " % ";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            double a = TotalTaxMonth();
            textBox6.Text = "$" + "" + a.ToString("0.00");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            double a = AverageAge();
            textBox7.Text = " " + a.ToString("0") + " years";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            double a = AvgProfitVS();
            textBox8.Text = "$" + a.ToString("0.00");
            double b = AvgProfitSheep();
            textBox9.Text = "$" + b.ToString("0.00");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double b = TotalJerseyTaxPerMonth();
            textBox10.Text = "$" + b.ToString("0.00");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double b = TotalJerseyProfit();
            textBox11.Text = "$" + b.ToString("0.00");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double b = RatioRed();
            textBox12.Text = b.ToString("0.00") + " %";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double b = AgeThreshold();
            textBox14.Text = b.ToString("0.00") + " %";
        }
    }
}


