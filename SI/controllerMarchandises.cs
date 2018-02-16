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
    class controllerMarchandises
    {
        private List<Marchandise> marchandises;
        private int MaxID;
        
        public controllerMarchandises()
        {
            this.marchandises = actualiseListeMarchandises();

            for (int i = 0; i < marchandises.Count; i++)
            {
                if (this.MaxID < this.marchandises.ElementAt(i).ID)
                    this.MaxID = this.marchandises.ElementAt(i).ID;
            }
        }

        public controllerMarchandises(List<Marchandise> marchandises)
        {

            for (int i = 0; i < marchandises.Count; i++)
            {
                if (this.MaxID < this.marchandises.ElementAt(i).ID)
                    this.MaxID = this.marchandises.ElementAt(i).ID;
            }

            marchandises = actualiseListeMarchandises();
            this.marchandises = marchandises;

        }

        public List<Marchandise> actualiseListeMarchandises()
        {
            marchandises = controllerMarchandises.ReadXML();
            return marchandises;
        }

        public List<Marchandise> getListeMarchandises()
        {
            return this.marchandises;
        }
        
        // Par paramètre Modele
        public bool AjouterMarchandise(string Nom, string Qantite, double Prix, string sourceAchat)
        {
            try
            {

                Marchandise marchandise = new Marchandise(++this.MaxID, Nom,Qantite,Prix,sourceAchat);
                marchandises.Add(marchandise);
                controllerMarchandises.WriteXML(marchandises);
                actualiseListeMarchandises();

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("La Marchandise n'ajoute pas");
            }

            return false;
        }

        public void supprimerMarchandise(int ID)
        {
            try
            {
                for (int i = 0; i < marchandises.Count; i++)
                {
                    if (this.marchandises.ElementAt(i).ID == ID)
                    {
                        this.marchandises.Remove(marchandises.ElementAt(i));
                        controllerMarchandises.WriteXML(marchandises);
                        actualiseListeMarchandises();
                        return;
                    }
                }

                System.Windows.Forms.MessageBox.Show("La modèle est introuvable");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("La modèle n'supprime pas");
            }
        }
        


        /* Static Fonctions et variables */
        private static string pathFichier = @"Marchandises.xml";
        private static string pathDossier = @"Les Données";


        public static void WriteXML(List<Marchandise> obj)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Marchandise>));

            if (!Directory.Exists(pathDossier))
                Directory.CreateDirectory(pathDossier);

            FileStream file;
            file = File.Create(pathDossier + "\\" + pathFichier);


            writer.Serialize(file, obj);

            file.Close();
        }

        public static List<Marchandise> ReadXML()
        {
            if (!File.Exists(pathDossier + "\\" + pathFichier))
                controllerMarchandises.WriteXML(new List<Marchandise>());

            List<Marchandise> objs = null;

            using (Stream reader = new FileStream(pathDossier + "\\" + pathFichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer read = new XmlSerializer(typeof(List<Marchandise>));
                objs = (List<Marchandise>)read.Deserialize(reader);
            }

            if (objs == null) return new List<Marchandise>();

            return objs;
        }
    }
}
