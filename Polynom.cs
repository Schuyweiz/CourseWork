
namespace Coursework5
{
    public class Polynom
    {
        public int a;
        public int b;
        public int ab;
        public int coef;
        public Polynom(int numA, int numB,int numC, bool calculate=false)
        {
            if (calculate == false)
            {
                this.coef = numC;
                a = numC;
                b = numC * numB * numA;
                ab = numC * (-numA + -numB);
            }
            else
            {
                a = numA;
                b = numC;
                this.ab = numB;
            }
        }
        
        public int Calculate(int x) => a * x * x + ab * x + b;
        public double Calculate(double x) => a * x * x + ab * x + b;
    }
}
