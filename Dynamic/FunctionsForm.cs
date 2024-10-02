﻿using ScoutingCodeRedo.Properties;
using ScoutingCodeRedo.Static;
using System;
using System.Windows.Forms;

namespace ScoutingCodeRedo.Dynamic
{
    internal partial class FunctionsForm : Form
    {
        BackgroundCode bgc;
        public FunctionsForm()
        {
            InitializeComponent();
            bgc = new BackgroundCode(true);
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

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            if (Settings.Default.DBExists)
            {
                UpdateDatabase frm = new UpdateDatabase(bgc.teamlist, bgc.MatchNumbers);
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please load The Blue Aliance to create the database or create the database in a different way");
            }
        }
    }
}
