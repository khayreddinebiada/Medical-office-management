using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePatients.SI
{

    class Ordonnance
    {

        public int ID { get; set; }

        public int IdPatient { get; set; }

        public string nomPatient { get; set; }

        public DateTime DateCreation { get; set; }

        public string nomMedicaments { get; set; }

        private List<Medicament> Medicaments;

        private Patient Patient;

    }
}
