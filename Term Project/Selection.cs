using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Term_Project
{
    public class Selection
    {
        private double start;
        private double end;
        /**Constructor for our Selection class.*/
        public Selection() {
            start = 0;
            end = 0;
        }
        /** Method to get the start of our selected points.*/
        public double getStart() {
            return start;
        }
        /** Method to set the start of our selected points. */
        public void setStart(double start2) {
            start = start2;
        }
        /** Method to get the end of our selected points.*/
        public double getEnd() {
            return end;
        }
        /** Method to set the start of our selected points.*/
        public void setEnd(double end2) {
            end = end2;
        }
    }
}
