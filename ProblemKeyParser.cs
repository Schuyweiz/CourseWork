using System;
using System.Collections.Generic;
using System.Linq;


namespace Coursework5
{
    public class ProblemKeyParser
    {
        public Tuple<List<string>, List<string>> ProblemsAnswers { get; set; }
        public ProblemKeyParser() { }
        public Problem Parse(string problemNumStr)
        {
            string problemLevel = problemNumStr.Last().ToString();
            problemNumStr = problemNumStr.Remove(problemNumStr.Length - 1, 1);
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
        #region problem set parser
        public void ParseProblemSet(string key, Tuple<List<string>, List<string>> pb)
        {
            //1,2,3 correspond to levels and 4 corresponds to a mixed set
            char type = key[0];
            int seed = int.Parse(key.Substring(1, 2));
            int amount = int.Parse(key.Substring(3));
            Tuple<List<string>, List<string>> tuple=null;
            if (type != '4')
                tuple = ParseLevel(type);
            else
                tuple = pb;
            List<string> problems = tuple.Item1;
            List<string> answers = tuple.Item2;
            List<string> selectedProblems = new List<string>();
            List<string> selectedAnswers = new List<string>();

            Random rng2 = new Random(seed);
            for (int i = 0; i < amount; i++)
            {
                int pos = rng2.Next(0, problems.Count);
                selectedProblems.Add(problems[pos]);
                selectedAnswers.Add(answers[pos]);
                problems.RemoveAt(pos);
                answers.RemoveAt(pos);
            }
            ProblemsAnswers= new Tuple<List<string>, List<string>>(selectedProblems, selectedAnswers);
        }

        private Tuple<List<string>, List<string>> ParseMixedSet()
        {
            List<string> problems = new List<string>();
            List<string> answers = new List<string>();

            int key1 = 0;
            int problemSeed1 = 0;
            do
            {
                Level2 task = new Level2(problemSeed1);
                task.GenerateProblemExpression();
                ;
                if (!answers.Contains(task.DisplayAnswers()))
                {
                    problems.Add(task.HtmlFormula);
                    answers.Add(task.DisplayAnswers());
                    key1++;
                }
                problemSeed1++;
            }
            while (key1 <100);
            int key2 = 0;
            int problemSeed2 = 0;
            do
            {
                Level2 task = new Level2(problemSeed2);
                task.GenerateProblemExpression();
                ;
                if (!answers.Contains(task.DisplayAnswers()))
                {
                    problems.Add(task.HtmlFormula);
                    answers.Add(task.DisplayAnswers());
                    key2++;
                }
                problemSeed2++;
            }
            while (key2 < 100);
            int key3 = 0;
            int problemSeed3 = 0;
            do
            {
                Level2 task = new Level2(problemSeed3);
                task.GenerateProblemExpression();
                ;
                if (!answers.Contains(task.DisplayAnswers()))
                {
                    problems.Add(task.HtmlFormula);
                    answers.Add(task.DisplayAnswers());
                    key3++;
                }
                problemSeed3++;
            }
            while (key3 < 100);
            return new Tuple<List<string>, List<string>>(problems, answers);
        }

        private Tuple<List<string>, List<string>> ParseLevel(char level, int n = 100)
        {
            List<string> problems = new List<string>();
            List<string> answers = new List<string>();
            switch (level)
            {
                case '1':
                    for (int i = 0; i < n; i++)
                    {
                        Level1 task = new Level1(i);
                        task.GenerateProblemExpression();
                        problems.Add(task.HtmlFormula);
                        answers.Add(task.DisplayAnswers());
                    }
                    break;
                case '2':
                    for (int i = 0; i < n; i++)
                    {
                        Level2 task = new Level2(i);
                        task.GenerateProblemExpression();
                        problems.Add(task.HtmlFormula);
                        answers.Add(task.DisplayAnswers());
                    }
                    break;
                case '3':
                    for (int i = 0; i < n; i++)
                    {
                        Level3 task = new Level3(i);
                        task.GenerateProblemExpression();
                        problems.Add(task.HtmlFormula);
                        answers.Add(task.DisplayAnswers());
                    }
                    break;
            }
            return new Tuple<List<string>, List<string>>(problems, answers);

        }
        #endregion
    }
}
