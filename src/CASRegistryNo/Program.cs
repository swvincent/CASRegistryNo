// Copyright 2018 Scott W. Vincent
// Shared under an MIT License - see LICENSE file for details

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CASRegistryNo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> casRegNos = new List<string>
            {
                "58-08-2",      // Valid # for caffeine
                "58-08-3",      // Invalid because check digit is wrong
                "5808-3"        // Invalid because format is wrong (missing dash)
            };

            foreach(var casRegNo in casRegNos)
            {
                var result = CasRegNo.Validate(casRegNo);

                if (result.isValid)
                    Console.WriteLine($"{casRegNo} is a valid CAS Registry Number.");
                else
                    Console.WriteLine($"{casRegNo} is not a valid CAS Registry Number because: {result.errorMessage}.");
            }

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}