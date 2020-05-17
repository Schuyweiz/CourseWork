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
            this.label1 = new System.Windows.Forms.Label();
            this.roundButtonInfo = new Coursework5.RoundButton();
            this.SuspendLayout();
            // 
            // buttonPreviewGen
            // 
            this.buttonPreviewGen.Image = ((System.Drawing.Image)(resources.GetObject("buttonPreviewGen.Image")));
            this.buttonPreviewGen.Location = new System.Drawing.Point(14, 196);
            this.buttonPreviewGen.Name = "buttonPreviewGen";
            this.buttonPreviewGen.Size = new System.Drawing.Size(100, 45);
            this.buttonPreviewGen.TabIndex = 0;
            this.buttonPreviewGen.UseVisualStyleBackColor = true;
            // 
            // buttonHandPick
            // 
            this.buttonHandPick.Location = new System.Drawing.Point(350, 376);
            this.buttonHandPick.Name = "buttonHandPick";
            this.buttonHandPick.Size = new System.Drawing.Size(100, 69);
            this.buttonHandPick.TabIndex = 1;
            this.buttonHandPick.Text = "Составить  по номерам";
            this.buttonHandPick.UseVisualStyleBackColor = true;
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLevel1.Location = new System.Drawing.Point(350, 30);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(100, 50);
            this.buttonLevel1.TabIndex = 2;
            this.buttonLevel1.Text = "Уровень 1";
            this.buttonLevel1.UseVisualStyleBackColor = false;
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonLevel2.Location = new System.Drawing.Point(350, 140);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(100, 47);
            this.buttonLevel2.TabIndex = 3;
            this.buttonLevel2.Text = "Уровень 2";
            this.buttonLevel2.UseVisualStyleBackColor = false;
            // 
            // buttonLevel3
            // 
            this.buttonLevel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonLevel3.Location = new System.Drawing.Point(350, 270);
            this.buttonLevel3.Name = "buttonLevel3";
            this.buttonLevel3.Size = new System.Drawing.Size(100, 47);
            this.buttonLevel3.TabIndex = 4;
            this.buttonLevel3.Text = "Уровень 3";
            this.buttonLevel3.UseVisualStyleBackColor = false;
            // 
            // buttonAddProblem
            // 
            this.buttonAddProblem.Location = new System.Drawing.Point(14, 75);
            this.buttonAddProblem.Name = "buttonAddProblem";
            this.buttonAddProblem.Size = new System.Drawing.Size(99, 33);
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
            this.buttonAnswersOnOff.Size = new System.Drawing.Size(102, 64);
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
            this.labelHintHandPick.Location = new System.Drawing.Point(120, 61);
            this.labelHintHandPick.Name = "labelHintHandPick";
            this.labelHintHandPick.Size = new System.Drawing.Size(204, 155);
            this.labelHintHandPick.TabIndex = 12;
            this.labelHintHandPick.Text = "Подсказка:\r\n\r\nНомера задач имеют \r\nчетырёхзначный номер\r\nи оканчиваются на 1,2 ил" +
    "и 3.\r\nВ список можно добавить\r\nдо 10 задач.\r\n\r\nПример: 0112";
            this.labelHintHandPick.Visible = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(12, 370);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(102, 54);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "выйти";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.Location = new System.Drawing.Point(328, 30);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(442, 424);
            this.webBrowserPreview.TabIndex = 15;
            this.webBrowserPreview.Visible = false;
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Enabled = false;
            this.buttonSaveFile.Location = new System.Drawing.Point(15, 300);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(100, 49);
            this.buttonSaveFile.TabIndex = 16;
            this.buttonSaveFile.Text = "Сохранить";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Предпросмотр списка задач";
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
            // ProblemChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.label1);
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
            this.Text = "Form1";
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
        private RoundButton roundButtonInfo;
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Label label1;
    }
}

