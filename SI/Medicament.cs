using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePatients.SI
{
    class Medicament
    {
        public int ID { get; set; }
        public string nomMedicament { get; set; }
        public string dosageMedicament { get; set; }
        public string formeMedicament { get; set; }
        public string nombreFoisParJour { get; set; }
        public string quantitePrise { get; set; }
    }
}
