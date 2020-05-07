using System.Linq;


namespace Coursework5
{
    public class ProblemChoiceParser
    {
        public ProblemChoiceParser() { }
        public Problem Parse(string problemNumStr)
        {
            string problemLevel = problemNumStr.Last().ToString();
            problemNumStr = problemNumStr.Remove(problemNumStr.Length-1,1);
            int problemNumInt = ParseNumber(problemNumStr);
            switch (ParseLevel(problemLevel))
            {
                case 1:
                    return new Level1(problemNumInt);
                case 2:
                    return new Level2(problemNumInt);
                case 3:
                    return new Level3(problemNumInt);
            }

            return null;
        }
        private int ParseLevel(string s) => int.Parse(s);
        private int ParseNumber(string s) => int.Parse(s);
    }
}
