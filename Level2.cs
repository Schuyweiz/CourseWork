using System;


namespace Coursework5
{
    public class Level2 : Problem
    {
        private Random rng;

        //X coefficient
        private int СoefX { get; set; }
        private int CoefX2 { get; set; }
        //When generating type 1 problem we will use the property
        //log_a(x1) + log_a(x2) = log_a(x1*x2). logVAl1 and logVal2 correspond to 
        //those 2 logs
        private int LogVal1 { get; set; }
        private int LogVal2 { get; set; }

        public int Part1Bvalue { get; set; }
        public int Part2Bvalue { get; set; }




        public Level2(int seedVal)
        {
            this.rng = new Random(seedVal);
            Position = seedVal;
        }

        private void GenerateXval(int seedVal)
        {
            //type 0 problems
            if (seedVal % 4 == 0)
            {
                СoefX = 1;
                this.Xvalue = rng.Next(-5, 5);
                Xvalue = Xvalue == 0 ? Xvalue + 1 : Xvalue;
                XvalueStr = Xvalue.ToString();
            }
            //type 1 problems
            else
            {
                this.Xvalue = rng.Next(2, 11);
                XvalueStr = Xvalue.ToString();
                СoefX = rng.Next(1, 6);

            }
        }
        private void GenerateValuesGeneral()
        {
            LogVal1 = rng.Next(0, 4);
            LogVal2 = rng.Next(4 - LogVal1, 5 - LogVal1);
            BaseValue = rng.Next(2, 5);
            LogValue = LogVal1 + LogVal2;
            CoefX2 = rng.Next(1, (int)Math.Pow(BaseValue, LogVal2) / Math.Abs(Xvalue) + 1);
            Part1Bvalue = (int)Math.Pow(BaseValue, LogVal1) - СoefX * Xvalue;
            Part2Bvalue = (int)Math.Pow(BaseValue, LogVal2) - CoefX2 * Xvalue;
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
        /// Generates problems of the type log_base(Polynom) = LogValue
        /// </summary>
        /// <returns>string containing problem expression</returns>
        private string Problem0()
        {
            Polynom p = new Polynom(Position);
            p.GeneratePolynom();
            //expression we have is (x-xValue)(coef*x-xValueNom2)=0
            Xvalue = p.xValue1;
            //xVAlue2 will be put down in case it exists

            p.c+=rng.Next(0,2)==1? -(int)Math.Pow(BaseValue, LogValue): (int)Math.Pow(BaseValue, LogValue);
            //now we have the expression log(polynome+c) = log(c) = LogValue
            //Lets check the possibility of x1 x2 giving a non erroneous answer
            XvalueStr = p.Calculate(Xvalue) > 0 ? Xvalue.ToString() : null;
            XvalueStr2 = p.Calculate(p.xValueNom2 / (double)p.xValueDenom2) > 0 ? Frac(p.xValueDenom2, p.xValueNom2) : null;

            string logExpression = CoefChecker(p.a, "x<sup>2</sup>") + CoefChecker(p.b,"x")+ NumChecker(p.c);
            Lhs = Log(BaseValue, logExpression);
            Rhs = LogValue.ToString();

            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generates a logarithm problem of a type 
        /// log_base(x1+b1) + log_base(x2+b2) = LogValue
        /// </summary>
        /// <returns>string containg problem expression</returns>
        private string Problem1()
        {
            string log1Expression = $"{CoefChecker(СoefX, "x")}{NumChecker(Part1Bvalue)}";
            string log2Expression = $"{CoefChecker(CoefX2, "x")}{NumChecker(Part2Bvalue)}";
            string log1 = Log(BaseValue, log1Expression);
            string log2 = Log(BaseValue, log2Expression);

            if (rng.Next(0, 2) == 1)
            {
                Lhs = log1 + " + " + log2;
                Rhs = $"{LogValue}";
            }
            else
            {
                Lhs = log1;
                Rhs = $"{LogValue}" + " - " + log2;
            }

            Xvalue2 = -(Part1Bvalue * CoefX2 + Part2Bvalue * СoefX) - Xvalue;
            XvalueStr2 = CoefX2 * Xvalue2 + Part2Bvalue > 0 && CoefX2 * Xvalue2 + Part1Bvalue > 0 ? Xvalue2.ToString() : null;
            XvalueStr = СoefX * Xvalue + Part1Bvalue > 0 && СoefX * Xvalue + Part2Bvalue > 0 ? Xvalue.ToString() : null;

            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generates a logarithm problem of the type log_{x}(value)=logvalue
        /// using log definition log_a(b)=c <=> a^c = b
        /// </summary>
        /// <returns>string containing a problem expression</returns>
        private string Problem2()
        {
            //Getting rid of obnoxiously large numbers
            int logValueUpperLim = 11 / (6 - (int)Math.Pow(2, (12 - Xvalue) / 5)) + (12 - Xvalue) / 5 + 3 * ((12 - Xvalue) / 10);
            int logValue = rng.Next(2, logValueUpperLim);

            Lhs = Log("x", (int)Math.Pow(Xvalue, logValue));
            Rhs = $"{logValue}";

            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        /// <summary>
        /// Generatesa logarithm problem of a type
        /// (a*log_base(x1)-root1) * (a'log_base(x2)-root2) = 0
        /// where root 1 is always 1 for the sake of convenience while generating
        /// </summary>
        /// <returns>string containing a problem expression</returns>
        private string Problem3()
        {
            //problem type is (a*log_base(x1)-1) * (a'log_base(x2)-1) = 0
            int root1 = 1;
            int aUpperLim = 9 / (6 - (int)Math.Pow(2, (12 - Xvalue) / 5)) + 2 * ((12 - Xvalue) / 10);
            int a = rng.Next(1, aUpperLim+1);
            int root2 = rng.Next(2, 4);
            int aPrime = rng.Next(1, 5);
            BaseValue = (int)Math.Pow(Xvalue, a);

            XvalueStr2 = Math.Pow(BaseValue, (double)root2 / aPrime) % 1 == 0 ?
                Math.Pow(BaseValue, (double)root2 / aPrime).ToString() :
                BaseValue.ToString() + "<sup><sup><sup>" + Frac(aPrime, root2) + "</sup></sup></sup>";

            Lhs = $"{a * aPrime}{"log"+LogPow(BaseValue,2,"x")}-{a * root2 + aPrime * root1}{Log(BaseValue, "x")}+{root1 * root2}";
            Rhs = $"0";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);

        }

        public override void GenerateProblemExpression()
        {
            Key = GenerateKey(Position) + "2";
            GenerateXval(Position);
            GenerateValuesGeneral();
            this.HtmlFormula = GenerateProblem(Position % 4);
        }

        public override string DisplayAnswers()
        {
            return XvalueStr2 == null && XvalueStr == null ?
                "Нет решений" :
                XvalueStr == null ?
                $"x = {XvalueStr2}" :
                XvalueStr2 == null ?
                $"x = {XvalueStr}" :
                $"x<sub>1</sub> = {XvalueStr} | x<sub>2</sub> = {XvalueStr2}";
        }
    }
}
