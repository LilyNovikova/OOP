using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Auto1
{
    public class ConfigParser
    {
        private static string ConfigFileName = FileUtils.SolutionDir + "config.xml";

        public static int MaxDisperciaPercent { get; private set; }
        public static int RequestReceivingFrequency { get; private set; }
        public static int ImitationDuration { get; private set; } = Schedule.GetTimeInMinutes(13, 19, 0);
        public static int MaxWaitingTime { get; private set; }
        public static int MaxTasksInRequest { get; private set; }
        public static int WagePercent { get; private set; }
        public static int MinimumWage { get; private set; }
        public static int StartHour { get; private set; }
        public static int UsualOpenedTime { get; private set; }
        public static int WeekendOpenedTime { get; private set; }

        public ConfigParser()
        {
            XmlDocument XConfig = new XmlDocument();
            try
            {
                XConfig.Load(ConfigFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + "*** " + ConfigFileName);
            }
            XmlElement XRoot = XConfig.DocumentElement; //корень документа
            foreach (XmlNode XNode in XRoot)
            {
                //сбор данных по узлам документа
                switch (XNode.Name)
                {
                    case "Admin":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            switch (XChildNode.Name)
                            {
                                case "MaxDisperciaPercent":
                                    MaxDisperciaPercent = int.Parse(XChildNode.InnerText);
                                    break;
                                case "RequestReceivingFrequency":
                                    RequestReceivingFrequency = int.Parse(XChildNode.InnerText);
                                    break;
                                case "ImitationDuration":
                                    ImitationDuration = int.Parse(XChildNode.InnerText);
                                    break;
                                case "MaxWaitingTime":
                                    MaxWaitingTime = int.Parse(XChildNode.InnerText);
                                    break;
                                case "MaxTasksInRequest":
                                    MaxTasksInRequest = int.Parse(XChildNode.InnerText);
                                    break;
                            }
                        }
                        break;
                    case "Worker":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            switch (XChildNode.Name)
                            {
                                case "WagePercent":
                                    WagePercent = int.Parse(XChildNode.InnerText);
                                    break;
                                case "MinimumWage":
                                    MinimumWage = int.Parse(XChildNode.InnerText);
                                    break;
                            }
                        }
                        break;
                    case "Schedule":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            switch (XChildNode.Name)
                            {
                                case "StartHour":
                                    StartHour = int.Parse(XChildNode.InnerText);
                                    break;
                                case "UsualOpenedTime":
                                    UsualOpenedTime = int.Parse(XChildNode.InnerText);
                                    break;
                                case "WeekendOpenedTime":
                                    WeekendOpenedTime = int.Parse(XChildNode.InnerText);
                                    break;
                            }
                        }
                        break;
                }
            }
            Schedule sch = new Schedule(StartHour, UsualOpenedTime, WeekendOpenedTime);
        }
    }
}
