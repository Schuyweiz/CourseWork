
using System;

namespace Coursework5
{
    public class Polynom
    {
        //polynome in this case is ax^2 + bx + c
        public int a;
        public int c;
        public int b;
        public int coef;
        public int xValue1;
        public int xValueNom2;
        public int xValueDenom2;
        public Polynom(int numA, int numB,int numC, bool calculate=false)
        {
            if (calculate == false)
            {
                this.coef = numC;
                a = numC;
                c = numC * numB * numA;
                b = numC * (-numA + -numB);
            }
            else
            {
                a = numA;
                c = numC;
                this.b = numB;
            }
        }
        Random rng;
        public Polynom(int seed) { rng = new Random(seed); }

        public void GeneratePolynom()
        {
            xValue1 = rng.Next(1, 4)*(rng.Next(0,2)-1);
            coef = rng.Next(1, 4);
            xValueNom2 = rng.Next(1, 3)*(rng.Next(0,2)-1);
            xValueDenom2 = coef;

            this.a = coef;
            this.b = -xValueNom2 - xValue1 * coef;
            this.c = xValue1 * xValueNom2;
        }
        
        public int Calculate(int x) => a * x * x + b * x + c;
        public double Calculate(double x) => a * x * x + b * x + c;
    }
}
