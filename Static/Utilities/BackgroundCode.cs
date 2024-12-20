﻿using ScoutingCodeRedo.Dynamic;
using ScoutingCodeRedo.Properties;
using ScoutingCodeRedo.Static.GamePadFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

namespace ScoutingCodeRedo.Static
{
    internal class BackgroundCode
    {
        public static GamePad[] gamePads;                                   //List of all the gamepads connected to the computer
        public static Controllers controllers = new Controllers();          //The controller class that handles all the gamepad stuff

        public static RobotState[] Robots = new RobotState[6];              //Contains the state of each Scout's match tracking

        public List<Match> InMemoryMatchList = new List<Match>();           //The list of all the matches at the selected event.
        public List<Match> UnSortedMatchList = new List<Match>();           //This is just the list of all matches, not yet sorted
        public static List<int> MatchNumbers = new List<int>();             //The list of match numbers for the event selected

        public static List<string> teamlist = new List<string>();           //The list of teams for the event selected

        public static Activity activity_record = new Activity();            //The activity record being sent to the database
        public static SeasonContext seasonframework = new SeasonContext();  //The database context

        public PrintOut print = new PrintOut();                             //Print out form for debugging

        private static readonly string soundFilePath = System.IO.Path.Combine(
            System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName,
            "errorSound.wav"
        );                                                                  //Sound file for practice mode error

        public static SoundPlayer soundCue = new SoundPlayer(soundFilePath);//Sound player for practice mode error
        public BackgroundCode()
        {
            //If the program is in debug mode, show the print out form
            if (Debugger.IsAttached)
            {
                print.Show();
            }

            //Sets the connection string to the database
            seasonframework.Database.Connection.ConnectionString = Settings.Default._scoutingdbConnectionString;

            //Checks if the database exists
            Settings.Default.DBExists = seasonframework.Database.Exists();

            //Sets the default values for the robots
            for (int i = 0; i < 6; i++)
            {
                Robots[i] = new RobotState
                {
                    ScouterBox = i,
                    _ScouterName = RobotState.SCOUTER_NAME.Select_Name,
                    color = i < 3 ? "Red" : "Blue"
                };
            }
        }
    }
}
