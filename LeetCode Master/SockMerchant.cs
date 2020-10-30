// https://www.hackerrank.com/challenges/sock-merchant/

using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

class SockMerchant
{
    // Task: Find matching pairs in an array. (Can't reuse items that are already paired)

    // My answer - O(n^2)
    static int sockMerchant(int n, int[] ar)
    {
        int pairCounter = 0;
        int[] indexOfDuplicateCounter = new int[n / 2];
        bool noDuplicates = true;

        for (int i = 0; i < n; i++)
        {
            noDuplicates = true;

            if (!indexOfDuplicateCounter.Contains(i) || i == 0)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (noDuplicates && ar[i] == ar[j])
                    {
                        indexOfDuplicateCounter[pairCounter] = j;
                        pairCounter++;
                        noDuplicates = false;
                    }
                }
            }
        }
        return pairCounter;
    }

    // lukes712 answer - O(n) - Most efficient answer.
    static int sockMerchant2(int n, int[] ar)
    {
        HashSet<int> colors = new HashSet<int>();
        int pairs = 0;

        for (int i = 0; i < n; i++)
        {
            if (!colors.Contains(ar[i]))
            {
                colors.Add(ar[i]);
            }
            else
            {
                pairs++;
                colors.Remove(ar[i]);
            }
        }
        return pairs;
    }

    // tusha2693 answer - O(n^2) - My favorite solution because of the logic. They change the value of the paired item to 0 and then uses an if statement to pass it so it doesn't get paired up again.
    static int sockMerchant3(int n, int[] ar)
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (ar[i] != 0)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (ar[i] == ar[j])
                    {
                        count++;
                        ar[j] = 0;
                        break;
                    }
                }
            }
        }
        return count;
    }
}