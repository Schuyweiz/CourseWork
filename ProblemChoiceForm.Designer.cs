namespace Coursework5
{
    partial class ProblemChoiceForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProblemChoiceForm));
            this.buttonPreviewGen = new System.Windows.Forms.Button();
            this.buttonHandPick = new System.Windows.Forms.Button();
            this.buttonLevel1 = new System.Windows.Forms.Button();
            this.buttonLevel2 = new System.Windows.Forms.Button();
            this.buttonLevel3 = new System.Windows.Forms.Button();
            this.buttonAddProblem = new System.Windows.Forms.Button();
            this.textBoxAmtOfPb = new System.Windows.Forms.TextBox();
            this.labelAmountOfProblems = new System.Windows.Forms.Label();
            this.labelProblemNumber = new System.Windows.Forms.Label();
            this.textBoxProblemNum = new System.Windows.Forms.TextBox();
            this.labelListOfPbm = new System.Windows.Forms.Label();
            this.buttonAnswersOnOff = new System.Windows.Forms.Button();
            this.labelHintHandPick = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.webBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.labelSetKeyPreviewl = new System.Windows.Forms.Label();
            this.buttonProblemSetPick = new System.Windows.Forms.Button();
            this.textBoxProblemSetPick = new System.Windows.Forms.TextBox();
            this.buttonMixedProblems = new System.Windows.Forms.Button();
            this.labelHintPreview = new System.Windows.Forms.Label();
            this.labelHintSaveFile = new System.Windows.Forms.Label();
            this.labelHintAddProblem = new System.Windows.Forms.Label();
            this.labelSetPick = new System.Windows.Forms.Label();
            this.roundButtonInfo = new Coursework5.HintButton();
            this.labelHintPreviewHandPick = new System.Windows.Forms.Label();
            this.labelHintProblemsInput = new System.Windows.Forms.Label();
            this.labelHintSetRestoreInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPreviewGen
            // 
            this.buttonPreviewGen.Image = ((System.Drawing.Image)(resources.GetObject("buttonPreviewGen.Image")));
            this.buttonPreviewGen.Location = new System.Drawing.Point(15, 196);
            this.buttonPreviewGen.Name = "buttonPreviewGen";
            this.buttonPreviewGen.Size = new System.Drawing.Size(99, 45);
            this.buttonPreviewGen.TabIndex = 0;
            this.buttonPreviewGen.UseVisualStyleBackColor = true;
            // 
            // buttonHandPick
            // 
            this.buttonHandPick.Location = new System.Drawing.Point(400, 325);
            this.buttonHandPick.Name = "buttonHandPick";
            this.buttonHandPick.Size = new System.Drawing.Size(100, 50);
            this.buttonHandPick.TabIndex = 1;
            this.buttonHandPick.Text = "Составить  по номерам";
            this.buttonHandPick.UseVisualStyleBackColor = true;
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLevel1.Location = new System.Drawing.Point(350, 25);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(100, 50);
            this.buttonLevel1.TabIndex = 2;
            this.buttonLevel1.Text = "Уровень 1";
            this.buttonLevel1.UseVisualStyleBackColor = false;
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonLevel2.Location = new System.Drawing.Point(350, 125);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(100, 50);
            this.buttonLevel2.TabIndex = 3;
            this.buttonLevel2.Text = "Уровень 2";
            this.buttonLevel2.UseVisualStyleBackColor = false;
            // 
            // buttonLevel3
            // 
            this.buttonLevel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonLevel3.Location = new System.Drawing.Point(350, 225);
            this.buttonLevel3.Name = "buttonLevel3";
            this.buttonLevel3.Size = new System.Drawing.Size(100, 50);
            this.buttonLevel3.TabIndex = 4;
            this.buttonLevel3.Text = "Уровень 3";
            this.buttonLevel3.UseVisualStyleBackColor = false;
            // 
            // buttonAddProblem
            // 
            this.buttonAddProblem.Location = new System.Drawing.Point(14, 75);
            this.buttonAddProblem.Name = "buttonAddProblem";
            this.buttonAddProblem.Size = new System.Drawing.Size(100, 33);
            this.buttonAddProblem.TabIndex = 5;
            this.buttonAddProblem.Text = "Добавить";
            this.buttonAddProblem.UseVisualStyleBackColor = true;
            // 
            // textBoxAmtOfPb
            // 
            this.textBoxAmtOfPb.Location = new System.Drawing.Point(15, 33);
            this.textBoxAmtOfPb.Name = "textBoxAmtOfPb";
            this.textBoxAmtOfPb.Size = new System.Drawing.Size(100, 22);
            this.textBoxAmtOfPb.TabIndex = 6;
            // 
            // labelAmountOfProblems
            // 
            this.labelAmountOfProblems.AutoSize = true;
            this.labelAmountOfProblems.Location = new System.Drawing.Point(12, 9);
            this.labelAmountOfProblems.Name = "labelAmountOfProblems";
            this.labelAmountOfProblems.Size = new System.Drawing.Size(129, 17);
            this.labelAmountOfProblems.TabIndex = 7;
            this.labelAmountOfProblems.Text = "Количество задач";
            // 
            // labelProblemNumber
            // 
            this.labelProblemNumber.AutoSize = true;
            this.labelProblemNumber.Location = new System.Drawing.Point(12, 9);
            this.labelProblemNumber.Name = "labelProblemNumber";
            this.labelProblemNumber.Size = new System.Drawing.Size(159, 17);
            this.labelProblemNumber.TabIndex = 8;
            this.labelProblemNumber.Text = "Введите номер задачи";
            // 
            // textBoxProblemNum
            // 
            this.textBoxProblemNum.Location = new System.Drawing.Point(14, 33);
            this.textBoxProblemNum.Name = "textBoxProblemNum";
            this.textBoxProblemNum.Size = new System.Drawing.Size(102, 22);
            this.textBoxProblemNum.TabIndex = 9;
            // 
            // labelListOfPbm
            // 
            this.labelListOfPbm.AutoSize = true;
            this.labelListOfPbm.Location = new System.Drawing.Point(191, 9);
            this.labelListOfPbm.Name = "labelListOfPbm";
            this.labelListOfPbm.Size = new System.Drawing.Size(102, 17);
            this.labelListOfPbm.TabIndex = 10;
            this.labelListOfPbm.Text = "Список задач:";
            // 
            // buttonAnswersOnOff
            // 
            this.buttonAnswersOnOff.Location = new System.Drawing.Point(14, 114);
            this.buttonAnswersOnOff.Name = "buttonAnswersOnOff";
            this.buttonAnswersOnOff.Size = new System.Drawing.Size(100, 64);
            this.buttonAnswersOnOff.TabIndex = 11;
            this.buttonAnswersOnOff.Text = "Ответы вкл.";
            this.buttonAnswersOnOff.UseVisualStyleBackColor = true;
            this.buttonAnswersOnOff.Visible = false;
            // 
            // labelHintHandPick
            // 
            this.labelHintHandPick.AutoSize = true;
            this.labelHintHandPick.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintHandPick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintHandPick.Location = new System.Drawing.Point(120, 114);
            this.labelHintHandPick.Name = "labelHintHandPick";
            this.labelHintHandPick.Size = new System.Drawing.Size(204, 104);
            this.labelHintHandPick.TabIndex = 12;
            this.labelHintHandPick.Text = "Ключи задач имеют \r\nчетырёхзначный номер\r\nи оканчиваются на 1,2 или 3.\r\nВ список " +
    "можно добавить\r\nдо 10 задач.\r\nПример: 0112";
            this.labelHintHandPick.Visible = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(15, 387);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(99, 54);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "выйти";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.Location = new System.Drawing.Point(350, 29);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(742, 407);
            this.webBrowserPreview.TabIndex = 15;
            this.webBrowserPreview.Visible = false;
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Enabled = false;
            this.buttonSaveFile.Location = new System.Drawing.Point(15, 300);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(99, 49);
            this.buttonSaveFile.TabIndex = 16;
            this.buttonSaveFile.Text = "Сохранить";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Visible = false;
            // 
            // labelSetKeyPreviewl
            // 
            this.labelSetKeyPreviewl.AutoSize = true;
            this.labelSetKeyPreviewl.Location = new System.Drawing.Point(347, 8);
            this.labelSetKeyPreviewl.Name = "labelSetKeyPreviewl";
            this.labelSetKeyPreviewl.Size = new System.Drawing.Size(197, 17);
            this.labelSetKeyPreviewl.TabIndex = 17;
            this.labelSetKeyPreviewl.Text = "Предпросмотр списка задач";
            // 
            // buttonProblemSetPick
            // 
            this.buttonProblemSetPick.Location = new System.Drawing.Point(180, 348);
            this.buttonProblemSetPick.Name = "buttonProblemSetPick";
            this.buttonProblemSetPick.Size = new System.Drawing.Size(100, 50);
            this.buttonProblemSetPick.TabIndex = 18;
            this.buttonProblemSetPick.Text = "Выбрать номер блока";
            this.buttonProblemSetPick.UseVisualStyleBackColor = true;
            // 
            // textBoxProblemSetPick
            // 
            this.textBoxProblemSetPick.Location = new System.Drawing.Point(14, 33);
            this.textBoxProblemSetPick.Name = "textBoxProblemSetPick";
            this.textBoxProblemSetPick.Size = new System.Drawing.Size(100, 22);
            this.textBoxProblemSetPick.TabIndex = 19;
            // 
            // buttonMixedProblems
            // 
            this.buttonMixedProblems.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonMixedProblems.Location = new System.Drawing.Point(244, 277);
            this.buttonMixedProblems.Name = "buttonMixedProblems";
            this.buttonMixedProblems.Size = new System.Drawing.Size(100, 50);
            this.buttonMixedProblems.TabIndex = 20;
            this.buttonMixedProblems.Text = "Разные задачи";
            this.buttonMixedProblems.UseVisualStyleBackColor = false;
            // 
            // labelHintPreview
            // 
            this.labelHintPreview.AutoSize = true;
            this.labelHintPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintPreview.Location = new System.Drawing.Point(90, 225);
            this.labelHintPreview.Name = "labelHintPreview";
            this.labelHintPreview.Size = new System.Drawing.Size(171, 70);
            this.labelHintPreview.TabIndex = 21;
            this.labelHintPreview.Text = "Обновление \r\nпредпросмотра\r\nсписка задач\r\n(Можно нажатием Enter)";
            this.labelHintPreview.Visible = false;
            // 
            // labelHintSaveFile
            // 
            this.labelHintSaveFile.AutoSize = true;
            this.labelHintSaveFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintSaveFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintSaveFile.Location = new System.Drawing.Point(87, 316);
            this.labelHintSaveFile.Name = "labelHintSaveFile";
            this.labelHintSaveFile.Size = new System.Drawing.Size(118, 70);
            this.labelHintSaveFile.TabIndex = 22;
            this.labelHintSaveFile.Text = "Сохранить файл\r\nна компьютер \r\nв формате\r\nHTML";
            // 
            // labelHintAddProblem
            // 
            this.labelHintAddProblem.AutoSize = true;
            this.labelHintAddProblem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintAddProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintAddProblem.Location = new System.Drawing.Point(97, 75);
            this.labelHintAddProblem.Name = "labelHintAddProblem";
            this.labelHintAddProblem.Size = new System.Drawing.Size(188, 36);
            this.labelHintAddProblem.TabIndex = 23;
            this.labelHintAddProblem.Text = "Добавить задачу в список \r\n(можно нажатием Enter)";
            // 
            // labelSetPick
            // 
            this.labelSetPick.AutoSize = true;
            this.labelSetPick.Location = new System.Drawing.Point(11, 8);
            this.labelSetPick.Name = "labelSetPick";
            this.labelSetPick.Size = new System.Drawing.Size(151, 17);
            this.labelSetPick.TabIndex = 24;
            this.labelSetPick.Text = "Введите номер блока";
            // 
            // roundButtonInfo
            // 
            this.roundButtonInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundButtonInfo.FlatAppearance.BorderSize = 0;
            this.roundButtonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("roundButtonInfo.Image")));
            this.roundButtonInfo.Location = new System.Drawing.Point(121, 33);
            this.roundButtonInfo.Name = "roundButtonInfo";
            this.roundButtonInfo.Size = new System.Drawing.Size(22, 22);
            this.roundButtonInfo.TabIndex = 14;
            this.roundButtonInfo.Text = "infoButton";
            this.roundButtonInfo.UseVisualStyleBackColor = false;
            this.roundButtonInfo.Visible = false;
            // 
            // labelHintPreviewHandPick
            // 
            this.labelHintPreviewHandPick.AutoSize = true;
            this.labelHintPreviewHandPick.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintPreviewHandPick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintPreviewHandPick.Location = new System.Drawing.Point(90, 225);
            this.labelHintPreviewHandPick.Name = "labelHintPreviewHandPick";
            this.labelHintPreviewHandPick.Size = new System.Drawing.Size(117, 53);
            this.labelHintPreviewHandPick.TabIndex = 25;
            this.labelHintPreviewHandPick.Text = "Обновление \r\nпредпросмотра \r\nсписка задач";
            // 
            // labelHintProblemsInput
            // 
            this.labelHintProblemsInput.AutoSize = true;
            this.labelHintProblemsInput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintProblemsInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintProblemsInput.Location = new System.Drawing.Point(164, 37);
            this.labelHintProblemsInput.Name = "labelHintProblemsInput";
            this.labelHintProblemsInput.Size = new System.Drawing.Size(147, 36);
            this.labelHintProblemsInput.TabIndex = 26;
            this.labelHintProblemsInput.Text = "Нужно ввести число \r\nот 1 до 99 ";
            // 
            // labelHintSetRestoreInput
            // 
            this.labelHintSetRestoreInput.AutoSize = true;
            this.labelHintSetRestoreInput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHintSetRestoreInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHintSetRestoreInput.Location = new System.Drawing.Point(151, 73);
            this.labelHintSetRestoreInput.Name = "labelHintSetRestoreInput";
            this.labelHintSetRestoreInput.Size = new System.Drawing.Size(216, 70);
            this.labelHintSetRestoreInput.TabIndex = 27;
            this.labelHintSetRestoreInput.Text = "Нужно ввести пятизначный \r\nключ блока задач.\r\nКлюч обязательно начинается\r\nна 1,2" +
    ",3 или 4";
            // 
            // ProblemChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1131, 453);
            this.Controls.Add(this.labelHintSetRestoreInput);
            this.Controls.Add(this.labelHintProblemsInput);
            this.Controls.Add(this.labelHintPreviewHandPick);
            this.Controls.Add(this.labelSetPick);
            this.Controls.Add(this.labelHintAddProblem);
            this.Controls.Add(this.labelHintSaveFile);
            this.Controls.Add(this.labelHintPreview);
            this.Controls.Add(this.buttonMixedProblems);
            this.Controls.Add(this.textBoxProblemSetPick);
            this.Controls.Add(this.buttonProblemSetPick);
            this.Controls.Add(this.labelSetKeyPreviewl);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.webBrowserPreview);
            this.Controls.Add(this.roundButtonInfo);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelHintHandPick);
            this.Controls.Add(this.buttonAnswersOnOff);
            this.Controls.Add(this.labelListOfPbm);
            this.Controls.Add(this.textBoxProblemNum);
            this.Controls.Add(this.labelProblemNumber);
            this.Controls.Add(this.labelAmountOfProblems);
            this.Controls.Add(this.textBoxAmtOfPb);
            this.Controls.Add(this.buttonAddProblem);
            this.Controls.Add(this.buttonLevel3);
            this.Controls.Add(this.buttonLevel2);
            this.Controls.Add(this.buttonLevel1);
            this.Controls.Add(this.buttonHandPick);
            this.Controls.Add(this.buttonPreviewGen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProblemChoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPreviewGen;
        private System.Windows.Forms.Button buttonHandPick;
        private System.Windows.Forms.Button buttonLevel1;
        private System.Windows.Forms.Button buttonLevel2;
        private System.Windows.Forms.Button buttonLevel3;
        private System.Windows.Forms.Button buttonAddProblem;
        private System.Windows.Forms.TextBox textBoxAmtOfPb;
        private System.Windows.Forms.Label labelAmountOfProblems;
        private System.Windows.Forms.Label labelProblemNumber;
        private System.Windows.Forms.TextBox textBoxProblemNum;
        private System.Windows.Forms.Label labelListOfPbm;
        private System.Windows.Forms.Button buttonAnswersOnOff;
        private System.Windows.Forms.Label labelHintHandPick;
        private System.Windows.Forms.Button buttonExit;
        private HintButton roundButtonInfo;
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Label labelSetKeyPreviewl;
        private System.Windows.Forms.Button buttonProblemSetPick;
        private System.Windows.Forms.TextBox textBoxProblemSetPick;
        private System.Windows.Forms.Button buttonMixedProblems;
        private System.Windows.Forms.Label labelHintPreview;
        private System.Windows.Forms.Label labelHintSaveFile;
        private System.Windows.Forms.Label labelHintAddProblem;
        private System.Windows.Forms.Label labelSetPick;
        private System.Windows.Forms.Label labelHintPreviewHandPick;
        private System.Windows.Forms.Label labelHintProblemsInput;
        private System.Windows.Forms.Label labelHintSetRestoreInput;
    }
}

