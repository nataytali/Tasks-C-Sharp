using System;
using System.Collections.Generic;
using System.Linq;

namespace IntToBinary
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 3, 7, 78, 3, 7, 7, 7, 78, 78 };
            int[] anotherNumbers = new int[] { 7, 345, 11 };
            int[] arr = new int[] { 8, 1, 2, 3, 4, 3, 2, 8, 1 };

            Console.WriteLine("5 in binary base - " + CountBits(5));

            DigitalRoot(345);

            Console.WriteLine("Is Machine isogram? - " + IsIsogram("Machine"));
            Console.WriteLine("Is Aba isogram? - " + IsIsogram("Aba"));

            Console.WriteLine(sumTwoSmallestNumbers(numbers));

            //var diff = ArrayDiff(numbers, anotherNumbers);
            //for (int i = 0; i < diff.Length; i++)
            //{
            //    Console.Write(diff[i] + "  ");
            //}

            Console.WriteLine(find_it(numbers));

            Console.WriteLine("4of Fo1r pe6ople g3ood th5e the2 => " + Order("4of Fo1r pe6ople g3ood th5e the2"));

            Console.WriteLine("Pins validation:");
            Console.WriteLine("123546 - " + ValidatePin("123546"));
            Console.WriteLine("0235 - " + ValidatePin("0235"));
            Console.WriteLine("12346 - " + ValidatePin("12346"));
            Console.WriteLine("12356s - " + ValidatePin("12356s"));

            Console.WriteLine(FindEvenIndex(arr));

            Console.ReadKey();
        }

        public static int CountBits(int n)
        {
            if (n >= 0)
            {
                string binary = Convert.ToString(n, 2);
                return Int32.Parse(binary);
            }

            return -1;
        }
        public static string DigitalRoot(long n)
        {
            string input = n.ToString();
            int sum;
            
            while (input.Length > 1)
            {
                sum = 0;
                Console.Write($"{input} -> ");

                foreach (char digit in input)
                {
                    if (digit == input[input.Length - 1]) 
                        Console.Write(digit + " = ");
                    else 
                        Console.Write(digit + " + ");                   
                    
                    sum += Int32.Parse(digit.ToString());
                }

                input = sum.ToString();
            }

            Console.Write($"{input}\n");

            return input;

        }
        public static string MorseDecode(string morseCode) // fail 
        {
            string decode = "";
            for(int i = 0; i < morseCode.Length; i++)
            {
                if(morseCode[i] == ' ')
                {
                    continue;
                }
                
            }
            return "";
        }
        public static bool IsIsogram(string str)
        {
            str = str.ToLower();
            int len = str.Length;

            char[] arr = str.ToCharArray();

            Array.Sort(arr);

            for (int i = 0; i < len - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    return false;
            }

            return true;
        }
        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            if(numbers.Length < 4)
            {
                Console.WriteLine("not enough numbers in array");
                return 0;
            }
            Array.Sort(numbers);

            return numbers[0] + numbers[1];
        }        
        public static int[] ArrayDiff(int[] a, int[] b) // fail
        {
            List<int> diff = new List<int>();

            a.Except(b);
            for (int i = 0; i < a.Length; i++)
            {
                if (!b.Contains(a[i]))
                {
                    diff.Add(a[i]);
                }
            }
            return diff.ToArray();
        }       
        public static int find_it(int[] seq) //return first number that occur in array odd times
        {
            int times;
            Array.Sort(seq);

            for (int i = 0; i < seq.Length; i++)
            {
                times = 0;
                for (int j = 0; j < seq.Length; j++)
                {
                   
                    if(seq[i] == seq[j]) {
                        times += 1;
                    }
                }
                if (times % 2 != 0)
                    return seq[i];
            }
            return -1;
        }
        public static string Order(string words)
        {
            string[] wordsArr = words.Split(" ");

            for(int i = 0; i < wordsArr.Length; i++)
            {
                for(int j = 0; j < wordsArr.Length; j++)
                {
                    if(wordsArr[j].Contains((i + 1).ToString())) {

                        string buff = wordsArr[j];
                        wordsArr[j] = wordsArr[i];
                        wordsArr[i] = buff;
                       
                    }
                }
            }

            return String.Join(" ", wordsArr);
        }
        public static bool ValidatePin(string pin)
        {
            int result;

            if((pin.Length == 4 || pin.Length == 6) && (Int32.TryParse(pin, out result)))
                return true;

            return false;
        }
        public static int FindEvenIndex(int[] arr)
        {
            int sumLeft = 0;
            int sumRight = arr.Sum() - arr[0];
            
            for (int i = 1; i < arr.Length - 1; i++)
            {
                sumLeft += arr[i - 1];
                sumRight -= arr[i];

                if (sumLeft == sumRight)
                    return i;

            }
            return -1;
        }

    }
}

