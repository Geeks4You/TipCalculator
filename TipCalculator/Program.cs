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

            // Variables Initialized

            var tipPercent = 0.0;    // Tip Percentage Amount
            var stotal = 0.0;        // Bill Amount, before taxes
            var total = 0.0;         // Total Amount to Pay, including Tip
            var tip = 0.0;           // Tip Amount

            // Welcome Message
            Console.WriteLine("\n\t\tWELCOME TO TIP CALCULATOR!");
            Console.WriteLine("\n\t*****************************************************");

            // Prompt for Bill Amount, before tax
            Console.Write ("\n\tPlease Enter your Bill Amount, before tax: ");

            // Call Method for Bill Amount, before taxes
            stotal = getBillstotal ();

            // Call Method to Display Menu with Tip Options
            tipPercent = getTipOptMenu ();

            // Call Method to Calculate the Tip Amount and Total Amount to Pay, including Tip
            calcAmtPay (stotal, tipPercent, out tip, out total);

            // Display the Required Resulting Values
            Console.WriteLine("\n\tBILL AMOUNT, TIP AMOUNT, TOTAL TO PAY VALUES");
            Console.WriteLine("\n\t*****************************************************");
            Console.WriteLine ("\n\tBill Amount, before taxes: \t\t{0:C2} \n\tCalculated Tip, based on option: \t{1:C2} \n\tTotal Amount to Pay, including Tip: \t{2:C2}", stotal, tip, total);
            Console.WriteLine("\n\t*****************************************************");
            Console.WriteLine("\n\tThank you for using Tip Calculator!");
            Console.ReadKey ();
        }

        /// <summary>
        /// Method requests a positive, non-zero numeric Bill Amount, before taxes
        /// </summary>
        /// <returns>Valid Bill Amount used in calculation</returns>

        static double getBillstotal()
        {
            // Variable for Bill Amount, before taxes
            var stotal = 0.0;

            // Validate input is numeric
            if (Double.TryParse (Console.ReadLine (), out stotal))
            {

                // Validate input is a positive number less than or equal to zero
                if (stotal <= 0.0)
                {
                    // Error Message
                    Console.WriteLine ("\n\tSorry, you enter a zero or a negative number. Please try again.");

                    // Prompt for Bill Amount, before tax, again
                    Console.Write("\n\tPlease Enter your Total Bill Amount, before tax: ");

                    // Call Method again
                    stotal = getBillstotal ();
                }
            }
            else    // Validate input is non-numeric
            {
                // Error Message
                Console.WriteLine ("\n\tSorry, you entered a non-numeric value. Please try again.");

                // Prompt for Bill Amount, before tax, again
                Console.Write("\n\tPlease Enter your Total Bill Amount, before tax: ");

                // Call Method again
                stotal = getBillstotal ();
            }

            return stotal;
        }

        /// <summary>
        /// Method that Displays a Tip Option Menu
        /// </summary>
        /// <param name="PercentOpt1">Tip Percentage Option #1</param>
        /// <param name="PercentOpt2">Tip Percentage Option #2</param>

        static void displayTipMenu (double Opt1, double Opt2)
        {
            // Method creates a Menu using parameters
            Console.WriteLine("\n\tTIP PERCENTAGE OPTION MENU");
            Console.WriteLine("\n\t*****************************************************");
            Console.WriteLine("\n\tPlease select a tip option for this bill. \n");
            Console.WriteLine("\t1.\t{0:P0}", Opt1);
            Console.WriteLine("\t2.\t{0:P0}", Opt2);
            Console.WriteLine("\n\t*****************************************************\n");
            Console.Write("\n\t: ");
        }

        /// <summary>
        /// Method prompts for a tip option that will be applied against the bill amount
        /// </summary>
        /// <param name="PercentOpt1">Percentage Option #1</param>
        /// <param name="PercentOpt2">Percentage Option #2</param>
        /// <returns>Percentage Option Selected</returns>

        static double getTipOptMenu(double Opt1 = 0.15, double Opt2 = 0.20)
        {
            // Variable Declarations

            string optionSel;        // String to hold Option selection
            var percent = 0.0;       // Percentage Amount based on option selected

            // Call Method to Display Tip Option Menu
            displayTipMenu (Opt1, Opt2);

            // Get User Input
            optionSel = Console.ReadLine ();

            // Determine Tip Percentage Amount based on the Menu Option selected
            switch (optionSel)
            {
                case "1":
                    percent = Opt1;
                    break;
                case "2":
                    percent = Opt2;
                    break;
                default:
                    // Error Message
                    Console.WriteLine ("\n\tSorry, there was an input error. Please select options 1 or 2.");

                    // Call Method again
                    percent = getTipOptMenu (Opt1, Opt2);
                    break;
            }

            return percent;
        }

        /// <summary>
        /// Method Calculates the Tip Amount and Total Amount to Pay, including Tip
        /// </summary>
        /// <param name="stotal">Bill Amount, before taxes</param>
        /// <param name="tipPercent">Tip Percentage Amount Selected</param>
        /// <param name="tip">Tip Amount</param>
        /// <param name="total">Total Amount to Pay, including Tip</param>

        static void calcAmtPay(double stotal, double tipPercent, out double tip, out double total)
        {
            // Calculate the Tip Amount
            tip = stotal * tipPercent;

            // Calculate the Total Amount to Pay, including Tip
            total = stotal + tip;
        }

    }

}
