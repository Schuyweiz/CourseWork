using System;

namespace Coursework5
{
    public class Level3 : Problem
    {
        private int Substraction { get; set; }
        private int LogInnerVal { get; set; }
        private int Avalue { get; set; }
        private string Xexpression { get; set; }
        private int Coef { get; set; }
        private int PowBase { get; set; }
        private int Pow { get; set; }
        private int LhsPowBase { get; set; }
        readonly Random rng;
        public Level3(int seedVal)
        {
            rng = new Random(seedVal);
            Position = seedVal;
        }

        public override string GenerateProblem(int count)
        {
            switch (count)
            {
                case 0:
                    return Problem0();
                case 1:
                    return Problem1();
                case 2:
                    return Problem2();
                case 3:
                    return Problem3();
            }
            return null;
        }
        /// <summary>
        /// Generates a logarithm problem of a type
        /// log_{x-substraction}(logInnerVal)=Logvalue
        /// </summary>
        /// <returns></returns>
        private string Problem0()
        {
            Xvalue = rng.Next(10, 20);
            XvalueStr = Xvalue.ToString();
            Substraction = rng.Next(Xvalue/2, Xvalue);
            LogValue = rng.Next(2, 4);
            int LogInnerValLowBound = Xvalue - Substraction == 1 ? 2 : Xvalue - Substraction;
            LogInnerVal = (int)Math.Pow(LogInnerValLowBound, LogValue);
            //if log value is an even number, then there are 2 solutions
            XvalueStr2 = LogValue % 2 == 0 ? (-LogInnerValLowBound + Substraction).ToString() : null;
            //expression containing xValue
            Xexpression = "x-" + Substraction;
            Lhs = Log(Xexpression, LogInnerVal);
            Rhs = $"{LogValue}";
            return MakeFont(DisplayKey()+ Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generates a logarithmic problem of the type log_base(num^{x+b})=c
        /// using a formula log_{a^m}(a^n) = n/m
        /// </summary>
        /// <returns>string containing problem expression</returns>
        private string Problem1()
        {
            int m = rng.Next(2, 5);
            int n = m * rng.Next(1, 4);
            Avalue = rng.Next(2, 4);
            //xValue coefficient
            Coef = rng.Next(3, 10);
            Xvalue = rng.Next(0, 9);
            XvalueStr = Xvalue.ToString();
            Bvalue = n - Coef * Xvalue;
            //base value of the log in the string expression
            BaseValue = (int)Math.Pow(Avalue, m);
            //stands for the value c of the problem formula
            LogValue = n / m;
            //expression containing xValue
            Xexpression = $"{Coef}x{NumChecker(Bvalue)}";

            Lhs = Log(BaseValue, $"{Avalue}<sup>{Xexpression}</sup>");
            Rhs = $"{LogValue}";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generates a logarithm problem of the type a^{log_base(x+b)}=c
        /// where base is powBase^pow
        /// </summary>
        /// <returns>string with the problem expression</returns>
        private string Problem2()
        {
            Xvalue = rng.Next(-5, 21);
            XvalueStr = Xvalue.ToString();
            Coef = rng.Next(2, 9);
            //generating base for the log base value
            PowBase = rng.Next(2, 5);
            Pow = rng.Next(2, 8 - PowBase);
            Bvalue = Xvalue * Coef - (int)Math.Pow(PowBase, Pow);
            //number a in the problem type expression
            LhsPowBase = rng.Next(2, 5);
            //part of the expression containing xValue
            Xexpression = Log((int)Math.Pow(LhsPowBase, Pow), $"{Coef}x{NumChecker(-Bvalue)}");
            //putting down left hand side and right hand side of the equation
            Lhs = $"{LhsPowBase}<sup>{ Xexpression}</sup >";
            Rhs = $"{PowBase}";

            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generates a logarithmic equation of the type log_a(x+b) = log_a^2(x^4)
        /// adds a coefficient based on the polynomial generated
        /// </summary>
        /// <returns>string with the problem expression</returns>
        private string Problem3()
        {
            Xvalue = RandomNonNullNonX(true);
            XvalueStr = Xvalue.ToString();
            Xvalue2 = RandomNonNullNonX(false);
            XvalueStr2 = Xvalue2.ToString();
            Coef = rng.Next(1, 3);
            Polynom poly = new Polynom(Xvalue, Xvalue2, Coef);
            BaseValue = rng.Next(2, 6);
            Lhs = Log(BaseValue, CoefChecker(-poly.ab,"x")+ NumChecker(-poly.b));
            Rhs = Log(Square(BaseValue), CoefChecker(Square(poly.a), "x<sup>4</sup>"));

            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }


        private int RandomNonNullNonX(bool isXvalue)
        {
            var res = rng.Next(-5, 6);
            res =res == 0  ? res + 1 : res;
            
            return isXvalue? res:
                res == Xvalue ?
                res + 1 :
                res;
        }

        public override void GenerateProblemExpression()
        {
            this.Key = GenerateKey(Position) + "3";

            HtmlFormula = GenerateProblem(Position % 4);
        }

        public override string DisplayAnswers()
        {
            return XvalueStr2 == null && XvalueStr == null ?
                "Нет решения" :
                XvalueStr2 == null ?
                "x = "+XvalueStr :
                XvalueStr == null ?
                "x = "+XvalueStr2 :
                $"x<sub>1</sub> = {XvalueStr} | x<sub>2</sub> = {XvalueStr2}";
        }
    }
}

