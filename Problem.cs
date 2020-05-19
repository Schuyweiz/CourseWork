

namespace Coursework5
{
    public abstract class Problem
    {

        #region fields
        private string key;
        private int xValue;
        private int baseValue;
        private int logValue;
        private int bValue;
        private string htmlFormula;
        private string rhs;
        private string lhs;
        private int randSubstractionTerm;
        private int xValue2;
        private string xValueStr;
        private string xValueStr2;
        private int position;
        public static int seed;
        #endregion

        #region properties
        public int Position { get => position; set => position = value; }
        public string XvalueStr2 { get => xValueStr2; set => xValueStr2 = value; }
        public string XvalueStr { get => xValueStr; set => xValueStr = value; }
        public int Xvalue { get => xValue; set => xValue = value; }
        public int Xvalue2 { get => xValue2; set => xValue2 = value; }
        public int RandSubstractionTerm { get => randSubstractionTerm; set => randSubstractionTerm = value; }
        public string HtmlFormula { get => htmlFormula; set => htmlFormula = value; }
        public string Key { get => key; set => key = value; }
        public int BaseValue { get => baseValue; set => baseValue = value; }
        public int LogValue { get => logValue; set => logValue = value; }
        public int Bvalue { get => bValue; set => bValue = value; }
        public string Rhs { get => rhs; set => rhs = value; }
        public string Lhs { get => lhs; set => lhs = value; }
        #endregion

        public virtual string GenerateKey(int position)=> position.ToString().PadLeft(3, '0');

        public virtual int Square(int val) => val * val;
        public virtual string Log(int logBase, string logVal) => $"log<sub vertical-align:-10px;>{logBase}</sub> ({logVal})";
        public virtual string Log(string logBase, int logVal) => $"log<sub vertical-align:-10px;>{logBase}</sub> ({logVal})";
        public virtual string LogFrac(int logBase, string logVal) => "log<sub> " + Frac(logBase) + $"</sub> ({logVal})";
        public virtual string NumChecker(int val) => val == 0 ? "" :
            val > 0 ? "+" + val.ToString() :
            val.ToString();
        public virtual string CoefChecker(int val, string x) => val == 1 ?
            x :
            val == 0 ?
            "" :
            val.ToString() + x;
        public virtual string Frac(int denom, int nom = 1)
        {
            if (nom == denom)
                return "1";
            if (nom == -denom)
                return "-1";
            if (nom == 0)
                return nom.ToString();
            string res = $"<span class=\"frac\"><sup>{nom}</sup>";
            res += "<span>&nbsp</span>";
            res += $"<sub>{denom}</sub></span>";
            return res;
        }
        public virtual string LogPow(int logBase, int logPow, string logExpression)
        {
            string res = $"<span class=\"logPow\"><sup>{logPow}</sup>";
            res += "<span>&nbsp</span>";
            res += "<span>&nbsp</span>";
            res += $"<sub>{logBase}</sub></span>";
            res += $"({logExpression})";
            return res;
        }
        public virtual string MakeFont(string expression) => $"<p><font face=\"Bookman\">" + expression + "</p>";
        public virtual string DisplayKey() => $"<small>№ {Key}</small>&ensp;&ensp;";
        public abstract string GenerateProblem(int count);

        public virtual string SimplifyFrac(int nom, int denom)
        {
            // a = b*q + r
            // b = r*q' + r'
            int a = nom > denom ? nom : denom;
            int b = nom + denom - a;
            int r = a - b * (a / b);
            int gcd = b;
            while (r != 0)
            {
                gcd = r;
                a = b;
                b = r;
                r = a - b * (a / b);
            }
            return Frac(denom / gcd, nom / gcd);
        }
        public abstract void GenerateProblemExpression();
        public abstract string DisplayAnswers();
    }
}
