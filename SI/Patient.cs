using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePatients.SI
{
    [Serializable]
    public class Patient
    {
        public enum Sexe { Home = 1, Femme=0 }

        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Naissance { get; set; }
        public string Age { get; set; }
        public Sexe sexeHome { get; set; }
        public string Diagnostic { get; set; }

        public string Addresse { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Antecedents { get; set; }

        public bool Favorie { get; set; }
        public string Profession { get; set; }
        public int Poid { get; set; }
        public int Taille { get; set; }
        public string Rapport { get; set; }

        public double[] argent;
        

        public DateTime DateCreation { get; set; }


        // public int NumCNAM { get; set; }
        // public string TypeCNAM { get; set; }
        // public int CodeAPCI { get; set; }

        public Patient()
        {

            ID = 0;

            this.Nom = "";
            this.Naissance = new DateTime(1990,1,1);
            this.Age = "";
            this.Poid = 0;
            this.Taille = 0;
            this.sexeHome = Sexe.Home;
            this.DateCreation = new DateTime(1990, 1, 1);
            this.Profession = "";
            this.Addresse = "";
            this.Email = "";
            this.Telephone = "";
            this.Favorie = false;
            this.Diagnostic = "";
            this.Antecedents = "";
            this.Rapport = "";
        }

        public Patient(int ID)
        {

            this.ID = ID;
            this.Nom = "";
            this.Naissance = new DateTime(1990, 1, 1);
            this.Age = "";
            this.sexeHome = Sexe.Home;
            this.Diagnostic = "";
            this.Addresse = "";
            this.Email = "";
            this.Telephone = "";
            this.Profession = "";
            this.Favorie = false;
            this.Poid = 0;
            this.Taille = 0;
            this.Antecedents = "";
            this.Rapport = "";

            this.DateCreation = new DateTime(1990, 1, 1);
        }

        public Patient(string Nom, DateTime Naissance, string Age, int Poid, int Taille, Sexe sexeHome, DateTime DateCreation, string Profession, string Addresse, string Email, string Telephone, bool Favorie, string Antecedents, string Diagnostic, string Rapport)
        {
            this.ID = ID;
            this.Nom = Nom;
            this.Naissance = Naissance;
            this.Age = Age;
            this.Poid = Poid;
            this.Taille = Taille;
            this.sexeHome = sexeHome;
            this.DateCreation = DateCreation;
            this.Profession = Profession;
            this.Addresse = Addresse;
            this.Email = Email;
            this.Telephone = Telephone;
            this.Favorie = Favorie;
            this.Antecedents = (Antecedents != null) ? Antecedents : "";
            this.Diagnostic = (Diagnostic != null) ? Diagnostic : "";
            this.Rapport = (Rapport != null) ? Rapport : "";
        }
    }
}
