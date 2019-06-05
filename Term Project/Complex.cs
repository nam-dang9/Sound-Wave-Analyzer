using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Term_Project
{
    class Complex
    {

         public double real, imaginary;
            /**2 parameter constructor*/
            public Complex(double re, double im) {
                real = re;
                imaginary = im;
            }
            /**Method to get the real points of our Complex number.*/
            public double getReal() {
                return real;
            }
            /** Method to get the imaginary points of our Complex number.*/
            public double getImaginary() {
                return imaginary;
            }
        
    }
}
