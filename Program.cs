using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program displays letter counts of numbers between 1 to 1000");

            int letterCount = CalculateLetterCount(1,1000);

            Console.WriteLine("Letter count is {0}",letterCount);

            Console.ReadLine();
        }

        public static int CalculateLetterCount(int start, int end)
        {
            int letterCount = 0;

            // initialize array of base text representation of numbers
            string[] baseNumbers = new string[] { "one","two","three","four","five","six","seven","eight","nine","ten",
                                                  "eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen",
                                                  "eighteen","nineteen"  };
            string[] tensNumbers = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] specialNumbers = new string[] { "hundred","thousand"};
            StringBuilder str = new StringBuilder();
            for (int i=start; i<= end; i++)
            {
                int num = i;

                if (num < 20) // if number is less than 20 get text representation directly
                {
                    str.Append(baseNumbers[num - 1]);
                    letterCount += str.Length;
                    str.Clear();
                    
                }
                else if (num < 100)
                {
                    if (num % 10 == 0) // get text representation for 20,30 etc.
                        str.Append(tensNumbers[num / 10 - 2]);
                    else
                        str.Append(tensNumbers[num / 10 - 2] + baseNumbers[num % 10 - 1]);

                    letterCount += str.Length;
                    str.Clear();
                    
                }
                else // number is greater than or equal to 100
                {
                    if (num == 1000) // hard coded here to solve this exact problem for the sake brevity
                        str.Append(baseNumbers[0] + specialNumbers[1]);
                    else
                    {
                        int hundredsPlace = num / 100;
                        int tensPlace = (num % 100) / 10;
                        int unitsPlace = num % 10;
                        //number between 100 - 999
                        if (num % 100 == 0)
                            str.Append(baseNumbers[hundredsPlace - 1] + specialNumbers[0]);
                        else if(num % 100 < 20) // handle nos like 101,319,612 etc.
                            str.Append(baseNumbers[hundredsPlace - 1] + specialNumbers[0] + "and" + baseNumbers[num % 100 - 1]);
                        else if ((num % 100) % 10 == 0) // handle nos like 150,250
                            str.Append(baseNumbers[hundredsPlace - 1] + specialNumbers[0] + "and" + tensNumbers[tensPlace - 2]);
                        else
                            str.Append(baseNumbers[hundredsPlace - 1] + specialNumbers[0] + "and" + tensNumbers[tensPlace- 2] + baseNumbers[num % 10 - 1]);

                    }

                    letterCount += str.Length;
                    str.Clear();

                }
                
            }



            return letterCount;
        }
    }
}
