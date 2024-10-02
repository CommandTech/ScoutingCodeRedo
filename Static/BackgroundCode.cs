﻿using System;
using System.Collections.Generic;
using System.Media;
using ScoutingCodeRedo.Dynamic;
using ScoutingCodeRedo.Properties;
using ScoutingCodeRedo.Static.GamePadFolder;
using SharpDX.DirectInput;

namespace ScoutingCodeRedo.Static
{
    internal class BackgroundCode
    {
        public DirectInput Input = new DirectInput();
        public static GamePad[] gamePads;
        public static Controllers controllers = new Controllers();

        public static RobotState[] Robots = new RobotState[6];                            //Contains the state of each Scout's match tracking

        public List<Match> InMemoryMatchList = new List<Match>();           //The list of all the matches at the selected event.
        public List<Match> UnSortedMatchList = new List<Match>();           //This is just the list of all matches, not yet sorted
        public List<int> MatchNumbers = new List<int>();

        public List<string> teamlist = new List<string>();                         //The list of teams for the event selected

        public RobotState[] rs = new RobotState[6];

        public static Activity activity_record = new Activity();
        public static SeasonContext seasonframework = new SeasonContext();

        private static string soundFilePath = System.IO.Path.Combine(
            System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName,
            "errorSound.wav"
        );
        public static SoundPlayer soundCue = new SoundPlayer(soundFilePath);
        public BackgroundCode(bool func)
        {
            if (!func)
            {
                seasonframework.Database.Connection.ConnectionString = Settings.Default._scoutingdbConnectionString;
            }

            for (int i = 0; i < 6; i++)
            {
                BackgroundCode.Robots[i] = new RobotState
                {
                    ScouterBox = i,
                    _ScouterName = RobotState.SCOUTER_NAME.Select_Name,
                    color = i < 3 ? "Red" : "Blue"
                };
            }
        }
    }
}
