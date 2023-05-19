using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PresentBaskets
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// fill the 2 baskets with the most expensive collection of fruits.
        /// </summary>
        /// <param name="W1">weight of 1st basket</param>
        /// <param name="W2">weight of 2nd basket</param>
        /// <param name="items">Pair of weight (Key) & cost (Value) of each item</param>
        /// <returns>max total cost to fill two baskets</returns>
        static public double PreparePresentBaskets(int W1, int W2, KeyValuePair<int, int>[] items)
        {
            int n = items.Length;
            int[] weight = new int[n];
            int[] cost = new int[n];
            double[] costPerWeight = new double[n];
            var c = new List<KeyValuePair<int, double>>();
            for (int j = 0; j < n; j++)
            {
                weight[j] = items[j].Key;
                cost[j] = items[j].Value;
                if (weight[j] == 0)
                {
                    continue;
                }
                costPerWeight[j] = (double)cost[j] / (double)weight[j];
                c.Add(new KeyValuePair<int, double>(weight[j], costPerWeight[j]));
            }
            c.Sort((x, y) => y.Value.CompareTo(x.Value));
            double totalcost = 0;
            double remainweight;
            double W = W1 + W2;
            for (int i = 0; i < c.Count; i++)
            {
                if (W > 0)
                {
                    if (c[i].Key <= W)
                    {
                        W = W - c[i].Key;
                        totalcost += (double)(c[i].Value * c[i].Key);
                    }
                    else
                    {
                        remainweight = W;
                        W = 0;
                        totalcost += c[i].Value * remainweight;

                    }
                }
                else
                {
                    break;
                }
            }
            return totalcost;
        }

        #endregion
    }
}
