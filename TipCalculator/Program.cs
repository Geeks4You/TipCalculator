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
            var percent = 0.0;      // Tip Percentage Amount
            var total = 0.0;        // Bill Amount, before taxes
            var pay = 0.0;          // Total Amount to Pay, including Tip
            var tip = 0.0;          // Tip Amount

            // Welcome Message
            Console.WriteLine("\n\t\t\tWELCOME TO TIP CALCULATOR!");
            Console.WriteLine("\n\t****************************************************************");

            // Prompt for Bill Amount, before tax
            Console.Write ("\n\tPlease Enter the Bill Amount, before tax: ");

            // Call Method to capture the Bill Amount, before taxes and validate input value
            total = billAmt ();

            // Call Method to display Menu with Tip Options and capture selection
            percent = optMenu ();

            // Call Method to Calculate the Tip Amount and Total Amount to Pay, including Tip
            amtPay (total, percent, out tip, out pay);

            // Display the Required Resulting Values
            Console.WriteLine("\n\tBILL AMOUNT, TIP AMOUNT, TOTAL TO PAY VALUES");
            Console.WriteLine("\n\t****************************************************************");
            Console.WriteLine ("\n\tBill Amount, before taxes: \t\t\t{0:C2} \n\tCalculated Tip, based on option: \t\t{1:C2} \n\tCalculated Amount to Pay, including Tip: \t{2:C2}", total, tip, pay);
            Console.WriteLine("\n\t****************************************************************");

            // Display Thank you Message
            Console.WriteLine("\n\tThank you for using Tip Calculator!");

            Console.ReadKey ();
        }

        // Method captures the Bill Amount, before taxes and validates proper input
        static double billAmt()
        {
            // Variable for Bill Amount, before taxes
            var total = 0.0;

            // Validate input is numeric
            if (Double.TryParse (Console.ReadLine (), out total))
            {

                // Validate input is a positive number
                if (total <= 0.0)
                {
                    // Error Message if input is zero or a negative number
                    Console.WriteLine ("\n\tSorry, you enter a number zero or less. Please try again.");

                    // Prompt for Bill Amount, before tax, again
                    Console.Write("\n\tPlease Enter the Total Bill Amount, before tax: ");

                    // Call Method again
                    total = billAmt ();
                }
            }
            else    // Validate input is numeric
            {
                // Error Message if input is not numeric
                Console.WriteLine ("\n\tSorry, you entered a non-numeric value. Please try again.");

                // Prompt for Bill Amount, before tax, again
                Console.Write("\n\tPlease Enter the Total Bill Amount, before tax: ");

                // Call Method again
                total = billAmt ();
            }

            return total;
        }

        /// <summary>
        /// Method displays Tip Option Menu and captures the Tip Option and Percentage 
        /// selection used to calculate Total Amount to Pay
        /// </summary>
        /// <returns>Selected Percentage used in Calculation</returns>

        static double optMenu()
        {
            // Variables Initialized
            double Opt1 = 0.15;   // Option 1 Percentage Amount
            double Opt2 = 0.20;   // Option 2 Percentage Amount
            string OptSel;        // String to hold Option selection
            var percent = 0.0;    // Percentage Amount based on option selected

            // Display Tip Option Menu
            Console.WriteLine("\n\tTIP OPTION MENU");
            Console.WriteLine("\n\t****************************************************************");
            Console.WriteLine("\n\tPlease select a tip amount to include with this bill. \n");
            Console.WriteLine("\t1.\t{0:P0}", Opt1);
            Console.WriteLine("\t2.\t{0:P0}", Opt2);
            Console.WriteLine("\n\t****************************************************************");
            Console.Write("\n\t: ");

            // Get Option Selected
            OptSel = Console.ReadLine ();

            // Determine Tip Percentage Amount based on the Menu Option selected
            switch (OptSel)
            {
                case "1":
                    percent = Opt1;
                    break;
                case "2":
                    percent = Opt2;
                    break;
                default:
                    // Error Message
                    Console.WriteLine ("\n\tSorry, your menu selection is invalid. Please try again.");

                    // Call Method again
                    percent = optMenu ();
                    break;
            }

            return percent;
        }

        /// <summary>
        /// Method Calculates the Tip Amount and Total Amount to Pay, including Tip
        /// </summary>
        /// <param name="total">Bill Amount, before taxes</param>
        /// <param name="tipPercent">Tip Percentage Amount</param>
        /// <param name="tip">Calculated Tip Amount</param>
        /// <param name="aPay">Calculated Total Amount to Pay, including Tip</param>

        static void amtPay(double total, double percent, out double tip, out double pay)
        {
            // Calculate the Tip Amount
            tip = total * percent;

            // Calculate the Total Amount to Pay, including Tip
            pay = total + tip;
        }

    }

}
