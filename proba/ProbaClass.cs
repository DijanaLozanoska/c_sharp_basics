using System;
namespace proba
{
    public class mcCalculator
    {

        private int iOutVal;
        //Default constructor  

        public mcCalculator()
        {
            iOutVal = 0;
        }

        public mcCalculator(int iVal1)
        {
            iOutVal = iVal1;
        }
        //destructor  
        ~mcCalculator()
        {
            iOutVal = 0;
        }

        //methods  
        public void displayiOutVal()
        {
            Console.WriteLine("iOutVal = {0}", iOutVal);
        }

        // this function adds two values and saves in iOutVal  

        public void add(int iVal1, int iVal2)
        {
            iOutVal = iVal1 + iVal2;
        }
        // this function subtracts one from other and saves in iOutVal  
        public void subtract(int iVal1, int iVal2)
        {
            iOutVal = iVal1 - iVal2;
        }
        // this function multiplyies two values and saves in iOutVal  
        public void Multiply(int iVal1, int iVal2)
        {
            iOutVal = iVal1 * iVal2;
        }
        // this function devides one value from other and saves in iOutVal  
        public void Divide(int iVal1, int iVal2)
        {
            iOutVal = iVal1 / iVal2;
        }
    }
}

