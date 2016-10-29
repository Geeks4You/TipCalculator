// Week 1: Individual: Tip Calculator
// Marcia L. Allen
// October 31, 2016
// Write an application that is used to determine the tip amount that should 
// be added to a restaurant charge. This program may be a console application 
// or a Windows Forms application. No matter whether you choose to develop a 
// Windows Forms application or a console application, be sure the interface 
// is professional looking and intuitive to use for the novice end user. Allow 
// the user to input the total, before taxes and the tip percentage (15% or 20%).
// Produce output showing the calculated values including the total amount due 
// for both the 15% and the 20% tips. Write appropriate methods for your solution,
// meaning develop your own void or value-returning methods in some way. Include 
// identifying information in the form of block comments at the top of each class 
// in the project (programmer name, date, program description). Include adequate
// comments throughout the program, utilize meaningful names for controls, 
// variables, fields, and forms. Include white space for readability purposes 
// in the code.

using System;

namespace TipCalculator
{
    class TipCalculatorProgram
    {
        static void Main ()
        {

            // Variable Declarations

            const double tipPercent1 = 0.10;
            const double tipPercent2 = 0.15;
            const double tipPercent3 = 0.20;

            var tipPercent = 0.0;       // Tip Percentage Amount
            var stotal = 0.0;           // Dollar Amount of Bill before taxes
            var input = true;           // Input for the loop condition
            double total;               // Total Amount to Pay, including Tip
            double tip;                 // Tip Amount

            // Prompt for Dollar Amount for Bill before tax
            Console.Write ( "\nPlease Enter Total Bill Amount, before tax : " );

            // Loop to look for a valid numeric input
            while (input)
            {
                // Check if user input is numeric
                if (Double.TryParse ( Console.ReadLine (), out stotal ))
                {

                    // Check if user entered a positive number, not equal to zero
                    if (stotal > 0.0)
                    {

                        // User entered a valid bill amount.
                        input = false;

                    }
                    else    // User input is a zero or negative number
                    {
                        // Display Error Message
                        Console.WriteLine ( "\nSorry there was an input error. Please enter a positive or non-zero amount." );

                        // Start Program over by Requesting Corrected User Input
                        Console.Write ( "\nPlease Enter Total Bill Amount, before tax : " );
                    }
                }
                else    // User input is non-numeric
                {
                    // Display Error Message
                    Console.WriteLine ( "\nSorry, you have entered a non-numeric value. Please try again." );

                    // Start Program over by Requesting Corrected User Input
                    Console.Write ( "\nPlease Enter Total Bill Amount, before tax : " );
                }

            }

            // Call Tip Options Menu
            tipPercent = getTipOptionMenu (tipPercent1, tipPercent2, tipPercent3 );


            // Calculate the tip amount
            tip = stotal * tipPercent;

            // Calculate the total amount plus tip to pay
            total = stotal + tip;

            Console.WriteLine ( "\nBill Amount : {0:C2} + \nCalculated Tip : {1:C2} = \nTotal Amount Due, including Tip : {2:C2}", stotal, tip, total );
            Console.ReadKey ();
        }

        /// <summary>
        /// Method that Displays a Tip Option Menu, showing three options specified as arguments
        /// </summary>
        /// <param name="PercentOpt1">First Tip Percentage Option</param>
        /// <param name="PercentOpt2">Second Tip Percentage Option</param>
        /// <param name="PercentOpt3">Third Tip Percentage Option</param>

        static void displayTipMenu (double PercentOpt1, double PercentOpt2, double PercentOpt3)
        {
            // Create the Menu using parameters
            Console.WriteLine ( "\nPlease select a tip percentage for this bill.\n" );
            Console.WriteLine ( "\t1.\t{0:P0}", PercentOpt1 );
            Console.WriteLine ( "\t2.\t{0:P0}", PercentOpt2 );
            Console.WriteLine ( "\t3.\t{0:P0}", PercentOpt3 );
            Console.WriteLine ( "\n; " );
        }

        /// <summary>
        /// Method prompts User for a tip percentage to apply toward bill total
        /// It is based on three options specified as an argument
        /// </summary>
        /// <param name="PercentOpt1">First Tip Percentage Option</param>
        /// <param name="PercentOpt2">Second Tip Percentage Option</param>
        /// <param name="PercentOpt3">Third Tip Percentage Option</param>
        /// <returns>Tip Percentage Rate Selected</returns>
        static double getTipOptionMenu(double PercentOpt1, double PercentOpt2, double PercentOpt3)
        {
            // Variable Declarations

            string option;           // String to hold the User selection
            var percent = 0.0;       // Tip Percentage

            // Call Function to Display Tip Menu
            displayTipMenu ( PercentOpt1, PercentOpt2, PercentOpt3 );


            // Get User Input
            option = Console.ReadLine ();

            // Determine Tip Percentage Rate based on Menu Opton selected
            switch (option)
            {
                case "1":
                    percent = PercentOpt1;
                    break;
                case "2":
                    percent = PercentOpt2;
                    break;
                case "3":
                    percent = PercentOpt3;
                    break;
                default:
                    // Display Error Message
                    Console.WriteLine ( "\nSorry there was an input error. Please select options 1, 2 or 3." );

                    // Call Method again using recursion. (More effective than a loop)
                    percent = getTipOptionMenu ( PercentOpt1, PercentOpt2, PercentOpt3 );
                    break;
            }

            return percent;
        }

    }

}
