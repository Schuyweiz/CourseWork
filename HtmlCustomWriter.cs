﻿using System.Collections.Generic;

namespace Coursework5
{
    public class HtmlCustomWriter
    {
        #region fields
        private readonly string intro = "<!DOCTYPE html><html><head> <meta charset=\"UTF-16\">";
        private readonly string outro = "</body></html>";
        
        private readonly string boxStyle =
            "* {box-sizing:border-box;" +
            "}" +
            ".column { float: left;" +
            " width: 33.33%;" +
            " padding: 1px;" +
            "}" +
            ".row:: after{content: \"\";" +
            "clear: both;" +
            " display: table;" +
            "}";
        private readonly string boxStylePreview =
            "* {box-sizing:border-box;" +
            "}" +
            ".column { float: left;" +
            " width: 50%;" +
            " padding: 0px;" +
            "}" +
            ".row:: after{content: \"\";" +
            "clear: both;" +
            " display: table;" +
            "}";

        private readonly string fractionStyle =
            "span.frac { display: inline-block;" +
            " vertical-align: -10px;" +
            " text-align: center;" +
            " font-size: 10px;" +
            " font-weight: 700" +
            "}" +
            " span.frac > sup, span.frac > sub {display: block;" +
            " font: inherit;" +
            " padding: 0 0.01em; " +
            "}" +
            " span.frac > sup {border-bottom: 0.1em solid;} " +
            " span.frac > span {display: none;}";
        private readonly string logPowStyle =
            "span.logPow { display: inline-block;" +
            " vertical-align: -5px;" +
            " text-align: center;" +
            " font-size: 10px;" +
            " font-weight: 700" +
            "}" +
            " span.logPow > sup, span.logPow > sub {display: block;" +
            " font: inherit;" +
            " padding: 0 0.01em; " +
            "}" +
            " span.logPow > span {display: none;}";
        private readonly string headerStyle = "H1 {text-align: center}";
        #endregion

        private string Style() => "<style>" + boxStyle + fractionStyle + logPowStyle +headerStyle+ "</style><body>";
        private string StylePreview() => "<style>" + boxStylePreview + fractionStyle + logPowStyle + "</style><body>";
        private string Header(string s) => $"<header><h1>{s}</h1></header>"; 
        private string Div(string s, string divClass) => $"<div class=\"{divClass}\">" + s + "</div>";
        private List<string> pbs;
        private List<string> answers;

        public HtmlCustomWriter(List<string> pbs, List<string> answers)
        {
            this.pbs = pbs;
            this.answers = answers;
        }

        public string PreviewTasks()
        {
            string res = intro;
            res += StylePreview();
            string col1 = "";
            string col2 = "";
            for (int i = 0; i < pbs.Count; i++)
            {
                string problem = pbs[i];
                switch (i % 2)
                {
                    case 0:
                        col1 += problem + "<p>Ответ:</p><br>";
                        break;
                    case 1:
                        col2 += problem + "<p>Ответ:</p><br>";
                        break;
                }
            }
            res += Div(Div(col1, "column") + Div(col2, "column"), "row");

            res += outro;
            return res;
        }
        public string PreviewTasksAnswers()
        {
            string res = intro;
            res += StylePreview();
            string col1 = "";
            string col2 = "";
            for (int i = 0; i < pbs.Count; i++)
            {
                string problem = pbs[i];
                string answer = answers[i];
                switch (i % 2)
                {
                    case 0:
                        col1 += problem + $"<p>Ответ: {answer}</p><br>";
                        break;
                    case 1:
                        col2 += problem + $"<p>Ответ: {answer}</p><br>";
                        break;
                }
            }
            res += Div(Div(col1, "column") + Div(col2, "column"), "row");

            res += outro;
            return res;
        }

        public string ShowTasks(string key,bool header)
        {
            string res = intro;
            res += Style();
            if (header)
                res += Header("Блок задач номер " + key);
            string col1 = "";
            string col2 = "";
            string col3 = "";
            for (int i = 0; i < pbs.Count; i++)
            {
                string problem = pbs[i];
                switch (i % 3)
                {
                    case 0:
                        col1 += problem + "<p>Ответ:</p><br>";
                        break;
                    case 1:
                        col2 += problem + "<p>Ответ:</p><br>";
                        break;
                    case 2:
                        col3 += problem + "<p>Ответ:</p><br>";
                        break;
                }
            }
            res += Div(Div(col1, "column") + Div(col2, "column") + Div(col3, "column"), "row");

            res += outro;
            return res;
        }
        public string ShowTasksAnswers(string key, bool header)
        {
            string res = intro;
            res += Style();
            if (header)
                res += Header("Блок задач номер " + key);
            string col1 = "";
            string col2 = "";
            string col3 = "";
            for (int i = 0; i < pbs.Count; i++)
            {
                string problem = pbs[i];
                string answer = answers[i];
                switch (i % 3)
                {
                    case 0:
                        col1 += problem + $"<p>Ответ: {answer}</p><br>";
                        break;
                    case 1:
                        col2 += problem + $"<p>Ответ: {answer}</p><br>";
                        break;
                    case 2:
                        col3 += problem + $"<p>Ответ: {answer}</p><br>";
                        break;
                }
            }
            res += Div(Div(col1, "column") + Div(col2, "column") + Div(col3, "column"), "row");

            res += outro;
            return res;
        }

    }
}
