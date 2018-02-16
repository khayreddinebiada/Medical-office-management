using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MePatients.SI
{
    class ControlleFichiers
    {

        private static string pathPatientFichier = @"Patients.xml";
        private static string pathPatientDossier = @"Les Données";

        public static void WriteXML(List<Patient> obj)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Patient>));
            
            if (!Directory.Exists(pathPatientDossier))
                Directory.CreateDirectory(pathPatientDossier);

            FileStream file;
            file = File.Create(pathPatientDossier + "\\" + pathPatientFichier);
            

            writer.Serialize(file, obj);

            file.Close();
        }

        public static List<Patient> ReadXML()
        {
            if (!File.Exists(pathPatientDossier + "\\" + pathPatientFichier))
                ControlleFichiers.WriteXML(new List<Patient>());
            
            List<Patient> objs = null;

            using (Stream reader = new FileStream(pathPatientDossier+"\\"+pathPatientFichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer read = new XmlSerializer(typeof(List<Patient>));
                objs = (List<Patient>)read.Deserialize(reader);
            }

            if (objs == null) return new List<Patient>();

            return objs;
        }

    }
}
