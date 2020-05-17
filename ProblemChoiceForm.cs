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
            LevelButtons = new List<Button>() { buttonLevel1, buttonLevel2, buttonLevel3 };
            #region initialising events for buttons
            //generate
            buttonSaveFile.Click += ButtonSaveFileClick;

            foreach (Button button in LevelButtons)
            {
                AssignGenerateProblems(button);
                button.Click += LevelPick;
                //button.Click += AnswersOnOffView;
                button.Click += AssignGenerateProblemsPreview;
                button.Click += ProblemSetType;
            }

            buttonHandPick.Click += HandPick;
            buttonHandPick.Click += AssignGenerateProblemsPreview;

            buttonProblemSetPick.Click += SetPick;
            buttonProblemSetPick.Click += AssignGenerateProblemsPreview;

            buttonAddProblem.Click += ProblemNumberCheck;

            buttonAnswersOnOff.Click += AnswersOnOff;

            buttonExit.Click += OnExitButtonClick;
            #endregion
            textBoxAmtOfPb.Text = "10";
            Parser = new ProblemChoiceParser();
            Problems = new List<string>();
            Answers = new List<string>();
            ButtonHtmlGenY = buttonPreviewGen.Location.Y;
            AnswersOn = true;
            AmountOfProblems = 0;
            LabelPointY = labelAmountOfProblems.Location.Y + 17;

            //info button handling
            roundButtonInfo.MouseHover += ShowHint;
            roundButtonInfo.MouseLeave += HideHint;

            //initial form size
            FormSize = this.Size;
            webBrowserPreview.Width += this.Width / 4;

            //Initializing controls lists for easier operations
            InitializeMainMenuControls();
            InitializeHandPickControls();
            InitializeLevelControls();
            InitializeProblemSetPickControls();

            //
            //buttonProblemSetLoad.Click += ProblemSetKeyTextBoxChecker;
            //buttonProblemSetLoad.Click += Preview;

            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            MainMenuControls.ForEach(x => x.Show());
        }



        #region Controls lists
        private List<Control> MainMenuControls;
        private List<Control> LevelControls;
        private List<Control> HandPickControls;
        private List<Control> ProblemSetPickControls;
        private void InitializeMainMenuControls()
        {
            var res = new List<Control>();
            res.Add(buttonLevel1);
            res.Add(buttonLevel2);
            res.Add(buttonLevel3);
            res.Add(buttonHandPick);
            res.Add(buttonProblemSetPick);
            MainMenuControls = res;
        }
        private void InitializeLevelControls()
        {
            var res = new List<Control>();
            res.Add(buttonAnswersOnOff);
            res.Add(buttonExit);
            res.Add(buttonSaveFile);
            res.Add(buttonPreviewGen);
            res.Add(textBoxAmtOfPb);
            res.Add(webBrowserPreview);
            res.Add(labelAmountOfProblems);
            res.Add(label1);
            LevelControls = res;
        }
        private void InitializeProblemSetPickControls()
        {
            var res = new List<Control>();
            res.Add(buttonAnswersOnOff);
            res.Add(buttonExit);
            res.Add(buttonSaveFile);
            res.Add(buttonPreviewGen);
            res.Add(textBoxProblemSetPick);
            res.Add(webBrowserPreview);
            res.Add(labelAmountOfProblems);
            res.Add(label1);
            //res.Add(buttonProblemSetLoad);
            ProblemSetPickControls = res;
        }
        private void InitializeHandPickControls()
        {
            var res = new List<Control>();
            res.Add(textBoxProblemNum);
            res.Add(labelListOfPbm);
            res.Add(labelProblemNumber);
            res.Add(buttonExit);
            res.Add(buttonAnswersOnOff);
            res.Add(webBrowserPreview);
            res.Add(buttonSaveFile);
            res.Add(roundButtonInfo);
            res.Add(label1);
            res.Add(buttonAddProblem);
            res.Add(buttonPreviewGen);
            HandPickControls = res;
        }
        #endregion

        private void Preview(object sender, EventArgs e)
        {
            string amount = null;
            if (labelProblemNumber.Visible || textBoxProblemSetPick.Visible)
            {
                HTML = new HtmlCustomWriter(Problems, Answers);
            }
            else
            {
                PickProblems(int.Parse(textBoxAmtOfPb.Text));
                amount = textBoxAmtOfPb.Text;
                ProblemSetKeyAssign(amount);
                HTML = new HtmlCustomWriter(Problems, Answers);
            }
            string htmlContent = AnswersOn ? HTML.PreviewTasksAnswers() : HTML.PreviewTasks();
            webBrowserPreview.DocumentText = htmlContent;
            label1.Text = "Предпросмотр списка заданий. Блок №" + ProblemSetKey;

            buttonSaveFile.Enabled = true;
        }

        private void AssignGenerateProblemsPreview(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "buttonLevel1":
                    buttonPreviewGen.Click += Level1ChoiceProblems;
                    buttonPreviewGen.Click += Preview;
                    break;
                case "buttonLevel2":
                    buttonPreviewGen.Click += Level2ChoiceProblems;
                    buttonPreviewGen.Click += Preview;
                    break;
                case "buttonLevel3":
                    buttonPreviewGen.Click += Level3ChoiceProblems;
                    buttonPreviewGen.Click += Preview;
                    break;
                case "buttonHandPick":
                    buttonPreviewGen.Click += Preview;
                    break;
                case "buttonProblemSetPick":
                    buttonPreviewGen.Click += ProblemSetKeyTextBoxChecker;
                    buttonPreviewGen.Click += Preview;
                    break;
            }
        }
        private void AssignGenerateProblems(Button b)
        {
            switch (b.Name)
            {
                case "buttonLevel1":
                    b.Click += Level1ChoiceProblems;
                    break;
                case "buttonLevel2":
                    b.Click += Level2ChoiceProblems;
                    break;
                case "buttonLevel3":
                    b.Click += Level3ChoiceProblems;
                    break;
            }
        }


        #region Properties
        private bool AnswersOn { get; set; }
        private List<string> Problems;
        private List<string> Answers;
        private int ButtonHtmlGenY { get; set; }
        private int LabelPointY { get; set; }
        private int ProblemSetSeed { get; set; }
        private Size FormSize { get; set; }
        readonly Random rng = new Random();
        private List<Button> LevelButtons { get; set; }
        private HtmlCustomWriter HTML { get; set; }
        ProblemChoiceParser Parser { get; set; }
        private bool Buttons { get; set; }
        private int AmountOfProblems { get; set; }
        private string FilePath { get; set; }
        #endregion

        private void OnExitButtonClick(object sender, EventArgs e) => MainMenu();

        #region Save file features
        private void ButtonSaveFileClick(object sender, EventArgs e)
        {
            if (labelListOfPbm.Visible == false)
            {
                int input;
                if (!int.TryParse((textBoxAmtOfPb.Text), out input) || input < 1 || input > 99)
                    MessageBox.Show("Введите число от 1 до 99");
                else
                {
                    SaveLoadInteraction(sender, e);
                }
            }
            else
            {
                SaveLoadInteraction(sender, e);
                MainMenu();
            }
        }
        private void SaveLoadInteraction(object sender, EventArgs e)
        {
            using (SaveFile form = new SaveFile())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string problems = CreateProblemsText();
                    bool val = form.SaveOrLoad;
                    if (val)
                    {
                        SaveFile(problems);
                        if (FilePath != null)
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
        #endregion


        #region Hand pick problem number checeker
        private bool LastDigitIsLevel(int num) => num == 1 || num == 2 || num == 3;
        private bool ProblemNumberChecker(string input) => input.Length != 4 ?
            false :
            !LastDigitIsLevel(int.Parse(input[3].ToString())) ?
            false :
            true;
        private void ProblemNumberCheck(object sender, EventArgs e)
        {
            string input = textBoxProblemNum.Text;
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
        #endregion

        #region answers on/off handling
        //private void AnswersOnOffView(object sender, EventArgs e) => buttonAnswersOnOff.Visible = !buttonAnswersOnOff.Visible;
        private void AnswersOnOff(object sender, EventArgs e)
        {
            buttonAnswersOnOff.Text = AnswersOn ? "Ответы выкл." : "Ответы вкл.";
            AnswersOn = !AnswersOn;
        }
        #endregion

        #region Level choice
        private void Level1ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel1(100);
        private void Level2ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel2(100);
        private void Level3ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel3(100);
        private void LevelPick(object sender, EventArgs e)
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            LevelControls.ForEach(x => x.Show());
            this.Size = new Size(this.Width * 5 / 4, this.Height);
            this.CenterToScreen();
            textBoxAmtOfPb.Focus();
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

        #region Hand pick problem choice interaction
        /// <summary>
        /// Genrates interface for the problem hand picking menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandPick(object sender, EventArgs e)
        {
            buttonPreviewGen.Enabled = false;
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            HandPickControls.ForEach(x => x.Show());
            this.Size = new Size(this.Width * 5 / 4, this.Height);
            this.CenterToScreen();
            textBoxProblemNum.Focus();
        }
        private string ProblemNumberInput()
        {
            string res = textBoxProblemNum.Text;
            textBoxProblemNum.Text = "";
            return res;
        }
        private void NewProblemLabel(string num)
        {
            Label problemNumber = new Label
            {
                Location = new Point(labelListOfPbm.Location.X,
                labelListOfPbm.Location.Y + LabelPointY),
                Text = num,
                BackColor = Color.White
            };
            Controls.Add(problemNumber);
            LabelPointY += 20;
        }
        private void AddNewProblem(object sender, EventArgs e)
        {
            string problemNum = ProblemNumberInput();
            Problem pb = Parser.Parse(problemNum);
            pb.GenerateProblemExpression();
            Problems.Add(pb.HtmlFormula);
            Answers.Add(pb.DisplayAnswers());
            NewProblemLabel(problemNum);
            buttonPreviewGen.Enabled = true;
        }
        #endregion

        private string CreateProblemsText()
        {
            return AnswersOn ? HTML.ShowTasksAnswers(ProblemSetKey) : HTML.ShowTasks(ProblemSetKey);
        }
        private void PickProblems(int n)
        {
            List<string> selectedProblems = new List<string>();
            List<string> correspondingAsnwers = new List<string>();
            ProblemSetSeed = rng.Next(0, 100);
            Random rng2 = new Random(92);
            for (int i = 0; i < n; i++)
            {
                int pos = rng2.Next(0, Problems.Count);
                selectedProblems.Add(Problems[pos]);
                correspondingAsnwers.Add(Answers[pos]);
                Problems.RemoveAt(pos);
                Answers.RemoveAt(pos);
            }
            Problems = selectedProblems;
            Answers = correspondingAsnwers;
        }

        private void HtmlLaunch() => System.Diagnostics.Process.Start(FilePath);

        #region Hint display
        private void ShowHint(object sender, EventArgs e) => labelHintHandPick.Show();
        private void HideHint(object sender, EventArgs e) => labelHintHandPick.Hide();
        #endregion



        private void MainMenu()
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            MainMenuControls.ForEach(x => x.Show());
            Problems = new List<string>();
            Answers = new List<string>();
            buttonAddProblem.Enabled = true;
            buttonPreviewGen.Enabled = true;
            buttonSaveFile.Enabled = false;
            label1.Text = "Предпросмотр списка заданий";

            LabelPointY = labelListOfPbm.Location.Y + 17;
            FilePath = null;
            this.Size = FormSize;
            webBrowserPreview.DocumentText = "";
            this.CenterToScreen();
            ResetPreviewButton();
        }
        private void ResetPreviewButton()
        {
            buttonPreviewGen.Click -= Level1ChoiceProblems;
            buttonPreviewGen.Click -= Level2ChoiceProblems;
            buttonPreviewGen.Click -= Level3ChoiceProblems;
            buttonPreviewGen.Click -= ProblemSetKeyTextBoxChecker;
            buttonPreviewGen.Click -= Preview;

        }



        #region Restore problem set by number
        private string ProblemSetKey { get; set; }
        private void ProblemSetType(object sender, EventArgs e)
        {
            int type = 0;
            switch ((sender as Button).Name)
            {
                case "buttonLevel1":
                    type = 1;
                    break;
                case "buttonLevel2":
                    type = 2;
                    break;
                case "buttonLevel3":
                    type = 3;
                    break;
                case "buttonMixedSet":
                    type = 4;
                    break;
            }
            ProblemSetKey = type.ToString();
        }
        private void ProblemSetKeyAssign(string amount) => ProblemSetKey = ProblemSetKey.Length == 1 ?
            ProblemSetKey + ProblemSetSeed.ToString().PadLeft(2, '0') + amount :
            ProblemSetKey[0] + ProblemSetSeed.ToString().PadLeft(2, '0') + amount;
        private void ProblemSetKeyTextBoxChecker(object sender, EventArgs e)
        {
            string key = textBoxProblemSetPick.Text;
            if (int.TryParse(key, out int k) && ProblemSetKeyChecker(key))
            {
                ProblemSetAssignProblems(key);
                ProblemSetKey = key;
                textBoxProblemSetPick.Text = "";
                textBoxProblemSetPick.Focus();
            }
            else
            {
                textBoxProblemSetPick.Text = "";
                textBoxProblemSetPick.Focus();
            }
        }
        private bool ProblemSetKeyChecker(string key)
        {
            if (key.Length > 5)
            {
                MessageBox.Show("Длина ключа не соответвует формату набора");
            }
            if (key[0] > '4' || key[0] < '1')
            {
                MessageBox.Show("Первая цифра не соответсвует формату набора");
                return false;
            }
            return true;
        }

        private void ProblemSetAssignProblems(string key)
        {
            Parser.ParseProblemSet(key);
            Problems = Parser.ProblemsAnswers.Item1;
            Answers = Parser.ProblemsAnswers.Item2;
        }

        private void SetPick(object sender, EventArgs e)
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            ProblemSetPickControls.ForEach(x => x.Show());
            this.Size = new Size(this.Width * 5 / 4, this.Height);
            this.CenterToScreen();
        }
        #endregion

    }
}
