using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using TableGameApp2.Data;

namespace TableGameApp2.DataAccessors
{
    public static class XMLAccessor
    {
        public static String _heroStatsFileName = "heroStats.xml";
        public static String _armyInfosFileName = "armyInfo.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="armies"></param>
        /// <returns></returns>
        public static string saveArmies(List<Army> armies)
        {
            string workingDirectory = Environment.CurrentDirectory;

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Army>));
            FileStream stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + _armyInfosFileName);
            serialiser.Serialize(stream, armies);
            stream.Dispose();
            return "";
        }
        /// <summary>
        /// used to load the armies from the XML file
        /// </summary>
        /// <returns></returns>
        public static List<Army> loadArmies()
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Army>));
            if (!File.Exists(Environment.CurrentDirectory + "\\" + _armyInfosFileName))
            {
                FileStream stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + _armyInfosFileName);
                serialiser.Serialize(stream, new List<Army>());
                stream.Dispose();
            }

            FileStream streamRead = File.OpenRead(Environment.CurrentDirectory + "\\" + _armyInfosFileName);
            List<Army> result = (List<Army>)(serialiser.Deserialize(streamRead));
            streamRead.Dispose();
            return result;
        }

        /// <summary>
        /// used to save a list of heros to the local xml file
        /// </summary>
        /// <param name="heroes"></param>
        /// <returns></returns>
        public static string saveHeroes(List<Hero> heroes)
        {
            string workingDirectory = Environment.CurrentDirectory;
          
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Hero>));
            FileStream stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + _heroStatsFileName);
            serialiser.Serialize(stream, heroes);
            stream.Dispose();
            return "";
        }

        /// <summary>
        /// used to load the heroes from the xml file
        /// </summary>
        /// <returns></returns>
        public static List<Hero> loadHeroes()
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Hero>));
            if(!File.Exists(Environment.CurrentDirectory + "\\" + _heroStatsFileName))
            {
                FileStream stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + _heroStatsFileName);
                serialiser.Serialize(stream, new List<Hero>());
                stream.Dispose();
            }
             
            FileStream streamRead = File.OpenRead(Environment.CurrentDirectory + "\\" + _heroStatsFileName);
            List<Hero> result = (List<Hero>)(serialiser.Deserialize(streamRead));
            streamRead.Dispose();
            return result;
        }
    }
}
