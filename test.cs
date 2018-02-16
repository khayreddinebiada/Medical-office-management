using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using MePatients.SI;

namespace MePatients
{
    class test
    {
        private static string path = @"File.xml";

        public static void WriteXML(List<Patient> obj)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Patient>));

            FileStream file = File.Create(path);

            writer.Serialize(file, obj);

            file.Close();
        }

        public static List<Patient> ReadXML()
        {
            List<Patient> objs = null;

            
            using (Stream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer read = new XmlSerializer(typeof(List<Patient>));
                objs = (List<Patient>)read.Deserialize(reader);
            }
            
            if (objs == null) return new List<Patient>();

            return objs;
        }
    }
}
