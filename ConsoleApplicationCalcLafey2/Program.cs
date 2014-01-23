/*
 * Programming Excersises, #1
 * Calculator Project 
 * IST 240
 * Author: Daniel Lafey
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplicationCalcLafey2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Calculator operations supported +,-,/,*,%,<,>,^");
            
            //While loop will keep reading input
            while(true)
            {
                String input = Console.ReadLine(); //Asks user for equation
                
                //We only want the operators, spaces, and numbers in the format 1+2, 11+22, etc.
                while (!Regex.IsMatch(input, "^[0-9]+[/*%+-<>^]{1}[0-9]+$"))
                {
                    //If the input contains any  invalid characters now with the regex
                    Console.WriteLine("Invalid Please Re-Enter");
                    input = Console.ReadLine();
                }

                Console.WriteLine(p.calculate(input));
            }
        }

        private String calculate(String input){
            int left; //Left Operand
            int right; //Right Operand
            char operation; // Operational character +-/*^%<>
            int fn = findFirstNonDigit(input); // find the operator location
            if (fn < 0)
                return "Could not parse command";
            operation = input[fn]; //Assigns the operator character

            try
            {
                //Seperate out the operands
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
                if (operation == '+')
                    return Convert.ToString(left + right); // Addition
                else if (operation == '-')
                    return Convert.ToString(left - right); // Subtraction
                else if (operation == '*')
                    return Convert.ToString(left * right); // Multiplication 
                else if (operation == '/')
                    return Convert.ToString(left / right); // Division
                else if (operation == '%')
                    return Convert.ToString(left % right); // Modulo
                else if (operation == '^')
                    return Convert.ToString(Math.Pow(left, right)); // Power
                else if (operation == '<')
                    return Convert.ToString((left < right) ? left : right); // Less Than
                else if (operation == '>')
                    return Convert.ToString((left > right) ? left : right); // Greater Than
                else
                    return "Operation Not Found!";
            }
            catch
            {
                return "Could not pars command.";
            }
  

        }
        private int findFirstNonDigit(String s){
            //for loops through the input string of chracters

            for (int i = 0; i < s.Length; i++)
            {
                if(!(Char.IsDigit(s[i]))) return i;
            }
            return -1; //return a neg 1 of none found
        }
    }
}
