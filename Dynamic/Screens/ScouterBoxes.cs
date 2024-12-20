﻿using ScoutingCodeRedo.Properties;
using ScoutingCodeRedo.Static;
using System;
using System.Windows.Forms;

namespace ScoutingCodeRedo.Dynamic
{
    internal partial class ScouterBoxes : Form
    {
        public ScouterBoxes()
        {
            InitializeComponent();

            updateScreen.Enabled = true;
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                int o = BackgroundCode.Robots[i].ScouterBox;
                switch (BackgroundCode.Robots[BackgroundCode.Robots[i].ScouterBox].Current_Mode)
                {
                    case RobotState.ROBOT_MODE.Auto:
                        InAutoMode(i, o);
                        break;
                    case RobotState.ROBOT_MODE.Teleop:
                        InTeleopMode(i, o);
                        break;
                    case RobotState.ROBOT_MODE.Showtime:
                        InShowtimeMode(i, o);
                        break;
                }
            }
        }

        private void InAutoMode(int Box_Number, int ScouterBox)
        {
            // Acquire
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Text = "Acq:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

            if (BackgroundCode.Robots[Box_Number].Acq_Loc == RobotState.CURRENT_LOC.Select.ToString() && BackgroundCode.Robots[Box_Number].Acq_Center == 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }

            if (BackgroundCode.Robots[Box_Number].Acq_Center != 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Acq_Center.ToString();
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Acq_Loc;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Text = "D";
            if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Acq_Center != 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = false;
            }

            // Current Location
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1", true)[0]).Text = "Loc:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Current_Loc.ToString();
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

            // Deliver Destination
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Del_Dest == RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Del_Dest.ToString();
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Text = "M";
            if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Del_Dest != RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Visible = false;
            }

            // Robot Setup
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3", true)[0]).Text = "Setup:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Robot_Set.ToString();
            if (BackgroundCode.Robots[Box_Number].Robot_Set == RobotState.ROBOT_SET.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }

            // Leave
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Text = "Leave:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Leave == 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).BackColor = System.Drawing.Color.Red;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).ForeColor = System.Drawing.Color.Red;
            }
            if (BackgroundCode.Robots[Box_Number].Leave == 1)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).BackColor = System.Drawing.Color.Green;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).ForeColor = System.Drawing.Color.Green;
            }

            // Hp in Amp
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5", true)[0]).Text = "HP Amp";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].HP_Amp == RobotState.HP_AMP.N)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).BackColor = System.Drawing.Color.Red;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).ForeColor = System.Drawing.Color.Red;
            }
            if (BackgroundCode.Robots[Box_Number].HP_Amp == RobotState.HP_AMP.Y)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).BackColor = System.Drawing.Color.Green;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).ForeColor = System.Drawing.Color.Green;
            }
            if (BackgroundCode.Robots[Box_Number].HP_Amp == RobotState.HP_AMP.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).BackColor = System.Drawing.Color.Yellow;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).ForeColor = System.Drawing.Color.Yellow;
            }

            if (BackgroundCode.Robots[Box_Number].NoSho == true)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Text = "Mics:";
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

                if (BackgroundCode.Robots[Box_Number].Mic == 10 || BackgroundCode.Robots[Box_Number].Mic == 9)
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = false;
                }
                else
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Mic.ToString();
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
                }
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Visible = false;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = false;
            }


            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10Value", true)[0]).Visible = false;
        }
        private void InTeleopMode(int Box_Number, int ScouterBox)
        {
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Text = "Acq:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Acq_Loc.ToString();
            if (BackgroundCode.Robots[Box_Number].Acq_Loc.Equals("Select"))
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Text = "D";
            if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Del_Dest == RobotState.DEL_DEST.Select && BackgroundCode.Robots[Box_Number].Acq_Loc != "Select")
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Acq_Loc.Equals("Select"))
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = false;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1", true)[0]).Text = "Loc:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Current_Loc.ToString();
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;


            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Del_Dest.ToString();
            if (BackgroundCode.Robots[Box_Number].Del_Dest != RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Text = "M";
            if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Del_Dest != RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else if (BackgroundCode.Robots[Box_Number].Flag == 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Visible = false;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10Value", true)[0]).Visible = false;
        }
        private void InShowtimeMode(int Box_Number, int ScouterBox)
        {
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Del_Dest.ToString();
            if (BackgroundCode.Robots[Box_Number].Del_Dest != RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Value", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Text = "M";
            if (BackgroundCode.Robots[Box_Number].Flag == 1 && BackgroundCode.Robots[Box_Number].Del_Dest != RobotState.DEL_DEST.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
            else if (BackgroundCode.Robots[Box_Number].Flag == 0)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position0Flag", true)[0]).Visible = false;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1", true)[0]).Visible = false;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position1Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Text = "Climb:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

            BackgroundCode.Robots[Box_Number].ClimbTDouble = BackgroundCode.Robots[Box_Number].ClimbT_StopWatch.Elapsed.TotalSeconds;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].ClimbTDouble.ToString("0.#");
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position2Flag", true)[0]).Visible = false;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3", true)[0]).Text = "Status:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Stage_Stat.ToString();
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

            if (BackgroundCode.Robots[Box_Number].Stage_Stat == RobotState.STAGE_STAT.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position3Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }

            if (BackgroundCode.Robots[Box_Number].Stage_Stat == RobotState.STAGE_STAT.Onstage)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Text = "Stage:";
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

                if (BackgroundCode.Robots[Box_Number].Stage_Loc == RobotState.STAGE_LOC.Select)
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = false;
                }
                else
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).BackColor = System.Drawing.Color.Black;
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).ForeColor = System.Drawing.Color.Yellow;
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Stage_Loc.ToString();
                }
            }
            else if (BackgroundCode.Robots[Box_Number].Stage_Stat == RobotState.STAGE_STAT.Park ||
                BackgroundCode.Robots[Box_Number].Stage_Stat == RobotState.STAGE_STAT.Elsewhere)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Text = "Att:";
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Text = "..";
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
                if (BackgroundCode.Robots[Box_Number].Stage_Att == RobotState.STAGE_ATT.N)
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).BackColor = System.Drawing.Color.Red;
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).ForeColor = System.Drawing.Color.Red;
                }
                else if (BackgroundCode.Robots[Box_Number].Stage_Att == RobotState.STAGE_ATT.Y)
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).BackColor = System.Drawing.Color.Green;
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).ForeColor = System.Drawing.Color.Green;
                }
                else if (BackgroundCode.Robots[Box_Number].Stage_Att == RobotState.STAGE_ATT.Select)
                {
                    ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = false;
                }
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4", true)[0]).Visible = false;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position4Value", true)[0]).Visible = false;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5", true)[0]).Text = "Harm:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position5", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Harm == 10 || BackgroundCode.Robots[Box_Number].Harm == 9)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Harm.ToString();
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).BackColor = System.Drawing.Color.Black;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).ForeColor = System.Drawing.Color.Yellow;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position5Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }


            ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Text = "Strat:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position6", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].App_Strat.ToString();
            if (BackgroundCode.Robots[Box_Number].App_Strat == RobotState.APP_STRAT.Select)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position6Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7", true)[0]).Text = "Spotlit:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Lit == RobotState.LIT.Y)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).BackColor = System.Drawing.Color.Green;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).ForeColor = System.Drawing.Color.Green;

            }
            else if (BackgroundCode.Robots[Box_Number].Lit == RobotState.LIT.N)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).BackColor = System.Drawing.Color.Red;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).BackColor = System.Drawing.Color.Yellow;
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).ForeColor = System.Drawing.Color.Yellow;
            }
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).Text = ".";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position7Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8", true)[0]).Text = "Def:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position8", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Def_Rat == 10 || BackgroundCode.Robots[Box_Number].Def_Rat == 9)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position8Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position8Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Def_Rat.ToString();
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position8Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }

            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9", true)[0]).Text = "Mics:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position9", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Mic == 10 || BackgroundCode.Robots[Box_Number].Mic == 9)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position9Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position9Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Mic.ToString();
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position9Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }


            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10", true)[0]).Text = "Avo:";
            ((Label)this.Controls.Find($"lbl{ScouterBox}Position10", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            if (BackgroundCode.Robots[Box_Number].Avo_Rat == 10 || BackgroundCode.Robots[Box_Number].Avo_Rat == 9)
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position10Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position10Value", true)[0]).Text = BackgroundCode.Robots[Box_Number].Avo_Rat.ToString();
                ((Label)this.Controls.Find($"lbl{ScouterBox}Position10Value", true)[0]).Visible = (ScouterBox == 0) || !Settings.Default.practiceMode;
            }
        }
    }
}
