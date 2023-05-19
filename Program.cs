namespace KthSmallestPrimeFraction
{
    internal class Program
    {
        public class SmallestPrimeFraction
        {
            private class Fraction
            {
                public readonly int numerator;
                public readonly int denominator;
                public readonly double fraction;

                public Fraction(int numerator, int denominator, double fraction)
                {
                    this.numerator = numerator;
                    this.denominator = denominator;
                    this.fraction = fraction;
                }
            }

            private void Swap(List<Fraction> arr, int i, int j)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }

            private int[] GetKthSmallestPrimeFraction(List<Fraction> arr, int startIdx, int endIdx, int position)
            {
                while(true)
                {
                    if (startIdx > endIdx)
                    {
                        throw new ArgumentException("Algorithm shouldn't be here");
                    }
                    int pivotIdx = startIdx;
                    int leftIdx = startIdx + 1;
                    int rightIdx = endIdx;
                    while(leftIdx <= rightIdx)
                    {
                        if (arr[pivotIdx].fraction < arr[leftIdx].fraction && arr[rightIdx].fraction < arr[pivotIdx].fraction)
                        {
                            Swap(arr, leftIdx, rightIdx);
                            ++leftIdx;
                            --rightIdx;
                        }
                        if (arr[leftIdx].fraction <= arr[pivotIdx].fraction)
                        {
                            ++leftIdx;
                        }
                        if (arr[rightIdx].fraction > arr[pivotIdx].fraction)
                        {
                            --rightIdx;
                        }
                    }
                    Swap(arr, pivotIdx, rightIdx);
                    if (rightIdx == position)
                    {
                        return new int[] { arr[rightIdx].numerator, arr[rightIdx].denominator };
                    }
                    if (rightIdx > position)
                    {
                        endIdx = rightIdx - 1;
                    }
                    else
                    {
                        startIdx = rightIdx + 1;
                    }
                }
            }
            public int[] KthSmallestPrimeFraction(int[] arr, int k)
            {
                int n = arr.Length;
                List<Fraction> fractions = new List<Fraction>();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = i + 1; j < n; ++j)
                    {
                        fractions.Add(new Fraction(arr[i], arr[j], arr[i] / (arr[j] * 1.0)));
                    }
                }
                return GetKthSmallestPrimeFraction(fractions, 0, fractions.Count - 1, k - 1);
            }
        }

        static void Main(string[] args)
        {
            SmallestPrimeFraction smallestPrimeFraction = new SmallestPrimeFraction();
            int[] test1 = smallestPrimeFraction.KthSmallestPrimeFraction(new int[] { 1, 2, 3, 5 }, 3);
            int[] test2 = smallestPrimeFraction.KthSmallestPrimeFraction(new int[] { 1, 7 }, 1);
            Console.WriteLine(test1[0] + " " + test1[1]);
            Console.WriteLine(test2[0] + " " + test2[1]);
        }
    }
}