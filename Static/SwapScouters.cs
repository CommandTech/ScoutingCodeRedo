﻿using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using ScoutingCodeRedo.Dynamic;
using System;

namespace ScoutingCodeRedo.Static
{
    public partial class SwapScouters : Form
    {
        public List<ComboBox> scoutDrops = new List<ComboBox>();

        public Dictionary<RobotState.SCOUTER_NAME, int> scouterDict = new Dictionary<RobotState.SCOUTER_NAME, int>();
        public SwapScouters()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                if (BackgroundCode.Robots[i].getScouterName(RobotState.SCOUTER_NAME.Select_Name) != RobotState.SCOUTER_NAME.Select_Name)
                {
                    scouterDict.Add(BackgroundCode.Robots[i].getScouterName(RobotState.SCOUTER_NAME.Select_Name), BackgroundCode.Robots[i].ScouterBox);
                }
            }

            scoutDrops.Add(ScoutDrop0);
            scoutDrops.Add(ScoutDrop1);
            scoutDrops.Add(ScoutDrop2);
            scoutDrops.Add(ScoutDrop3);
            scoutDrops.Add(ScoutDrop4);
            scoutDrops.Add(ScoutDrop5);

            foreach (var comboBox in scoutDrops)
            {
                comboBox.Items.AddRange(scouterDict.Keys.Select(sn => sn.ToString()).ToArray());
                comboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        //How I vision this is that each robot state is an object, each one has an int that declares which box they are in, then when deciding which box gets controlled by which controller, it looks at the int.

        private void ScoutOK_Click(object sender, EventArgs e)
        {
            List<int> newLocations = new List<int>();

            for (int i = 0; i < scoutDrops.Count; i++)
            {
                if (scoutDrops[i].SelectedIndex != -1)
                {
                    if (Enum.TryParse(scoutDrops[i].SelectedItem.ToString(), out RobotState.SCOUTER_NAME selectedName))
                    {
                        newLocations.Add(scouterDict[selectedName]);
                    }
                }
                else
                {
                    newLocations.Add(-1);
                }
            }

            for (int i = 0; i < newLocations.Count; i++)
            {
                if (newLocations[i] != -1)
                {
                    BackgroundCode.Robots[i].ScouterBox = newLocations[i];
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(BackgroundCode.Robots[i]._ScouterName + ": " + BackgroundCode.Robots[i].ScouterBox);
            }

            this.Hide();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox(scoutDrops);
        }
        private void UpdateComboBox(List<ComboBox> comboBoxes)
        {
            List<RobotState.SCOUTER_NAME> scouterNamesC = new List<RobotState.SCOUTER_NAME>();

            scouterNamesC = scouterDict.Keys.ToList();
            var selectedNames = comboBoxes.Select(cb => cb.SelectedItem).ToList();
            
            scouterNamesC.RemoveAll(sn => selectedNames.Contains(sn.ToString()));

            foreach (var comboBox in comboBoxes)
            {
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            }

            foreach (var comboBox in comboBoxes)
            {
                var prevItem = comboBox.SelectedItem;
                comboBox.Items.Clear();
                comboBox.Items.AddRange(scouterNamesC.Select(sn => sn.ToString()).ToArray());

                if (prevItem != null && comboBox.SelectedIndex == -1)
                {
                    comboBox.Items.Add(prevItem);
                    comboBox.SelectedItem = prevItem;
                }
            }

            foreach (var comboBox in comboBoxes)
            {
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void ClearScouters(object sender, EventArgs e)
        {
            foreach (var comboBox in scoutDrops)
            {
                comboBox.SelectedItem = null;
                comboBox.Items.Clear();
                comboBox.Items.AddRange(scouterDict.Keys.Select(sn => sn.ToString()).ToArray());
            }
        }
    }
}
