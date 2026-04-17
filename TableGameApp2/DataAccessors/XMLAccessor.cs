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
        public static bool NewLineOnAttributes { get; set; }

        /// <summary>
        /// used to save a list of heros to the local xml file
        /// </summary>
        /// <param name="heroes"></param>
        /// <returns></returns>
        public static string saveHeroes(List<Hero> heroes)
        {
            string workingDirectory = Environment.CurrentDirectory;
          
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Hero>));
            FileStream stream = File.OpenWrite(Environment.CurrentDirectory + "\\heroStats.xml");
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
            FileStream streamRead = File.OpenRead(Environment.CurrentDirectory + "\\heroStats.xml");
            var result = (List<Hero>)(serialiser.Deserialize(streamRead));
            return result;
        }
    }
}
