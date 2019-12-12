using System;
using System.Collections.Generic;
using System.Xml;

namespace kurs_part1
{
    public class InputParser
    {
        private static string InputFileName = FileUtils.SolutionDir + "input.xml";
        public static List<Car> Cars { get; private set; } = new List<Car>();
        public static List<Boat> Boats { get; private set; } = new List<Boat>();
        public static List<Aircraft> Aircrafts { get; private set; } = new List<Aircraft>();
        public static List<Train> Trains { get; private set; } = new List<Train>();


        public InputParser()
        {
            XmlDocument XConfig = new XmlDocument();
            try
            {
                XConfig.Load(InputFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() +"*** "+ InputFileName);
            }
            XmlElement XRoot = XConfig.DocumentElement;
            foreach (XmlNode XNode in XRoot)
            {
                switch (XNode.Name)
                {
                    case "Car":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            Cars.Add(new Car(XChildNode.InnerText));
                        }
                        break;
                    case "Boat":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            Boats.Add(new Boat(XChildNode.InnerText));
                        }
                        break;
                    case "Aircraft":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            Aircrafts.Add(new Aircraft(XChildNode.InnerText));
                        }
                        break;
                    case "Train":
                        foreach (XmlNode XChildNode in XNode.ChildNodes)
                        {
                            Trains.Add(new Train(XChildNode.InnerText));
                        }
                        break;
                }
            }
        }
    }
}
