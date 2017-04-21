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
        static void exit (int K, int[] A, string h)
        {
            Console.Write("{0}    = ",h);
            int count = 0;
            for (int i = 0; i < K; i++)
            {
                if (count == K / 5)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.Write("       ");
                    count = 0;
                }
                if (A[i] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                string str = String.Format("{0,3}", A[i]);
                Console.Write(str);
                count++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            count = 0;
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int K = 15;
            List<int[]> Images = new List<int[]>();
            int[] A = { 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, -1, 1, 1, -1, 1 };
            int[] fAke= { -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, -1, 1, -1, 1 };
            int[] I = { 1, 1, 1, -1, 1, -1, -1, 1, -1, -1, 1, -1, 1, 1, 1 };
            int[] F = { 1, 1, 1, 1, -1, -1, 1, 1, -1, 1, -1, -1, 1, -1, -1 };
            Images.Add(A);
            Images.Add(I);
            Images.Add(F);
            int[] Y = new int[K];
            int[,] W = new int[K, K];
            W = wMas(W, K, A);
            W = wMas(W, K, I);
            W = wMas(W, K, F);
            for (int k = 0; k < K; k++)
            {
                for (int j = 0; j < K; j++)
                {
                    string str = String.Format("{0,2} ", W[j,k]); 
                    Console.Write(str);
                }
                Console.WriteLine();
            }
            exit(K, A, "A");
            exit(K, I, "I");
            exit(K, F, "F");
            exit(K, fAke, "f");
            bool over = true;
            for (int k = 0; k < K; k++)
            {
                Y[k] = fnet(W, fAke, k, K);
            }
            int count = 1;
            while (over)
            {
                foreach (var j in Images)
                {
                    if (Y.SequenceEqual(j))
                    {
                        over = false;
                        break;
                    }
                }
                if (over == false) break;
                Y.CopyTo(fAke, 0);
                for (int k = 0; k < K; k++)
                {
                    Y[k] = fnet(W, fAke, k, K);
                }
                count++;
                if (count == 50)
                {
                   for(int i = 0; i < Y.Length; i++)
                    {
                        Y[i] = -Y[i];
                    }
                }
            }           
            exit(K, Y, "n");
            Console.WriteLine("За {0} эпох", count);
            Console.ReadKey();
        }
    }
}
