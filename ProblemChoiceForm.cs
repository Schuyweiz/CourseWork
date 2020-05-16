using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Coursework5
{
    public partial class ProblemChoiceForm : Form
    {
        public ProblemChoiceForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Text = "Генератор задач";
            #region initialising events for buttons
            buttonHtmlGen.Click += HtmlGenButton_Click;


            buttonLevel1.Click += Level1Choice;
            buttonLevel1.Click += LevelButtonsSwitch;
            buttonLevel1.Click += LevelPick;
            buttonLevel1.Click += AnswersOnOffView;
            buttonLevel2.Click += Level2Choice;
            buttonLevel2.Click += LevelButtonsSwitch;
            buttonLevel2.Click += LevelPick;
            buttonLevel2.Click += AnswersOnOffView;
            buttonLevel3.Click += Level3Choice;
            buttonLevel3.Click += LevelButtonsSwitch;
            buttonLevel3.Click += LevelPick;
            buttonLevel3.Click += AnswersOnOffView;
            buttonHandPick.Click += LevelButtonsSwitch;
            buttonHandPick.Click += HandPick;
            buttonHandPick.Click += AnswersOnOffView;
            buttonAddProblem.Click += ProblemNumberCheck;
            buttonAddProblem.Click += ProblemAmtChecker;

            buttonAnswersOnOff.Click += AnswersOnOff;

            buttonExit.Click += OnExitButtonClick;
            #endregion
            textBoxAmtOfPb.Text = "10";
            Parser = new ProblemChoiceParser();
            Problems = new List<string>();
            Answers = new List<string>();
            LevelSelectionButtons(Buttons = true);
            ButtonHtmlGenY = buttonHtmlGen.Location.Y;
            AnswersOn = true;
            AmountOfProblems = 0;

            
        }
        readonly Random rng = new Random();
        #region fields
        private int ButtonHtmlGenY { get; set; }
        private int labelPointY = 20;
        #endregion
        #region Properties
        private bool AnswersOn { get; set; }
        private List<string> Problems;
        private List<string> Answers;
        ProblemChoiceParser Parser { get; set; }
        private int LabelPointY { get => labelPointY; set => labelPointY = value; }
        private bool Buttons { get; set; }
        private int AmountOfProblems { get; set; }
        private string FilePath { get; set; }
        #endregion

        private void HtmlGenButton_Click(object sender, EventArgs e)
        {
            if (labelListOfPbm.Visible == false)
            {
                int input;
                if (!int.TryParse((textBoxAmtOfPb.Text), out input) || input < 1 || input > 99)
                    MessageBox.Show("Введите число от 1 до 99");
                else
                {
                    SaveLoadInteraction(sender, e);
                    LevelButtonsSwitch(sender, e);
                }
            }
            else
            {
                SaveLoadInteraction(sender,e);
                LevelButtonsSwitch(sender, e);
                MainMenu();
            }
        }
        private void OnExitButtonClick(object sender, EventArgs e)
        {
            LevelButtonsSwitch(sender, e);
            MainMenu();
        }
        private void SaveLoadInteraction(object sender, EventArgs e)
        {
            using (SaveFile form = new SaveFile())
            {
                form.Location = buttonHtmlGen.Location;
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string problems = CreateProblemsText();
                    bool val = form.SaveOrLoad;          
                    if (val)
                    {
                        SaveFile(problems);
                        if(FilePath!=null)
                            HtmlLaunch();
                        MainMenu();
                    }
                    else
                    {
                        SaveFile(problems);
                        MainMenu();
                    }
                }
            }
        }
        public void SaveFile(string problems)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                save.FileName = "Список задач";
                save.FilterIndex = 1;
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    FilePath = save.FileName;
                    TryWriting(problems, FilePath);
                }
            }
        }
        private void TryWriting(string text, string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "Error occured while writing down a file...",
                    "", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "You do not have the rights to write a file. Try launching the application again as an administrator",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unk",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private string CreateProblemsText()
        {
            HtmlCustomWriter html;
            if (labelProblemNumber.Visible)
                html = new HtmlCustomWriter(Problems, Answers);

            else
            {
                PickProblems(int.Parse(textBoxAmtOfPb.Text));
                html = new HtmlCustomWriter(Problems, Answers);
            }
            return AnswersOn ? html.ShowTasksAnswers() : html.ShowTasks();
        }
        
        private bool LastDigitIsLevel(int num) => num == 1 || num == 2 || num == 3;
        private bool ProblemNumberChecker(string input) => input.Length !=4 ?
            false :
            !LastDigitIsLevel(int.Parse(input[3].ToString())) ?
            false :
            true;
        private void ProblemNumberCheck(object sender, EventArgs e)
        {
            string input = textBoxAmtOfPb.Text;
            if (!int.TryParse((input), out int output))
                MessageBox.Show("Введите четырёхзначный номер задачи");
            else if (!ProblemNumberChecker(input))
                MessageBox.Show("Задачи с такиим номером не существует");
            else
            {
                AddNewProblem(sender, e);
            }
        }
        private void ProblemAmtChecker(object sender, EventArgs e)
        {
            AmountOfProblems++;
            if (AmountOfProblems < 1 || AmountOfProblems > 10)
                buttonAddProblem.Enabled = false;
        }
        private void LevelButtonsSwitch(object sender, EventArgs e)
        {
            Buttons = !Buttons;
            LevelSelectionButtons(Buttons);
        }
        private void LevelSelectionButtons(bool on)
        {
            if (on)
            {
                buttonLevel1.Show();
                buttonLevel2.Show();
                buttonLevel3.Show();
                buttonHandPick.Show();
                buttonAddProblem.Hide();
                buttonHtmlGen.Hide();
                buttonAnswersOnOff.Hide();
                buttonExit.Hide();
                foreach (var lbl in Controls.OfType<Label>())
                    lbl.Hide();
                foreach (var lbl in Controls.OfType<TextBox>())
                    lbl.Hide();
            }
            else
            {
                foreach (var lbl in Controls.OfType<Button>())
                    lbl.Hide();
            }
        }

        #region answers handling
        private void AnswersOnOffView(object sender, EventArgs e) => buttonAnswersOnOff.Visible = !buttonAnswersOnOff.Visible;
        private void AnswersOnOff(object sender, EventArgs e)
        {
            buttonAnswersOnOff.Text = AnswersOn ? "Ответы выкл." : "Ответы вкл.";
            AnswersOn = !AnswersOn;
        }
        #endregion



        #region Level choice
        private void Level1Choice(object sender, EventArgs e) => GenerateTasksLevel1(100);
        private void Level2Choice(object sender, EventArgs e) => GenerateTasksLevel2(100);
        private void Level3Choice(object sender, EventArgs e) => GenerateTasksLevel3(100);
        private void LevelPick(object sender, EventArgs e)
        {
            buttonHtmlGen.Show();
            textBoxAmtOfPb.Show();
            buttonExit.Show();
            labelAmountOfProblems.Show();
        }
        #endregion

        #region Level problem generation
        private void GenerateTasksLevel1(int n)
        {
            List<string> problems = new List<string>();
            List<string> answers = new List<string>();

            for (int i = 0; i < n; i++)
            {
                Level1 task = new Level1(i);
                task.GenerateProblemExpression();
                problems.Add(task.HtmlFormula);
                answers.Add(task.DisplayAnswers());
            }
            Problems = problems;
            Answers = answers;
        }
        private void GenerateTasksLevel2(int n)
        {
            List<string> problems = new List<string>();
            List<string> answers = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Level2 task = new Level2(i);
                task.GenerateProblemExpression();
                problems.Add(task.HtmlFormula);
                answers.Add(task.DisplayAnswers());
            }
            Problems = problems;
            Answers = answers;
        }
        private void GenerateTasksLevel3(int n)
        {
            List<string> problems = new List<string>();
            List<string> ans = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Level3 task = new Level3(i);
                task.GenerateProblemExpression();
                problems.Add(task.HtmlFormula);
                ans.Add(task.DisplayAnswers());
            }
            Problems = problems;
            Answers = ans;
        }
        #endregion 

        #region Hand pick choice methods
        /// <summary>
        /// Genrates interface for the problem hand picking menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandPick(object sender, EventArgs e)
        {
            buttonHtmlGen.Enabled = false;
            buttonHtmlGen.Show();
            buttonAddProblem.Show();
            textBoxAmtOfPb.Show();
            labelProblemNumber.Show();
            labelListOfPbm.Show();
            labelHint.Show();
            buttonExit.Show();
            Point p = buttonHtmlGen.Location;
            buttonHtmlGen.Location = new Point(p.X, p.Y + 50);
        }
        private string ProblemNumberInput()
        {
            string res = textBoxAmtOfPb.Text;
            textBoxAmtOfPb.Text = "";
            return res;
        }
        private void NewProblemLabel(string num)
        {
            Label problemNumber = new Label
            {
                Location = new Point(labelListOfPbm.Location.X,
                labelListOfPbm.Location.Y+LabelPointY),
                Text = num
            };
            Controls.Add(problemNumber);
            LabelPointY += 25;
        }
        private void AddNewProblem(object sender, EventArgs e)
        {
            string problemNum = ProblemNumberInput();
            Problem pb = Parser.Parse(problemNum);
            pb.GenerateProblemExpression();
            Problems.Add(pb.HtmlFormula);
            Answers.Add(pb.DisplayAnswers());
            NewProblemLabel(problemNum);
            buttonHtmlGen.Enabled = true;
        }
        #endregion

        private void PickProblems(int n)
        {
            List<string> selectedProblems = new List<string>();
            List<string> correspondingAsnwers = new List<string>();

            for (int i = 0; i < n; i++)
            {
                int pos = rng.Next(0, Problems.Count);
                selectedProblems.Add(Problems[pos]);
                correspondingAsnwers.Add(Answers[pos]);
                Problems.RemoveAt(pos);
                Answers.RemoveAt(pos);
            }
            Problems = selectedProblems;
            Answers = correspondingAsnwers;
        }

        private void HtmlLaunch()=> System.Diagnostics.Process.Start(FilePath);

        



        private void MainMenu()
        {
            Problems = new List<string>();
            Answers = new List<string>();
            buttonAddProblem.Enabled = true;
            buttonHtmlGen.Enabled = true;
            labelHint.Hide();
            LabelPointY = 20;
            Point p = buttonHtmlGen.Location;
            buttonHtmlGen.Location = new Point(p.X, ButtonHtmlGenY);
            FilePath = null;
        }
    }
}
