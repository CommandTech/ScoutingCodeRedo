﻿using ScoutingCodeRedo.Properties;
using ScoutingCodeRedo.Static;
using System;
using System.Windows.Forms;

namespace ScoutingCodeRedo.Dynamic
{
    internal partial class FunctionsForm : Form
    {
        public FunctionsForm()
        {
            InitializeComponent();
        }

        private void FuncOK_Click(object sender, EventArgs e)
        {
            Settings.Default.practiceMode = cbxPractice.Checked;
            this.Hide();
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            PriorityForm frm = new PriorityForm();
            this.Hide();
            frm.Show();
        }

        private void btnSwapScouters_Click(object sender, EventArgs e)
        {
            SwapScouters frm = new SwapScouters();
            this.Hide();
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BaseScreen.UpdateJoysticks();
            this.Hide();
        }
    }
}