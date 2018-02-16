using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MePatients.SI
{
    [Serializable]
    public class Modele
    {
        public int ID { get; set; }
        public string Reference { set; get; }
        public string Nom { set; get; }
        public int Quantite;
        public string lieuStockage { set; get; }

        public Modele()
        {
            this.ID = -1;
            this.Quantite = 0;
            this.Nom = null;
            this.Reference = null;
            this.lieuStockage = null;
        }

        public Modele(int ID, string Nom, int Quantite, string reference, string lieuStockage)
        {
            this.ID = ID;
            this.Nom = Nom;
            this.Quantite = Quantite;
            this.Reference = reference;
            this.lieuStockage = lieuStockage;
        }

    }
}
