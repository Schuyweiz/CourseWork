using System;
using System.Windows.Forms;

namespace Coursework5
{
    public partial class SaveFile : Form
    {
        public SaveFile()
        {
            InitializeComponent();
            this.CenterToParent();
            this.Text = "";
            buttonSave.Click += UserAnswerSave;
            buttonSaveAndOpen.Click += UserAnswerSaveLoad;
        }
        public bool SaveOrLoad { get; set; }
        public void UserAnswerSaveLoad(object sender, EventArgs e)
        {
            this.SaveOrLoad = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void UserAnswerSave(object sedner, EventArgs e)
        {
            this.SaveOrLoad = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
