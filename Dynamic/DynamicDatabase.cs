﻿using ScoutingCodeRedo.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ScoutingCodeRedo.Dynamic
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    internal class SeasonContext : DbContext
    {
        public SeasonContext()
            : base(Settings.Default._scoutingdbConnectionString)
        { }

        public DbSet<EventSummary> Eventset { get; set; }
        public DbSet<TeamSummary> Teamset { get; set; }
        public DbSet<Match> Matchset { get; set; }
        public DbSet<Activity> ActivitySet { get; set; }
        public DbSet<UpdatePreview> UpdatePreviewSet { get; set; }
    }

    public class Activity : BaseEntity
    {
        //Data elements used in multiple modes (Auto, Auto and/or Showtime)
        //Record Type = Transaction

        //2024
        public string Team { get; set; }
        public int Match { get; set; }
        public DateTime Time { get; set; }
        public string RecordType { get; set; }
        public string Mode { get; set; }
        public int Leave { get; set; }
        public string AcqLoc { get; set; }
        public int AcqCenter { get; set; }
        public int AcqDis { get; set; }
        public int AcqDrp { get; set; }
        public string DelOrig { get; set; }
        public string DelDest { get; set; }
        public int DelMiss { get; set; }
        public string DriveSta { get; set; }
        public string RobotSta { get; set; }
        public string HPAmp { get; set; }
        public string StageStat { get; set; }
        public int StageAtt { get; set; }
        public string StageLoc { get; set; }
        public int Harmony { get; set; }
        public int Spotlit { get; set; }
        public double ClimbT { get; set; }
        public double OZTime { get; set; }
        public double NZTime { get; set; }
        public double AZTime { get; set; }
        public int Defense { get; set; }
        public int Avoidance { get; set; }
        public string Strategy { get; set; }
        public int Mics { get; set; }
        public string ScouterName { get; set; }
        public int ScouterError { get; set; }
        public string Match_event { get; set; }

        //Examples from previous years
        //public TimeSpan Cycle { get; set; }
        //public DateTime AcquireTime { get; set; }
        //public DateTime DeliverTime { get; set; }
        //public Decimal score_contribution { get; set; }
    }

    public class UpdatePreview : BaseEntity
    {
        //2024
        public string Team { get; set; }
        public int Match { get; set; }
        public DateTime Time { get; set; }
        public string RecordType { get; set; }
        public string Mode { get; set; }
        public int Leave { get; set; }
        public string AcqLoc { get; set; }
        public int AcqCenter { get; set; }
        public int AcqDis { get; set; }
        public int AcqDrp { get; set; }
        public string DelOrig { get; set; }
        public string DelDest { get; set; }
        public int DelMiss { get; set; }
        public string DriveSta { get; set; }
        public string RobotSta { get; set; }
        public string HPAmp { get; set; }
        public string StageStat { get; set; }
        public int StageAtt { get; set; }
        public string StageLoc { get; set; }
        public int Harmony { get; set; }
        public int Spotlit { get; set; }
        public double ClimbT { get; set; }
        public double OZTime { get; set; }
        public double NZTime { get; set; }
        public double AZTime { get; set; }
        public int Defense { get; set; }
        public int Avoidance { get; set; }
        public string Strategy { get; set; }
        public int Mics { get; set; }
        public string ScouterName { get; set; }
        public int ScouterError { get; set; }
        public string Match_event { get; set; }
    }
    public class EventSummary : BaseEntity
    {
        public string Key { get; set; }
        public string Website { get; set; }
        public bool Official { get; set; }
        public string End_date { get; set; }
        public string Name { get; set; }
        public string Short_name { get; set; }
        public string Facebook_eid { get; set; }
        public string Event_district_string { get; set; }
        public string Venue_address { get; set; }
        public int Event_district { get; set; }
        public String Week { get; set; }
        public string Location { get; set; }
        public string Event_code { get; set; }
        public int Year { get; set; }
        public List<object> Webcast { get; set; }
        public string Timezone { get; set; }
        public List<object> Alliances { get; set; }
        public string Event_type_string { get; set; }
        public string Start_date { get; set; }
        public int Event_type { get; set; }
    }

    public class TeamSummary : BaseEntity
    {
        /* UNUSED DATA AVAILABLE FROM TBA
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string gmaps_place_id { get; set; }
        public string gmaps_url { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string location_name { get; set; }
        public string motto { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string postal_code { get; set; }
        public string rookie_year { get; set; }
        public string school_name { get; set; }
        public string state_prov { get; set; }
        public string website { get; set; }         */
        public string Event_key { get; set; }
        public string Team_key { get; set; }
        public string Team_number { get; set; }
        public string Nickname { get; set; }
    }

    public class Match : BaseEntity
    {
        public string Comp_level { get; set; }
        public int Match_number { get; set; }
        public List<object> Videos { get; set; }
        public object Time_string { get; set; }
        public int Set_number { get; set; }
        public string Key { get; set; }
        public string Time { get; set; }
        public string Blueteam1 { get; set; }
        public string Blueteam2 { get; set; }
        public string Blueteam3 { get; set; }
        public string Redteam1 { get; set; }
        public string Redteam2 { get; set; }
        public string Redteam3 { get; set; }
        public string Event_key { get; set; }
        public int Pointscorered { get; set; }
        public int Redfouls { get; set; }
        public int Pointscoreblue { get; set; }
        public int Bluefouls { get; set; }
        public int Blueauto { get; set; }
        public int Redauto { get; set; }
        public int Bluecharge { get; set; }
        public int Redcharge { get; set; }
        public int Bluetotaldel { get; set; }
        public int Redtotaldel { get; set; }
    }
}
