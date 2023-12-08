using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Shared.Extensions
{
    public static class CommonHelpers
    {
        public static ulong FindLCM(List<int> numbers)
        {
            List<int> primes = FindPrimeInRage(numbers.Max());

            Dictionary<int, Dictionary<int, int>> numberWithDivisors = new Dictionary<int, Dictionary<int, int>>();
            foreach (int number in numbers)
            {
                Dictionary<int, int> divisors = new Dictionary<int, int>();
                int currentValue = number;
                while (currentValue != 1)
                {
                    foreach (var prime in primes)
                    {
                        if (currentValue % prime == 0)
                        {
                            if (divisors.ContainsKey(prime))
                            {
                                divisors[prime]++;
                            }
                            else
                            {
                                divisors.Add(prime, 1);
                            }
                            currentValue = currentValue / prime;
                            break;
                        }
                    }
                }
                numberWithDivisors.Add(number, divisors);
            }

            Dictionary<int, int> divisorsCount = new Dictionary<int, int>();

            foreach (var number in numberWithDivisors)
            {
                foreach (var divisor in number.Value)
                {
                    if (divisorsCount.ContainsKey(divisor.Key))
                    {
                        if (divisorsCount[divisor.Key] < divisor.Value)
                        {
                            divisorsCount[divisor.Key] = divisor.Value;
                        }
                    }
                    else
                    {
                        divisorsCount.Add(divisor.Key, divisor.Value);
                    }
                }
            }
            return (ulong)divisorsCount.Aggregate(1.0, (x, y) => x *= Math.Pow(y.Key, y.Value));
        }

        private static List<int> FindPrimeInRage(int limit)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                bool isPrime = true;
                foreach (var previousPrime in primes)
                {
                    if (i % previousPrime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
