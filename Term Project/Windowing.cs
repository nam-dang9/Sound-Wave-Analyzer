using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Term_Project
{
    class Windowing
    {
        /**Method to apply Triangle windowing on selected points.*/
        public double[] Triangle(double[] wave, int size, int start)
        {
            int N = start + size;
            for (int n = 0; n < N + 1; n++)
            {
                wave[n] = wave[n] * (1 - Math.Abs((n - ((N - 1) / 2)) / (N / 2)));
            }
            return wave;
        }
        /**Method to apply Rectangle windowing on selected points.*/
        public double[] Rectangle(double[] wave, int size, int start)
        {
            int N = start + size;
            for (int n = start; n < N; n++)
            {
                wave[n] =  1;
            }
            return wave;
        }
        /**Method to apply Welch windowing on selected points.*/
        public double[] Welch(double[] wave, int size, int start)
        {
            int N = start + size;
            for (int n = start; n < N; n++)
            {
                wave[n] = (1 - Math.Sqrt((n - ((N - 1) / 2)) / ((N - 1) / 2)));
            }
            return wave;
        }
    }
}
