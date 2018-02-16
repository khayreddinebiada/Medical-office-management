using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MePatients.SI;

namespace MePatients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private controllerListePatients listPatientsAfficher = null;
        private ControllerModelesProduits Modeles = null;
        private controllerMarchandises marchandise = null;
        private bool licence = false;


        public MainWindow()
        {

            InitializeComponent();

            WindowState = WindowState.Maximized;
            InitializingWindow();

        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            if (enUtilisateur.Text.Equals("DR.JAZOULI") && enModepasse.Password.Equals("123.DR.JAZOULI"))
            {
                LicenceSoft.Visibility = Visibility.Hidden;
                PatientsGrid.Visibility = Visibility.Visible;
                licence = true;
            }
        }

        private void btn_AfficherGridPatient (object sender, RoutedEventArgs e)
        {
            if (licence)
            {
                GridStockage.Visibility = Visibility.Hidden;
                GridPatient.Visibility = Visibility.Visible;
                bntAfficherGridPatient.IsEnabled = false;
                btnAfficherGridStockage.IsEnabled = true;
            }
        }

        private void btn_AfficherGridStockage(object sender, RoutedEventArgs e)
        {
            if (licence)
            {
                GridStockage.Visibility = Visibility.Visible;
                GridPatient.Visibility = Visibility.Collapsed;
                bntAfficherGridPatient.IsEnabled = true;
                btnAfficherGridStockage.IsEnabled = false;
            }
        }

        private void ListPatients(object sender, RoutedEventArgs e)
        {

        }

        private void AjouterPatient()
        {
            enPoid.Text = enPoid.Text.Replace(" ", string.Empty);
            enTaille.Text = enTaille.Text.Replace(" ", string.Empty);

            Patient patient = new Patient(enNom.Text, new DateTime((int)enAnnee.SelectedItem, (int)enMois.SelectedItem, (int)enJour.SelectedItem), enAge.Text, int.Parse((!enPoid.Text.Equals(""))?enPoid.Text:"0")
                , int.Parse((!enTaille.Text.Equals("")) ? enTaille.Text : "0"), (ChackHomme.IsChecked == true) ? Patient.Sexe.Home : Patient.Sexe.Femme, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), enProfession.Text
                , enAddresse.Text, enEmail.Text, enNumTele.Text, (enFavorie.IsChecked == true) ? true : false
                , enAntecedents.Text, enCompte_rendu.Text, enNotesMedicale.Text);

            listPatientsAfficher.AjouterPatient(patient);
            ControlleFichiers.WriteXML(listPatientsAfficher.getListePatients());

        }

        private void ViderTextBox()
        {

            enNom.Text = "";
            enJour.SelectedItem = 1;
            enMois.SelectedItem = 1;
            enAnnee.SelectedItem = 1990;

            enAge.Text = "";
            enPoid.Text = "";
            enTaille.Text = "";

            ChackHomme.IsChecked = true;

            enProfession.Text = "";
            enAddresse.Text = "";
            enEmail.Text = "";
            enNumTele.Text = "";

            enFavorie.IsChecked = false;

            enCompte_rendu.Text = "";
            enAntecedents.Text = "";
            enNotesMedicale.Text = "";

        }

        private bool estVide()
        {
            if (
                enNom.Text.Equals("") && enAge.Text.Equals("") && enPoid.Text.Equals("") && enTaille.Text.Equals("")
                && enProfession.Text.Equals("") && enAddresse.Text.Equals("") && enEmail.Text.Equals("") && enNumTele.Text.Equals("")
                && enCompte_rendu.Text.Equals("") && enNotesMedicale.Text.Equals("") && enAntecedents.Text.Equals("")
               )
                return true;
            return false;
        }

        private void AfficherListeRechercher(List<Patient> Patients)
        {

            while (LISTES_DES_PATIENTS.Items.Count != 0)
            {
                LISTES_DES_PATIENTS.Items.Clear();
            }

            for (int i = 0; i < Patients.Count; i++)
            {
                LISTES_DES_PATIENTS.Items.Add(Patients[i]);
            }


        }

        private void AfficherToutListe()
        {

            while (LISTES_DES_PATIENTS.Items.Count != 0)
            {
                LISTES_DES_PATIENTS.Items.Clear();
            }


            List<Patient> Patients = ControlleFichiers.ReadXML();

            for (int i = 0; i < Patients.Count; i++)
            {
                LISTES_DES_PATIENTS.Items.Add(Patients[i]);
            }


        }

        private void remplirDataGridPatientInfo(Patient patient)
        {
            if (patient != null)
            {

                enNom.Text = (patient.Nom != null) ? patient.Nom.ToString() : "";
                enJour.SelectedItem = patient.Naissance.Day;
                enMois.SelectedItem = patient.Naissance.Month;
                enAnnee.SelectedItem = patient.Naissance.Year;

                enAge.Text = (patient.Nom != null) ? patient.Age.ToString() : "";
                enPoid.Text = patient.Poid.ToString();
                enTaille.Text = patient.Taille.ToString();

                ChackHomme.IsChecked = (patient.sexeHome == Patient.Sexe.Home) ? true : false;
                ChackFemme.IsChecked = (patient.sexeHome == Patient.Sexe.Home) ? false : true;

                enProfession.Text = (patient.Profession != null) ? patient.Profession.ToString() : "";
                enAddresse.Text = (patient.Addresse != null) ? patient.Addresse.ToString() : "";
                enEmail.Text = (patient.Email != null) ? patient.Email.ToString() : "";
                enNumTele.Text = patient.Telephone;

                enFavorie.IsChecked = patient.Favorie;

                enCompte_rendu.Text = (patient.Diagnostic != null) ? patient.Diagnostic.ToString() : "";
                enAntecedents.Text = (patient.Antecedents != null) ? patient.Antecedents.ToString() : "";
                enNotesMedicale.Text = (patient.Rapport != null) ? patient.Rapport.ToString() : "";

            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }

        private bool estModifie(Patient patient)
        {
            if (patient != null)
            {
                if (
                    !enNom.Text.Equals(patient.Nom) || !enAge.Text.Equals(patient.Age.ToString()) || !enPoid.Text.Equals(patient.Poid.ToString()) || !enTaille.Text.Equals(patient.Taille.ToString())
                    || !enProfession.Text.Equals(patient.Profession) || !enAddresse.Text.Equals(patient.Addresse) || !enEmail.Text.Equals(patient.Email) || !enNumTele.Text.Equals(patient.Telephone)
                    || !enCompte_rendu.Text.Equals(patient.Diagnostic) || !enNotesMedicale.Text.Equals(patient.Rapport) || !enAntecedents.Text.Equals(patient.Antecedents)
                    || (int.Parse(enJour.SelectedItem.ToString()) != patient.Naissance.Day) || (int.Parse(enMois.SelectedItem.ToString()) != patient.Naissance.Month) || (int.Parse(enAnnee.SelectedItem.ToString()) != patient.Naissance.Year)
                    || ChackHomme.IsChecked != ((patient.sexeHome == Patient.Sexe.Home) ? true : false) || ChackFemme.IsChecked != !((patient.sexeHome == Patient.Sexe.Home) ? true : false) || enFavorie.IsChecked != patient.Favorie
                   )
                    return true;
            }

            return false;
        }

        private void enregistrerPatientModifications(int IdSelected)
        {

            Patient patient = null;

            for (int i = 0; i < listPatientsAfficher.getListePatients().Count; i++)
            {
                if (listPatientsAfficher.getListePatients()[i].ID == IdSelected)
                {
                    patient = listPatientsAfficher.getListePatients()[i];
                    break;
                }
            }

            if (patient == null) patient = new Patient();

            patient.ID = IdSelected;
            patient.Nom = enNom.Text;
            patient.Naissance = new DateTime(int.Parse(enAnnee.SelectedItem.ToString()), int.Parse(enMois.SelectedItem.ToString()), int.Parse(enJour.SelectedItem.ToString()));
            patient.Age = enAge.Text;
            patient.Poid = (!enPoid.Text.Equals("")) ? int.Parse(enPoid.Text) : 0;
            patient.Taille = (!enTaille.Text.Equals("")) ? int.Parse(enTaille.Text) : 0;

            patient.sexeHome = (ChackHomme.IsChecked == true) ? Patient.Sexe.Home : Patient.Sexe.Femme;

            patient.Profession = enProfession.Text;
            patient.Addresse = enAddresse.Text;
            patient.Email = enEmail.Text;
            patient.Telephone = enNumTele.Text;

            patient.Favorie = (bool) enFavorie.IsChecked;

            patient.Diagnostic = enCompte_rendu.Text;
            patient.Antecedents = enAntecedents.Text;
            patient.Rapport = enNotesMedicale.Text;


            ControlleFichiers.WriteXML(listPatientsAfficher.getListePatients());

            AfficherToutListe();
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_EnregistrerPatient (object sender, RoutedEventArgs e)
        {
            btn_NomAjouterPatient.IsEnabled = true;
            if (!estVide())
            {

                if (listPatientsAfficher.clickAjouter)
                {
                    if (listPatientsAfficher.patientAfficherPres == null)
                    {
                        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Ajouter le Patient :" + enNom.Text, "Enregistrer", MessageBoxButtons.YesNo);

                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            AjouterPatient();
                        }
                        ViderTextBox();

                    }
                } else {

                    if (estModifie(listPatientsAfficher.patientAfficherPres))
                    {
                        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Enregistrer les modifications de :" + listPatientsAfficher.patientAfficherPres.Nom, "Enregistrer", MessageBoxButtons.YesNo);
                        
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            enregistrerPatientModifications(listPatientsAfficher.patientAfficherPres.ID);
                        }

                        ViderTextBox();
                        AfficherToutListe();
                    }
                }
                AfficherToutListe();

            }

        }

        private void btn_AjouterPatient(object sender, RoutedEventArgs e)
        {
            btn_NomAjouterPatient.IsEnabled = false;
            if (estModifie(listPatientsAfficher.patientAfficherPres))
            {

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Enregistrer les modifications de Patient", "Enregistrer", MessageBoxButtons.YesNo);

                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    enregistrerPatientModifications(listPatientsAfficher.patientAfficherPres.ID);
                }
            }

            ViderTextBox();
            listPatientsAfficher.patientAfficherPres = null;
            listPatientsAfficher.clickAjouter = true;

            AfficherToutListe();
        }

        private void btn_ModifierPatient (object sender, RoutedEventArgs e)
        {

            btn_NomAjouterPatient.IsEnabled = true;
            if (!estVide())
            {
                if (listPatientsAfficher.patientAfficherPres == null)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Ajouter le Patient :" + enNom.Text, "Enregistrer", MessageBoxButtons.YesNo);

                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        AjouterPatient();
                    }
                    ViderTextBox();

                }
                else if (estModifie(listPatientsAfficher.patientAfficherPres))
                {
                    enregistrerPatientModifications(listPatientsAfficher.patientAfficherPres.ID);
                }

            }

            listPatientsAfficher.clickAjouter = false;
            remplirDataGridPatientInfo((Patient)LISTES_DES_PATIENTS.SelectedItem);
            listPatientsAfficher.patientAfficherPres = (Patient)LISTES_DES_PATIENTS.SelectedItem;

            AfficherToutListe();
        }

        private void btn_SupprimerPatient (object sender, RoutedEventArgs e)
        {

            btn_NomAjouterPatient.IsEnabled = true;
            if (((Patient)LISTES_DES_PATIENTS.SelectedItem) != null)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("vous voulez supprimer le Patient ", "Enregistrer " + ((Patient)LISTES_DES_PATIENTS.SelectedItem).Nom + " ?"
                    , MessageBoxButtons.YesNo);

                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    listPatientsAfficher.supprimerPatient(((Patient)LISTES_DES_PATIENTS.SelectedItem).ID);
                    ControlleFichiers.WriteXML(listPatientsAfficher.getListePatients());
                    AfficherToutListe();
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Selectionner le Patient");
            }
        }

        private void btn_RecherchePatient(object sender, RoutedEventArgs e)
        {
            if (enRecherche.Text == null || enRecherche.Text.Equals(""))
            {
                AfficherToutListe();
                System.Windows.Forms.MessageBox.Show("Entrer le nom de Patient");
            }
            else
            {
                try
                {
                    AfficherListeRechercher(listPatientsAfficher.recherchePatientParID(int.Parse(enRecherche.Text)));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Entrer un numéro");
                }
            }
        }

        private void btn_RechercherFavories(object sender, RoutedEventArgs e)
        {
            AfficherListeRechercher(listPatientsAfficher.recherchePatientFavories());
        }

        private void btn_ToutListe (object sender, RoutedEventArgs e)
        {
            AfficherToutListe();
        }

        private void InitializingWindow()
        {

            listPatientsAfficher = new controllerListePatients(ControlleFichiers.ReadXML());

            AfficherToutListe();

            Modeles = new ControllerModelesProduits();
            marchandise = new controllerMarchandises();

            AfficherToutListeModele();
            AfficherToutListeMarchandise();

            ActualiseComboxModele(Modeles.getListeModeles());

            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                enAnnee.Items.Add(i);
                if (i == 1990)
                    enAnnee.SelectedItem = 1990;

            }

            for (int i = 1; i <= 31; i++)
            {
                enJour.Items.Add(i);
                if (i == 1)
                    enJour.SelectedItem = 1;

            }

            for (int i = 1; i <= 12; i++)
            {
                enMois.Items.Add(i);
                if (i == 1)
                    enMois.SelectedItem = 1;

            }

        }
        
        private void ActualiseComboxModele(List<Modele> mod)
        {
            comboxListModeles.Items.Clear();

            for (int i = 0; i < mod.Count; i++)
            {
                comboxListModeles.Items.Add(mod.ElementAt(i).Nom);
            }

            if (0 < comboxListModeles.Items.Count)
            {
                comboxListModeles.SelectedIndex = 0;
            }
        }


        private void btn_SupprimerMarchandise (object sender, RoutedEventArgs e)
        {
            
            if (LISTES_DES_MARCHANDISES.SelectedIndex != -1)
            {
                marchandise.supprimerMarchandise (((Marchandise)LISTES_DES_MARCHANDISES.SelectedItem).ID);
                AfficherToutListeMarchandise();
            }
            
        }
        
        private void btn_AjouterMarchandise(object sender, RoutedEventArgs e)
        {

            if (!estVideMarchandise())
            {
                double Quantite = 0;
                try
                {
                    Quantite = double.Parse(enPrix.Text.Replace(".", ","));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Le Prix est invalide");
                    return;
                }
                marchandise.AjouterMarchandise(comboxListModeles.SelectedItem.ToString(), enQuatite.Text, Quantite, enSource.Text);
                AfficherToutListeMarchandise();
                VideTextBoxMarchandise();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Saisir les informations de Marchandise");
            }

        }
        
        private void listDesProduits (object sender, RoutedEventArgs e)
        {

        }

        private bool estVideMarchandise()
        {
            if (string.IsNullOrEmpty(enQuatite.Text) || string.IsNullOrEmpty(enPrix.Text))
                return true;

            return false;
        }

        private void VideTextBoxMarchandise()
        {
            comboxListModeles.SelectedIndex = 0;
            enQuatite.Text = "";
            enPrix.Text = "";
            enSource.Text = "";
        }

        private void AfficherToutListeMarchandise()
        {

            while (LISTES_DES_MARCHANDISES.Items.Count != 0)
            {
                LISTES_DES_MARCHANDISES.Items.Clear();
            }


            List<Marchandise> marchandis = marchandise.getListeMarchandises();

            for (int i = 0; i < marchandis.Count; i++)
            {
                LISTES_DES_MARCHANDISES.Items.Add(marchandis[i]);
            }

        }







        private void listDesModeles(object sender, RoutedEventArgs e)
        {

        }

        private bool estVideModele()
        {
            if (string.IsNullOrEmpty(nomModele.Text))
                return true;

            return false;
        }

        private void VideTextBoxModele()
        {
            nomModele.Text = "";
            numRefer.Text = "";
            lieuStockage.Text = "";
        }
        
        private void AfficherToutListeModele()
        {

            while (LISTE_DES_MODELES.Items.Count != 0)
            {
                LISTE_DES_MODELES.Items.Clear();
            }


            List<Modele> modeles = Modeles.getListeModeles();

            for (int i = 0; i < modeles.Count; i++)
            {
                LISTE_DES_MODELES.Items.Add(modeles[i]);
            }


        }

        private void btn_SupprimerModele(object sender, RoutedEventArgs e)
        {
            if (LISTE_DES_MODELES.SelectedIndex != -1)
            {
                Modeles.supprimerModele(((Modele)LISTE_DES_MODELES.SelectedItem).ID);
                AfficherToutListeModele();
                ActualiseComboxModele(Modeles.getListeModeles());
            }

        }

        private void btn_AjouterModele(object sender, RoutedEventArgs e)
        {
            if (!estVideModele())
            {
                Modeles.AjouterModele(nomModele.Text, numRefer.Text, lieuStockage.Text);
                AfficherToutListeModele();
                VideTextBoxModele();
                ActualiseComboxModele(Modeles.getListeModeles());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Saisir le nom du Modèle");
            }
        }

    }
}
