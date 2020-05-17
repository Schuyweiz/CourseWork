using System;


namespace Coursework5
{
    class Level1 : Problem
    {
        //In this type of problems we will study logarithmic expressions such as 
        //log_a x+b = c where a is the base of the logarithm, x is the value under the logarithm
        //and c is the value of the logarithm
        private string LogExpression { get; set; }
        private int LogValueCoef { get; set; }

        readonly Random rng;


        public Level1(int seedValue)
        {
            rng = new Random(seedValue);
            Position = seedValue;
        }


        private void GenerateValue()
        {
            Xvalue = rng.Next(-40, 40);
            BaseValue = rng.Next(2, 5);
            LogValueCoef = rng.Next(2, 4);
            LogValue = rng.Next(2, 6 - LogValueCoef);
            Bvalue = (int)Math.Pow(BaseValue, LogValue) - Xvalue;
            LogExpression = $"x{NumChecker(Bvalue)}";
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
        private string Problem0()
        {
            Lhs = Log(BaseValue, LogExpression) + NumChecker(RandSubstractionTerm = rng.Next(-LogValue, LogValue));
            LogValue += RandSubstractionTerm;
            Rhs = rng.Next(0, 2) == 1 && LogValue > 1 && LogValue == BaseValue ?
                 Log(BaseValue.ToString(), (int)Math.Pow(LogValue, BaseValue)) :
                $"{LogValue}";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        private string Problem1()
        {
            Lhs = LogFrac(BaseValue, LogExpression) + NumChecker(RandSubstractionTerm = rng.Next(-LogValue, LogValue));
            LogValue -= RandSubstractionTerm;
            Rhs = $"{NumChecker(-LogValue)}";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        private string Problem2()
        {
            int logValuePart = rng.Next(-LogValue, LogValue);
            Lhs = Log(BaseValue, LogExpression) + NumChecker(-logValuePart);
            Rhs = $"{LogValue - logValuePart}";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        private string Problem3()
        {
            RandSubstractionTerm = rng.Next(-LogValue, LogValue);
            Lhs = $"{CoefChecker(LogValueCoef, Log(BaseValue, $"x{NumChecker(Bvalue)}"))}" + NumChecker(-RandSubstractionTerm);
            Rhs = $"{LogValue * LogValueCoef - RandSubstractionTerm}";
            return MakeFont(DisplayKey() + Lhs + " = " + Rhs);
        }
        public override void GenerateProblemExpression()
        {
            Key = GenerateKey(Position) + "1";
            GenerateValue();
            this.HtmlFormula = GenerateProblem(Position % 4);
        }

        public override string DisplayAnswers()
        {
            return $"{Xvalue}";
        }
    }
}
