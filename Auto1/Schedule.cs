﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Schedule
    {
        public const int DaysPerWeek = 7;
        public const int HoursPerDay = 24;
        public const int MinutesPerHour = 60;
        public const DaysOfWeek StartDay = DaysOfWeek.Monday;

        public static int StartHour { get; private set; } = ConfigParser.StartHour; //opening at 10 am
        public static int UsualOpenedTime { get; private set; } = ConfigParser.UsualOpenedTime;
        public static int WeekendOpenedTime { get; private set; } = ConfigParser.WeekendOpenedTime;

        //current time
        public static DaysOfWeek CurrentDay { get { return (DaysOfWeek)(Admin.Now / (HoursPerDay * MinutesPerHour) % DaysPerWeek); } }
        public static int CurrentHour { get { return Admin.Now / MinutesPerHour % HoursPerDay; } }
        public static int CurrentMinute { get { return Admin.Now % MinutesPerHour; } }
        public static bool IsOpened { get { return CheckIsOpened(); } }
        public enum DaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public Schedule(int SchStartHour, int SchUsualOpenedTime, int SchWeekendOpenedTime)
        {
            StartHour = SchStartHour;
            UsualOpenedTime = SchUsualOpenedTime;
            WeekendOpenedTime = SchWeekendOpenedTime;
        }

        public static int GetTimeInMinutes(int Day, int Hour, int Minute)
        {
            return Minute + MinutesPerHour * (Hour + HoursPerDay * Day);
        }


        public static int GetOpenedTime(DaysOfWeek day)
        {
            if (day == DaysOfWeek.Saturday || day == DaysOfWeek.Sunday)
            {
                return WeekendOpenedTime;
            }
            else
            {
                return UsualOpenedTime;
            }
        }

        public static string GetTimeString()
        {
            return string.Format("{0} {1}", ((DaysOfWeek)CurrentDay).ToString(), Utils.ToTimeFormat(CurrentHour, CurrentMinute));
        }

        public static string GetTimeString(int Time)
        {
            return string.Format("{0} {1}",
                 ((DaysOfWeek)(Time / (HoursPerDay * MinutesPerHour) % DaysPerWeek)).ToString(),
                 Utils.ToTimeFormat(Time / MinutesPerHour % HoursPerDay, Time % MinutesPerHour));
        }

        public static int GetDayNumber()
        {
            return Admin.Now / (HoursPerDay * MinutesPerHour);
        }

        private static bool CheckIsOpened()
        {
            return Admin.Now >= GetTimeInMinutes(GetDayNumber(), StartHour, 0) && Admin.Now <= GetTimeInMinutes(GetDayNumber(), StartHour + GetOpenedTime(CurrentDay), 0);
        }
    }
}
