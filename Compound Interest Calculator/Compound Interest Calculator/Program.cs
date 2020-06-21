using System;
using System.Linq;
using System.Globalization;
using System.Threading;


namespace Compound_Interest_Calculator
{
    class Program
    {
        /*
         * This programme creates a console app to calculate the compound interest of your bank balance given the interest value.  
         */
        static void Main(string[] args)
        {
            //Global variables
            bool userError = false; //for error handling when inputs occur
            double balance = 0; //setting up to be used in the conversion
            double interest = 0; //setting up to be used in the conversion
            int years = 0;
            
            //Get the balance of account from the user
            Console.WriteLine("Enter your current balance (do not use £ or $ symbol): ");
            string strBalance = Console.ReadLine();

           
           try 
           {
                balance = double.Parse(strBalance, NumberStyles.AllowDecimalPoint); //convert the inputted string into a double to be used in the calculation
           }
           catch (FormatException)
           {
                //do not use the data if you cannot convert it
                Console.WriteLine("Unable to convert '{0}' to a Double.", strBalance);
                userError = true;   
           }
           catch
           {
                //if input falls outside the range -1.7*10^308 & 1.7*10^308 
                Console.WriteLine("'{0}' is outside the range of a Double.", strBalance);
                userError = true;
           }
            /* Tests for data handling
            double.Parse(balance2); thought this would parse the string as a double but it does not
            Console.WriteLine(balance2.GetType());
            Console.WriteLine(result.GetType());
            Console.WriteLine("The value should be: '{0}'", balance2);
            Console.WriteLine("The value is: '{0}'", result);   
            bool allStringIsDigits = strBalance.All(char.IsNumber);//returns true if the string only contains digits
            System.Type type = typeof(double);//checking if double is the type in question*/


            //Getting the input for interest rate (in percentage)
            string strInterest = "";
            if (userError == false) //if no error so far continue the programme
            {
                //Get the interest rate value from the user
                
                Console.WriteLine("Enter your interest rate (do not use % symbol): ");

                strInterest = Console.ReadLine();
            }


            /* This was used to check if the string contains all numbers but deprecated since need to allow for use of . in string for interest rates to be accurate - example 1.5 needs to be handled correctly
                bool allStringIsDigits2 = strInterest.All(char.IsNumber);

             if (allStringIsDigits2)
            {
           CultureInfo.InvariantCulture - for localisation if needed
           Convert.ToDouble(strInterest); deprecated to allow for double.Parse & inclusion of decimal point handling
           */

            //Checking what was put into the first string and if the answer is a number then convert to double ready to be used by the calculator------------------------------------

            try
            {
                    
                    interest = double.Parse(strInterest, NumberStyles.AllowDecimalPoint);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to convert '{0}' to a Double.", strInterest);
                    userError = true;
                }
                catch
                {
                    Console.WriteLine("'{0}' is outside the range of a Double.", strInterest);
                    userError = true;
                }

            interest = interest / 100; //scaling the percent to normal values
           ;
            Console.WriteLine("Enter the years you want to calculate for: ");
            string strYears = Console.ReadLine();


            try
            {
                years = int.Parse(strYears); //convert the inputted string into an int to be used in the calculation
            }
            catch (FormatException)
            {
                //do not use the data if you cannot convert it
                Console.WriteLine("Unable to convert '{0}' to a int.", strYears);
                userError = true;
            }
            catch
            {
                //if input falls outside the range 
                Console.WriteLine("'{0}' is outside the range of a int.", strYears);
                userError = true;
            }
            //variable creation - just for example purposes
            //double interest = 0.1; //10% 
            //double balance = 1000; //£1000
            if (userError)
            {
                return;
            }
            else
            {
                for (double i = 1; i <= years; i++)
                {
                    double futureValue = balance * Math.Pow((1 + interest), i);

                 
                    /*
                     * Take the original value then multiply by the interest rate, ensuring the interest is at the correct iteration for the year using the pow func
                     */
                    
                    Console.WriteLine("Total value in account for {0} year(s) is: £{1}", i, Math.Round(futureValue, 2)); //cast to float to make a little bit easier to read 
                                                                                                                         //the {0} is what inserts the object after the string into the printed string in console.
                    Thread.Sleep(1000);
                }
                Console.WriteLine("\n**********\n\nThank you for using the calculator\n\n**********\n");
            }
           
        }
    }
}
