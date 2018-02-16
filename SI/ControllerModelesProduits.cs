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
    class ControllerModelesProduits
    {
        private List<Modele> modeles;
        private int MaxID;


        private static string pathFichier = @"Modeles.xml";
        private static string pathDossier = @"Les Données";


        // les Constructeurs

        public ControllerModelesProduits()
        {
            this.modeles = actualiseListeModeles();

            for (int i = 0; i < modeles.Count; i++)
            {
                if (this.MaxID < this.modeles.ElementAt(i).ID)
                    this.MaxID = this.modeles.ElementAt(i).ID;
            }
        }

        public ControllerModelesProduits(List<Modele> modeles)
        {
            modeles = actualiseListeModeles();
            this.modeles = modeles;
        }

        public List<Modele> actualiseListeModeles()
        {
            modeles = ControllerModelesProduits.ReadXML();
            return modeles;
        }
        
        public List<Modele> getListeModeles()
        {
            return this.modeles;
        }
        
        // Par paramètre Modele
        public bool AjouterModele(string Nom, string Reference, string lieuStockage)
        {
            try
            {

                for (int i = 0; i < modeles.Count; i++)
                {
                    if (this.modeles.ElementAt(i).Nom.Equals(Nom))
                    {
                        System.Windows.Forms.MessageBox.Show("La modèle a existé, On ne peux pas ajouter.");
                        return false;
                    }
                }

                Modele modele = new Modele(++this.MaxID, Nom, 0, Reference, lieuStockage);
                modeles.Add(modele);
                ControllerModelesProduits.WriteXML(modeles);
                actualiseListeModeles();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("La modèle n'ajoute pas");
            }

            return false;
        }

        // Par paramètre List <Modele>
        public void AjouterModele(List<Modele> modeles)
        {
            try
            {
                for (int i = 0; i < modeles.Count; i++)
                {
                    this.modeles.Add(modeles.ElementAt(i));
                }

                ControllerModelesProduits.WriteXML(modeles);
                actualiseListeModeles();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("La modèle n'ajoute pas");
            }
        }

        public void supprimerModele(int ID)
        {
            try
            {
                for (int i = 0; i < modeles.Count; i++)
                {
                    if (this.modeles.ElementAt(i).ID == ID)
                    {
                        this.modeles.Remove(modeles.ElementAt(i));
                        ControllerModelesProduits.WriteXML(modeles);
                        actualiseListeModeles();
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



        public static void WriteXML(List<Modele> obj)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Modele>));

            if (!Directory.Exists(pathDossier))
                Directory.CreateDirectory(pathDossier);

            FileStream file;
            file = File.Create(pathDossier + "\\" + pathFichier);


            writer.Serialize(file, obj);

            file.Close();
        }

        public static List<Modele> ReadXML()
        {
            if (!File.Exists(pathDossier + "\\" + pathFichier))
                ControllerModelesProduits.WriteXML(new List<Modele>());

            List<Modele> objs = null;

            using (Stream reader = new FileStream(pathDossier + "\\" + pathFichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer read = new XmlSerializer(typeof(List<Modele>));
                objs = (List<Modele>)read.Deserialize(reader);
            }

            if (objs == null) return new List<Modele>();

            return objs;
        }
    }
}
