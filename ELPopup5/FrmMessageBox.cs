using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmMessageBox : Form
    {

        private bool ClosingWithButtonPress = false;

        private DialogResult Result_Btn1;
        private DialogResult Result_Btn2;
        private DialogResult Result_Btn3;

        public FrmMessageBox(string title, string message, bool use_btn1, DialogResult btn1_result_type, bool use_btn2, DialogResult btn2_result_type, bool use_btn3, DialogResult btn3_result_type, string btn1_text, string btn2_text, string btn3_text, int default_button)
        {
            InitializeComponent();
            Common.DrawColors(this, title);

            tbMessage.BackColor = Program.C_BACKGROUND;
            tbMessage.Text = message;

            // Set text to buttons
            btn1.Text = btn1_text;
            btn2.Text = btn2_text;
            btn3.Text = btn3_text;

            Result_Btn1 = btn1_result_type;
            Result_Btn2 = btn2_result_type;
            Result_Btn3 = btn3_result_type;

            // Enable/disable buttons by making them visible/invisible
            btn1.Visible = use_btn1;
            btn2.Visible = use_btn2;
            btn3.Visible = use_btn3;

            switch (default_button)
            {
                case 1:
                    btn1.Focus();
                    break;
                case 2:
                    btn2.Focus();
                    break;
                case 3:
                    btn3.Focus();
                    break;
            }

        }

        public void Button_Click(object sender, EventArgs e)
        {
            Button the_button = (Button)sender;
            ClosingWithButtonPress = true;
            switch (the_button.Name)
            {
                case "btn1":
                    DialogResult = Result_Btn1;
                    break;

                case "btn2":
                    DialogResult = Result_Btn2;
                    break;

                case "btn3":
                    DialogResult = Result_Btn3;
                    break;
            }

            Close();

        }

        private void FrmMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingWithButtonPress)
            {
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
