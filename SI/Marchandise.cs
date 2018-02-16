using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePatients.SI
{
    [Serializable]
    public class Marchandise
    {

        public int ID { get; set; }
        public string nomModele { set; get; }
        public string Quantite { set; get; }
        public double Prix { set; get; }
        public string sourceAchat { set; get; }
        public DateTime dateAchat { set; get; }

        public Marchandise() {

            this.ID = -1;
            this.nomModele = "";
            this.Quantite = "";
            this.Prix = 0;
            this.sourceAchat = "";
            this.dateAchat = DateTime.Now;

        }

        public Marchandise(int ID, string nomModele, string Quantite, double Prix, string sourceAchat)
        {

            this.ID = ID;
            this.nomModele = nomModele;
            this.Quantite = Quantite;
            this.Prix = Prix;
            this.sourceAchat = sourceAchat;
            this.dateAchat = DateTime.Now;

        }

    }
}
