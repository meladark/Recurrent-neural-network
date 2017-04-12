using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class Program
    {
        static int fnet(int[,]w, int[] y,int k, int K)
        {
            int net = 0;

            for(int j = 0; j < K; j++)
            {
                if (j == k)
                {
                    continue;
                }
                else
                {
                    net += w[j, k] * y[j];
                }
            }
            if (net > 0)
            {
                return 1;
            }
            else
            {
                if (net < 0)
                {
                    return -1;
                }
                else
                {
                    return y[k];
                }
            }
        }
        static int[,] wMas(int[,] W, int K, int[] x)
        {
            for(int k = 0; k < K; k++)
            {
               for(int j = 0; j < K; j++)
                {
                    if (j==k)
                    {
                        continue;
                    }
                    else
                    {
                        W[j, k] += x[j] * x[k];
                    }
                }
            }
            return W;
        }
        static void Main(string[] args)
        {
            int K = 15;
            int[] A = {1,1,1,1,1,1,-1,1,-1,-1,1,1,1,1,1};
            int[] I = {1,-1,-1,-1,1,1,1,1,1,1,1,-1,-1,-1, 1};
            int[] F = {1,1,1,1,1,1,-1,1,-1,-1,1,-1,-1,-1,-1};
            int[] Y = new int[K];
           for (int i = 0; i < K; i++)
            {
                Y[i] = A[i];
            }
            int[,] W = new int[K, K];
            W = wMas(W,K,A);
            W = wMas(W, K, I);
            W = wMas(W, K, F);
            for (int k = 0; k < K; k++)
            {
                for (int j = 0; j < K; j++)
                {
                    Console.Write(W[j,k]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
