using System.Numerics;
using System;

namespace hjvaLib
{
    public static class hjvaMath
    {
        /*********************************************************************************/
        public static int[] ProperDivisors(int inVal){
            List<int> divisors = new();

            for (int i=1; i < Math.Sqrt(inVal); i++){
                if (inVal % i == 0){
                    divisors.Add(i);

                    int div = inVal / i;
                    if ((div != inVal % i) && div != inVal){
                        divisors.Add(div);
                    }

                }
            }
            return divisors.OrderBy(x => x).ToArray();
        }
        /**************************************************************************************************
        * recursive Factorial (n * n - 1) 
        ***************************************************************************************************/
        public static BigInteger Factorial(BigInteger n)
        {
            if (n == 1)
                return 1;
            else
                return (n * Factorial(n - 1));
        }
        /*******************************************************************************************************/
        public static string MultiplyTwoStrings(string one, string two)
        {
            int iTopChar, iBotChar;
            int iCarry = 0;                     // if multiplication results is larger than 10
            int iMult;                          // multiply two characters
            string sRet = "0";                  // return value.
            List<string> lstLines = new();      // one for each power of 10
            string sLine = String.Empty;        // string representative of multipling 2 chars. 

            // Bottem line. For each bottom line char, run through all the char's in the top line
            for (int t = two.Length - 1; t >= 0; t--)
            {
                // convert char to integer
                iBotChar = two[t] - '0';
                sLine = String.Empty;
                iCarry = 0;
                // add leading zeros for each powers of 10
                for (int u = 0; u < two.Length - 1 - t; u++)
                {
                    sLine += "0";
                }
                for (int on = one.Length - 1; on >= 0; on--)
                {
                    // multiply two chars
                    iTopChar = one[on] - '0';
                    iMult = iBotChar * iTopChar + iCarry;
                    // put result remainder into line string
                    sLine = (iMult % 10).ToString() + sLine;
                    // put division value in iCarry
                    iCarry = iMult / 10;
                }

                // if last multiplaction of top and bottom digits is > 10
                if (iCarry > 0)
                {
                    sLine = iCarry.ToString() + sLine;
                }
                // each power of 10 of bottom line add them together
                lstLines.Add(sLine);
            }
            foreach (string l in lstLines)
            {
                sRet = AddTwoStrings(sRet, l);
            }
            return sRet;
        }

        /*******************************************************************************************************/
        public static string AddTwoStrings(string one, string two)
        {
            const int ZEROChar = 48;

            // trim out any extra spaces
            one.Trim();
            two.Trim();

            bool good = true;
            string sResult = String.Empty;

            // make sure all characters are between 0 - 9
            foreach (char c in one)
            {
                if (c < '0' || c > '9')
                {
                    good = false;
                    break;
                }
            }
            if (good)
            {
                foreach (char c in two)
                {
                    if (c < '0' || c > '9')
                    {
                        good = false;
                        break;
                    }
                }
            }
            if (good)
            {
                // make two strings equal lengths by adding '0' to beginning of string
                if (one.Length != two.Length)
                {
                    while (one.Length < two.Length)
                    {
                        one = '0' + one;
                    }
                    while (one.Length > two.Length)
                    {
                        two = '0' + two;
                    }
                }

                // Perform math one char at a time starting from the right
                int carry = 0;
                for (int i = one.Length - 1; i >= 0; i--)
                {
                    int first = one[i] - '0';
                    int second = two[i] - '0';
                    int iResult = carry + first + second;
                    if (iResult >= 10)
                    {
                        carry = 1;
                        iResult -= 10;
                    }
                    else
                    {
                        carry = 0;
                    }
                    char wth = (char)(iResult + ZEROChar);
                    sResult = wth + sResult;
                }
                if (carry != 0)
                {
                    sResult = "1" + sResult;
                }
            }
            return sResult;
        }
        /*******************************************************************************************************/
        public static bool[] SieveOfEratosthenes(int MaxValue)
        {
            bool[] primes = new bool[MaxValue + 1];

            // set all primes to true
            for (int i = 2; i < MaxValue; i++)
            {
                primes[i] = true;
            }

            // for each value up to sqrt of maxvalue
            for (int i = 0; i < Math.Sqrt(MaxValue); i++)
            {
                // if array value is true
                if (primes[i])
                {
                    // find start position for second loop
                    // all non prime values below i^2 will already be set to false.
                    long start = (long)Math.Pow(i, 2);

                    //From start incrementing by i, set primes to false
                    // i.e i=2, start = 4, set 4,6,8,10... to false
                    for (long j = start; j < MaxValue; j += i)
                    {
                        primes[j] = false;

                    }
                }
            }
            return primes;
        }
        /*******************************************************************************************************/
        public static bool isPalindrome(string s)
        {
            bool ret = true;        // Return value

            // walk string from position 0 to half way
            // compare first digit with last digit, then second digit with second to last digit...
            // If not the same return false
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1]) {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        /*******************************************************************************************************/
        public static bool isPrime(long n)
        {
            //get all factors for n
            long[] factors = primeFactors(n);

            // if only one factor, they return true, else false.
            return (factors.Length == 1);
        }
        /*******************************************************************************************************/
        public static long[] AllFactors(long n)
        {
            List<long> factors = new();
            long sq = (long)Math.Floor(Math.Sqrt(n));

            factors.Add(1); // one and input number are always factors
                            // from 2 to square root of input number
            for (int i = 2; i < sq; i++)
            {
                // check if interation (i) divides evenly into input number
                if (n % i == 0)
                {
                    factors.Add(i);
                    factors.Add(n / i);
                }
            }
            factors.Add(n);     // put input number in factors list

            return factors.ToArray();
        }

        /*******************************************************************************************************/
        public static long[] primeFactors(long n)
        {
            List<long> result = new();

            // Print the number of 2s that divide n 
            while (n % 2 == 0)
            {
                result.Add(2);
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    result.Add(i);
                    n /= i;
                }
            }

            // This condition is to handle the case when 
            // n is a prime number greater than 2 
            if (n > 2)
            {
                result.Add(n);
            }
            return result.ToArray();
        }
    }
}

