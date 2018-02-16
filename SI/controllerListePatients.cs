using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MePatients.SI
{
    class controllerListePatients
    {
        private List<Patient> patients = null;
        private int maxID;
        public Patient patientAfficherPres = null;
        public bool clickAjouter = false;

        public controllerListePatients(Patient patients)
        {
            this.maxID = patients.ID;

            this.patients = new List<Patient>();
            this.patients.Add(patients);
        }

        public controllerListePatients(List<Patient> patients)
        {

            this.patients = patients;

            for (int i = 0; i < patients.Count; i++)
            {
                if (this.maxID < patients[i].ID) this.maxID = patients[i].ID;
            }

        }

        public List<Patient> recherchePatientFavories()
        {
            List<Patient> patientRechercher = new List<Patient>();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients.ElementAt(i).Favorie == true)
                {
                    patientRechercher.Add(patients.ElementAt(i));
                }
            }

            return patientRechercher;
        }

        public List<Patient> recherchePatientParID(int IdRechercher)
        {
            List<Patient> patientRechercher = new List<Patient>();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients.ElementAt(i).ID == IdRechercher)
                {
                    patientRechercher.Add(patients.ElementAt(i));
                    break;
                }
            }

            return patientRechercher;
        }

        public List<Patient> recherchePatientParNom( string elementRechercher)
        {
            List<Patient> patientRechercher = new List<Patient>();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients.ElementAt(i).Nom.Contains(elementRechercher))
                {
                    patientRechercher.Add(patients.ElementAt(i));
                }
            }

            return patientRechercher;
        }

        public void supprimerPatient(int Id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].ID == Id)
                {
                    patients.RemoveAt(i);
                    break;
                }
            }
        }

        public int getMaxID (){
            return this.maxID;
        }

        public List<Patient> getListePatients()
        {
            return patients;
        }

        public void setListePatients(List<Patient> listePatients)
        {
            this.patients = listePatients;
        }

        public void AjouterPatient(Patient patient)
        {
            patient.ID = ++this.maxID;
            this.patients.Add(patient);
        }
    }

}
