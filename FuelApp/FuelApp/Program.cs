using System;
using static System.Console;

namespace FuelApp
{
    class FuelCost
    {
        static void Main()
        {
            //Set up input for fuel type
            string type;
            Write("Enter fuel type>>> ");
            type = ReadLine();
            InputFuelType(ref type); 

            //Set up input for litres & cost of fuel
            double litres; double cost;
            InputLitresAndCost(out litres, out cost);

            //Set up for Method to display all information
            DisplayInformation(litres, type, cost);
            
        }

        //Method to display all information
        public static void DisplayInformation(double displayLitres, string displayType, double displayCost)
        {
            WriteLine("\nThe number of litres of fuel: {0}", displayLitres.ToString("F2"));
            WriteLine("Fuel type: {0}", displayType);
            WriteLine("Cost of fuel: {0}", displayCost.ToString("C"));
            WriteLine("Total cost of fuel: {0} ", DisplayTotalCost(displayLitres, displayCost).ToString("C")); 
        }

        //Check if fuel type input is valid
        public static bool IsValid(string id)
        {

            //check valid fuel type for all 3 criteria
            int lastTwoDigits;

            if ((id.Length == 3) && (id[0] >= 65 && id[0] <= 90) && (int.TryParse(id.Substring(1, 2), out lastTwoDigits)))
            {
                //check last 2 digits are digits  
                return lastTwoDigits >= 0; 
            } else
            {
                return false; 
            }

        }
        //Input fuel type
        public static string InputFuelType(ref string fuelType)
        {
            {
                while (IsValid(fuelType) != true)
                {
                    Write("Invalid entry. Please re-enter a valid fuel type>>> ");
                    fuelType = ReadLine();
                }
            }
            return fuelType; 
        }

        //Input litres & cost of fuel
        public static void InputLitresAndCost(out double inputLitres, out double inputCost)
        {
            const double POSITIVE = 0.00;

            Write("Enter number of litres of fuel filled>>> ");

            inputLitres = Convert.ToDouble(ReadLine());
            while (!(inputLitres >= POSITIVE))
            {
                Write("Invalid input. Please re-enter a positive numeric value for litres of fuel filled >>> ");
                inputLitres = Convert.ToDouble(ReadLine());
            }

            Write("Enter cost of fuel in dollars and cents filled>>> ");
            inputCost = Convert.ToDouble(ReadLine());
            while (!(inputCost >= POSITIVE))
            {
                Write("Invalid input. Please re-enter a positive numeric value for cost of fuel in dollars and cents >>> ");
                inputCost = Convert.ToDouble(ReadLine());
            }

        }

        //Calculate total cost of fuel
        public static double DisplayTotalCost(double calLitres, double calCost) 
        {
            double totalCost;
            totalCost = calLitres * calCost;
            return totalCost; 
        }

    }
}
