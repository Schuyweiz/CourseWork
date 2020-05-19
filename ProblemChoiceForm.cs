using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
                AssignLevelProblems(button);
                button.Click += LevelMenu;
                //button.Click += AnswersOnOffView;
                button.Click += AssignGenerateProblemsPreview;
                button.Click += ProblemSetType;
            }

            buttonHandPick.Click += HandPickMenu;
            buttonHandPick.Click += AssignGenerateProblemsPreview;
            buttonAddProblem.Click += ProblemNumberCheck;

            buttonProblemSetPick.Click += SetPickMenu;
            buttonProblemSetPick.Click += AssignGenerateProblemsPreview;

            buttonMixedProblems.Click += MixedProblemsMenu;
            buttonMixedProblems.Click += AssignGenerateProblemsPreview;
            buttonMixedProblems.Click += ProblemSetType;

            buttonAnswersOnOff.Click += AnswersOnOff;
            buttonExit.Click += OnExitButtonClick;
            #endregion
            Parser = new ProblemKeyParser();
            Problems = new List<string>();
            Answers = new List<string>();
            //ButtonHtmlGenY = buttonPreviewGen.Location.Y;
            AnswersOn = true;
            AmountOfProblems = 0;
            LabelPointY = labelAmountOfProblems.Location.Y + 17;

            //info button handling
            roundButtonInfo.MouseHover += ShowHint;
            roundButtonInfo.MouseLeave += HideHint;

            //initial form size
            FormSizeProblems = this.Size;

            //Initializing controls lists for easier operations
            InitializeMainMenuControls();
            InitializeHandPickControls();
            InitializeLevelControls();
            InitializeProblemSetPickControls();
            InitializeMixedProblemsControls();

            //
            this.Size = new Size(300, 240);
            FormSizeMainMenu = this.Size;
            var tempButtons = new List<Button>() { buttonHandPick, buttonProblemSetPick, buttonMixedProblems };
            for (int i = 0; i < LevelButtons.Count; i++)
            {
                LevelButtons[i].Location = new Point(35, i * 60 + 10);
                tempButtons[i].Location = new Point(145, i * 60 + 10);
            }
            this.CenterToScreen();



            foreach (var tb in Controls.OfType<TextBox>())
                tb.KeyDown += TextBoxEnter;



            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            MainMenuControls.ForEach(x => x.Show());
        }

        

        private void TextBoxEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (CurrentMenu)
                {
                    case "Level 1":
                    case "Level 2":
                    case "Level 3":
                        LevelTextBoxChecker(sender, e);
                        break;
                    case "Hand pick":
                        ProblemNumberCheck(sender, e);
                        break;
                    case "Set":
                        ProblemSetKeyTextBoxChecker(sender, e);
                        //Preview(sender, e);
                        break;
                    case "Mix":
                        GeneratedMixedProblemsSet(sender, e);
                        MixedProblemsTextBoxChecker(sender, e);
                        break;
                }
            }
        }

        private string CurrentMenu { get; set; }
        private bool Header { get; set; }



        #region Controls lists
        private List<Control> MainMenuControls { get; set; }
        private List<Control> LevelControls { get; set; }
        private List<Control> HandPickControls { get; set; }
        private List<Control> ProblemSetPickControls { get; set; }
        private List<Control> MixedProblemsControls { get; set; }
        private void InitializeMainMenuControls()
        {
            var res = new List<Control>();
            res.Add(buttonLevel1);
            res.Add(buttonLevel2);
            res.Add(buttonLevel3);
            res.Add(buttonHandPick);
            res.Add(buttonProblemSetPick);
            res.Add(buttonMixedProblems);
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
            res.Add(labelSetKeyPreviewl);
            res.Add(roundButtonInfo);
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
            res.Add(labelSetPick);
            res.Add(roundButtonInfo);
            res.Add(labelSetKeyPreviewl);
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
            res.Add(labelSetKeyPreviewl);
            res.Add(roundButtonInfo);
            res.Add(buttonAddProblem);
            res.Add(buttonPreviewGen);
            HandPickControls = res;
        }
        private void InitializeMixedProblemsControls()
        {
            var res = new List<Control>();
            res.Add(buttonAnswersOnOff);
            res.Add(buttonExit);
            res.Add(buttonSaveFile);
            res.Add(buttonPreviewGen);
            res.Add(textBoxAmtOfPb);
            res.Add(webBrowserPreview);
            res.Add(labelAmountOfProblems);
            res.Add(roundButtonInfo);
            res.Add(labelSetKeyPreviewl);
            MixedProblemsControls = res;
        }
        #endregion

        #region generating problems and preview
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
                labelSetKeyPreviewl.Text = "Предпросмотр списка заданий. Блок №" + ProblemSetKey;
            }
            string htmlContent = AnswersOn ? HTML.PreviewTasksAnswers() : HTML.PreviewTasks();
            webBrowserPreview.DocumentText = htmlContent;

            buttonSaveFile.Enabled = true;
        }
        private void AssignGenerateProblemsPreview(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "buttonLevel1":
                    buttonPreviewGen.Click += Level1ChoiceProblems;
                    buttonPreviewGen.Click += LevelTextBoxChecker;
                    CurrentMenu = "Level 1";
                    Header = true;
                    break;
                case "buttonLevel2":
                    buttonPreviewGen.Click += Level2ChoiceProblems;
                    buttonPreviewGen.Click += LevelTextBoxChecker;
                    CurrentMenu = "Level 2";
                    Header = true;
                    break;
                case "buttonLevel3":
                    buttonPreviewGen.Click += Level3ChoiceProblems;
                    buttonPreviewGen.Click += LevelTextBoxChecker;
                    CurrentMenu = "Level 3";
                    Header = true;
                    break;
                case "buttonHandPick":
                    buttonPreviewGen.Click += Preview;
                    CurrentMenu = "Hand pick";
                    Header = false;
                    break;
                case "buttonProblemSetPick":
                    buttonPreviewGen.Click += ProblemSetKeyTextBoxChecker;
                    CurrentMenu = "Set";
                    Header = true;
                    break;
                case "buttonMixedProblems":
                    buttonPreviewGen.Click += GeneratedMixedProblemsSet;
                    buttonPreviewGen.Click += MixedProblemsTextBoxChecker;
                    CurrentMenu = "Mix";
                    Header = true;
                    break;
            }
        }
        private void PickProblems(int n)
        {
            List<string> selectedProblems = new List<string>();
            List<string> correspondingAsnwers = new List<string>();
            ProblemSetSeed = rng.Next(0, 100);
            Random rng2 = new Random(ProblemSetSeed);
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
        private string CreateProblemsText(bool header)
        {
            return AnswersOn ? HTML.ShowTasksAnswers(ProblemSetKey,header) : HTML.ShowTasks(ProblemSetKey,header);
        }
        #endregion

        #region Properties
        private bool AnswersOn { get; set; }
        private List<string> Problems { get; set; }
        private List<string> Answers { get; set; }
        //private int ButtonHtmlGenY { get; set; }
        private int LabelPointY { get; set; }
        private int ProblemSetSeed { get; set; }
        private Size FormSizeProblems { get; set; }
        private Size FormSizeMainMenu { get; set; }
        readonly Random rng = new Random();
        private List<Button> LevelButtons { get; set; }
        private HtmlCustomWriter HTML { get; set; }
        ProblemKeyParser Parser { get; set; }
        private bool Buttons { get; set; }
        private int AmountOfProblems { get; set; }
        private string FilePath { get; set; }
        #endregion


        #region Save file features
        private void ButtonSaveFileClick(object sender, EventArgs e)
        {
                SaveLoadInteraction(sender, e);
                MainMenu();
        }
        private void SaveLoadInteraction(object sender, EventArgs e)
        {
            using (SaveFile form = new SaveFile())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string problems = CreateProblemsText(Header);
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
            {
                ResetTextboxContent(textBoxProblemNum);
                MessageBox.Show("Введите четырёхзначный ключ задачи");
            }
            else if (!ProblemNumberChecker(input))
            {
                ResetTextboxContent(textBoxProblemNum);
                MessageBox.Show("Задачи с таким ключом не существует");
            }
            else
            {
                AddNewProblem(sender, e);
                ResetTextboxContent(textBoxProblemNum);
            }
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
        private void AssignLevelProblems(Button b)
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
        private void Level1ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel1(100);
        private void Level2ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel2(100);
        private void Level3ChoiceProblems(object sender, EventArgs e) => GenerateTasksLevel3(100);
        private void LevelMenu(object sender, EventArgs e)
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            LevelControls.ForEach(x => x.Show());
            this.Size = FormSizeProblems;
            this.CenterToScreen();
            textBoxAmtOfPb.Focus();
        }
        private void LevelTextBoxChecker(object sender, EventArgs e)
        {
            string input = textBoxAmtOfPb.Text;
            int intInput;
            if (int.TryParse(input, out intInput) && intInput > 0 && intInput < 100)
                Preview(sender, e);
            else
            {
                ResetTextboxContent(textBoxAmtOfPb);
                MessageBox.Show("Неверный формат ввода");
            }
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
        private void HandPickMenu(object sender, EventArgs e)
        {
            buttonPreviewGen.Enabled = false;
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            HandPickControls.ForEach(x => x.Show());
            this.Size = FormSizeProblems;
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
            if (AmountOfProblems < 11)
            {
                string problemNum = ProblemNumberInput();
                Problem pb = Parser.Parse(problemNum);
                pb.GenerateProblemExpression();
                Problems.Add(pb.HtmlFormula);
                Answers.Add(pb.DisplayAnswers());
                NewProblemLabel(problemNum);
                buttonPreviewGen.Enabled = true;
                AmountOfProblems++;
            }
            else
            {
                MessageBox.Show("Максимальное количество задач достигнуто");
                ResetTextboxContent(textBoxProblemNum);
            }
        }
        #endregion

        #region Hint display
        private void ShowHint(object sender, EventArgs e)
        {
            foreach (Label label in Controls.OfType<Label>())
            {
                if (label.Name.Contains("Hint") && textBoxProblemNum.Visible == true)
                    label.Show();
                else if (label.Name.Contains("Hint") && label != labelHintHandPick&& label!= labelHintAddProblem)
                {
                    label.Show();
                }
            }
        }
        private void HideHint(object sender, EventArgs e)
        {
            foreach (Label label in Controls.OfType<Label>())
            {
                if (label.Name.Contains("Hint"))
                    label.Hide();
            }
        }
        #endregion


        private void OnExitButtonClick(object sender, EventArgs e) => MainMenu();
        private void HtmlLaunch() => System.Diagnostics.Process.Start(FilePath);

        private void MainMenu()
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            MainMenuControls.ForEach(x => x.Show());
            Problems = new List<string>();
            Answers = new List<string>();
            buttonAddProblem.Enabled = true;
            buttonPreviewGen.Enabled = true;
            buttonSaveFile.Enabled = false;
            labelSetKeyPreviewl.Text = "Предпросмотр списка заданий";
            foreach (TextBox box in Controls.OfType<TextBox>())
                box.Text = "";
            LabelPointY = labelListOfPbm.Location.Y + 17;
            FilePath = null;
            this.Size = FormSizeMainMenu;
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
                case "buttonMixedProblems":
                    type = 4;
                    break;
            }
            ProblemSetKey = type.ToString();
        }
        private void ProblemSetKeyAssign(string amount) => ProblemSetKey = ProblemSetKey.Length == 1 ?
            ProblemSetKey + ProblemSetSeed.ToString().PadLeft(2, '0') + amount.PadLeft(2,'0') :
            ProblemSetKey[0] + ProblemSetSeed.ToString().PadLeft(2, '0') + amount.PadLeft(2,'0');
        private void ProblemSetKeyTextBoxChecker(object sender, EventArgs e)
        {
            string key = textBoxProblemSetPick.Text;
            if (int.TryParse(key, out int k) && ProblemSetKeyChecker(key))
            {
                ProblemSetAssignProblems(key);
                ProblemSetKey = key;
                Preview(sender, e);
                textBoxProblemSetPick.Text = "";
                textBoxProblemSetPick.Focus();
            }
            else if (key == "")
            {
                MessageBox.Show("Поле ввода пустое");
            }
            else if (!int.TryParse(key, out int d))
            {
                MessageBox.Show("Неверный формат ввода");
                ResetTextboxContent(textBoxProblemSetPick);
            }
            else
                ResetTextboxContent(textBoxProblemSetPick);
        }
        private bool ProblemSetKeyChecker(string key)
        {
            if (key.Length != 5)
            {
                MessageBox.Show("Длина ключа не соответвует формату набора");
                return false;
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

        private void SetPickMenu(object sender, EventArgs e)
        {
            Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            ProblemSetPickControls.ForEach(x => x.Show());
            this.Size = FormSizeProblems;
            this.CenterToScreen();
            textBoxProblemSetPick.Focus();
        }
        #endregion

        private void ResetTextboxContent(TextBox text)
        {
            text.Text = "";
            text.Focus();
        }

        #region Mixed problems
        private void MixedProblemsMenu(object sender, EventArgs e)
        {
            this.Controls.Cast<Control>().ToList().ForEach(x => x.Hide());
            MixedProblemsControls.ForEach(x => x.Show());
            this.Size = FormSizeProblems;
            this.Width += 50;
            this.CenterToScreen();
            textBoxAmtOfPb.Focus();
        }

        private void MixedProblemsTextBoxChecker(object sender, EventArgs e)
        {
            string input = textBoxAmtOfPb.Text;
            int intInput;

            if (int.TryParse(input, out intInput) && intInput > 0 && intInput < 100)
            {
                Preview(sender, e);
                ResetTextboxContent(textBoxAmtOfPb);
            }
            else if (!int.TryParse(input, out intInput))
            {
                ResetTextboxContent(textBoxAmtOfPb);
                MessageBox.Show("Введите числовое значение");
            }
            else
            {
                ResetTextboxContent(textBoxAmtOfPb);
                MessageBox.Show("Значение должно быть от 1 до 99");
            }
        }
        private void GeneratedMixedProblemsSet(object sender, EventArgs e)
        {
            List<string> problems = new List<string>();
            List<string> answers = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                List<Problem> tasks = new List<Problem>() { new Level1(i), new Level2(i), new Level3(i) };
                foreach (var task in tasks)
                {
                    task.GenerateProblemExpression();
                    problems.Add(task.HtmlFormula);
                    answers.Add(task.DisplayAnswers());
                }

                Problems = problems;
                Answers = answers;
            }
        }
        #endregion
    }
}
