using DbMasajModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProMasaj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        DbMasajEntitiesModel ctx = new DbMasajEntitiesModel();
        CollectionViewSource clientVSource;
        CollectionViewSource angajatVSource;
        CollectionViewSource masajVSource;
        CollectionViewSource salaVSource;
        CollectionViewSource programareVSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        // Aici sunt butoanele de Add, Edit si Delete Generale
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            BindingOperations.ClearBinding(numeTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(prenumeTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            BindingOperations.ClearBinding(numeTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(prenumeTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        // Aici sunt butoanele de Next si Previous de la Client
        private void btnNextClient_Click(object sender, RoutedEventArgs e)
        {
            clientVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousClient_Click(object sender, RoutedEventArgs e)
        {
            clientVSource.View.MoveCurrentToPrevious();
        }

        // Aici sunt butoanele de Next si Previous de la Angajat
        private void btnNextAngajat_Click(object sender, RoutedEventArgs e)
        {
            angajatVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousAngajat_Click(object sender, RoutedEventArgs e)
        {
            angajatVSource.View.MoveCurrentToPrevious();
        }

        // Aici sunt butoanele de Next si Previous de la Masaj
        private void btnNextMasaj_Click(object sender, RoutedEventArgs e)
        {
            masajVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousMasaj_Click(object sender, RoutedEventArgs e)
        {
            masajVSource.View.MoveCurrentToPrevious();
        }

        // Aici sunt butoanele de Next si Previous de la Sala
        private void btnNextSala_Click(object sender, RoutedEventArgs e)
        {
            salaVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousSala_Click(object sender, RoutedEventArgs e)
        {
            salaVSource.View.MoveCurrentToPrevious();
        }

        // Aici e metoda SaveClient
        private void SaveClient()
        {
            Client client = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Client entity
                    client = new Client()
                    {
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim(),
                        NrTelefon = nrTelefonTextBox.Text.Trim(),
                        Email = emailTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Client.Add(client);
                    clientVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    client = (Client)clientDataGrid.SelectedItem;
                    client.Nume = numeTextBox.Text.Trim();
                    client.Prenume = prenumeTextBox.Text.Trim();//salvam modificarile
                    client.NrTelefon = nrTelefonTextBox.Text.Trim();
                    client.Email = emailTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    client = (Client)clientDataGrid.SelectedItem;
                    ctx.Client.Remove(client);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientVSource.View.Refresh();
            }

        }

        //Aici e metoda SaveAngajats
        private void SaveAngajats()
        {
            Angajat angajat = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Angajat entity
                    angajat = new Angajat()
                    {
                        Nume = numeTextBox1.Text.Trim(),
                        Prenume = prenumeTextBox1.Text.Trim(),
                        NrTelefon = nrTelefonTextBox1.Text.Trim(),
                        Salariu = int.Parse(salariuTextBox.Text.Trim())
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Angajats.Add(angajat);
                    angajatVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    angajat = (Angajat)angajatDataGrid.SelectedItem;
                    angajat.Nume = numeTextBox1.Text.Trim();
                    angajat.Prenume = prenumeTextBox1.Text.Trim();//salvam modificarile
                    angajat.NrTelefon = nrTelefonTextBox1.Text.Trim();
                    angajat.Salariu = int.Parse(salariuTextBox.Text.Trim());

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    angajat = (Angajat)angajatDataGrid.SelectedItem;
                    ctx.Angajats.Remove(angajat);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                angajatVSource.View.Refresh();
            }

        }

        //Aici e metoda SaveSala
        private void SaveSalas()
        {
            Sala sala = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Sala entity
                    sala = new Sala()
                    {
                        Numar = int.Parse(numarTextBox.Text.Trim()),
                        Etaj = int.Parse(etajTextBox.Text.Trim()),
                        Strada = stradaTextBox.Text.Trim(),
                        AngajatId = int.Parse(angajatIdTextBox1.Text.Trim())

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Salas.Add(sala);
                    salaVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sala = (Sala)salaDataGrid.SelectedItem;
                    sala.Numar = int.Parse(numarTextBox.Text.Trim());
                    sala.Etaj = int.Parse(etajTextBox.Text.Trim());
                    sala.Strada = stradaTextBox.Text.Trim();
                    sala.AngajatId = int.Parse(angajatIdTextBox1.Text.Trim());

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sala = (Sala)salaDataGrid.SelectedItem;
                    ctx.Salas.Remove(sala);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                salaVSource.View.Refresh();
            }

        }

        //Aici e metoda SaveMasajs
        private void SaveMasajs()
        {
            Masaj masaj = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Masaj entity
                    masaj = new Masaj()
                    {
                        Denumire = denumireTextBox.Text.Trim(),
                        Pret = pretTextBox.Text.Trim(),
                        Durata = int.Parse(durataTextBox.Text.Trim())
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Masajs.Add(masaj);
                    masajVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    masaj = (Masaj)masajDataGrid.SelectedItem;
                    masaj.Pret = pretTextBox.Text.Trim();
                    masaj.Durata = int.Parse(durataTextBox.Text.Trim());
                    masaj.Denumire = denumireTextBox.Text.Trim();

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    masaj = (Masaj)masajDataGrid.SelectedItem;
                    ctx.Masajs.Remove(masaj);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                masajVSource.View.Refresh();
            }

        }


        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlDbMasaj.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Client":
                    SaveClient();
                    break;
                case "Angajat":
                    SaveAngajats();
                    break;
                case "Masaj":
                    SaveMasajs();
                    break;
                case "Sala":
                    SaveSalas();
                    break;
                case "Programare":
                    SaveProgramares();
                    break;
            }
            ReInitialize();
        }
        
        // Aici este metoda SaveProgramare
        private void SaveProgramares()
        {
            Programare programare = null;
            if (action == ActionState.New)
            {
                try
                {
                    Client client = (Client)cmbClient.SelectedItem;
                    Angajat angajat = (Angajat)cmbAngajat.SelectedItem;
                    Masaj masaj = (Masaj)cmbMasaj.SelectedItem;
                    Sala sala = (Sala)cmbSala.SelectedItem;

                    //instantiem programare entity
                    programare = new Programare()
                    {
                        Ora = oraDatePicker.DisplayDate,
                        ClientId = client.ClientId,
                        AngajatId = angajat.AngajatId,
                        MasajId = masaj.MasajId,
                        SalaId = sala.SalaId
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Programares.Add(programare);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            if (action == ActionState.Edit)
            {
                dynamic selectedProgramare = programareDataGrid.SelectedItem;
                try
                {
                    programare.Ora = oraDatePicker.DisplayDate;
                    int curr_id = selectedProgramare.ProgramareId;
                    var editedProgramare = ctx.Programares.FirstOrDefault(s => s.ProgramareId == curr_id);
                   
                    if (editedProgramare != null)
                    {
                        editedProgramare.ClientId = Int32.Parse(cmbClient.SelectedValue.ToString());
                        editedProgramare.AngajatId = Convert.ToInt32(cmbAngajat.SelectedValue.ToString());
                        editedProgramare.MasajId = Int32.Parse(cmbMasaj.SelectedValue.ToString());
                        editedProgramare.SalaId = Int32.Parse(cmbSala.SelectedValue.ToString());


                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                programareVSource.View.MoveCurrentTo(selectedProgramare);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedProgramare = programareDataGrid.SelectedItem;
                    int curr_id = selectedProgramare.ProgramareId;
                    var deletedProgramare = ctx.Programares.FirstOrDefault(s => s.ProgramareId == curr_id);
                    if (deletedProgramare != null)
                    {
                        ctx.Programares.Remove(deletedProgramare);
                        ctx.SaveChanges();
                        MessageBox.Show("Programarea a fost stearsa cu succes!", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BindDataGrid()
        {
            var queryOrder = from ord in ctx.Programares
                             join clie in ctx.Client on ord.ClientId equals clie.ClientId
                             join ang in ctx.Angajats on ord.AngajatId equals ang.AngajatId
                             join mas in ctx.Masajs on ord.MasajId equals mas.MasajId
                             join inv in ctx.Salas on ord.SalaId equals inv.SalaId
                             select new
                             {
                                 ord.ProgramareId,
                                 ord.ClientId,
                                 ord.AngajatId,
                                 ord.MasajId,
                                 ord.SalaId,
                                 clie.Nume,
                                 clie.Prenume,
                                 mas.Denumire,
                                 inv.Strada
                                 //ang.Nume,
                                 //ang.Prenume
                             };
            programareVSource.Source = queryOrder.ToList();
        }

        private void SetValidationBinding()
        {
            Binding numeValidationBinding = new Binding();
            numeValidationBinding.Source = clientVSource;
            numeValidationBinding.Path = new PropertyPath("Nume");
            numeValidationBinding.NotifyOnValidationError = true;
            numeValidationBinding.Mode = BindingMode.TwoWay;
            numeValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //string required
            numeValidationBinding.ValidationRules.Add(new StringNotEmpty());
            numeTextBox.SetBinding(TextBox.TextProperty, numeValidationBinding);
            Binding prenumeValidationBinding = new Binding();
            prenumeValidationBinding.Source = clientVSource;
            prenumeValidationBinding.Path = new PropertyPath("Prenume");
            prenumeValidationBinding.NotifyOnValidationError = true;
            prenumeValidationBinding.Mode = BindingMode.TwoWay;
            prenumeValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //string min length validator
            prenumeValidationBinding.ValidationRules.Add(new StringMinLengthValidator());
            prenumeTextBox.SetBinding(TextBox.TextProperty, prenumeValidationBinding); //setare binding nou
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clientVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            clientVSource.Source = ctx.Client.Local;
            ctx.Client.Load();

            angajatVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatVSource.Source = ctx.Angajats.Local;
            ctx.Angajats.Load();

            masajVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("masajViewSource")));
            masajVSource.Source = ctx.Masajs.Local;
            ctx.Masajs.Load();

            salaVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salaViewSource")));
            salaVSource.Source = ctx.Salas.Local;
            ctx.Salas.Load();

            programareVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("programareViewSource")));
            //programareVSource.Source = ctx.Programares.Local;
            ctx.Programares.Load();

            BindDataGrid();

            cmbClient.ItemsSource = ctx.Client.Local;
            //cmbClient.DisplayMemberPath = "Nume";
            cmbClient.SelectedValuePath = "ClientId";

            cmbAngajat.ItemsSource = ctx.Angajats.Local;
            //cmbAngajat.DisplayMemberPath = "Nume";
            cmbAngajat.SelectedValuePath = "AngajatId";

            cmbMasaj.ItemsSource = ctx.Masajs.Local;
            cmbMasaj.DisplayMemberPath = "Denumire";
            cmbMasaj.SelectedValuePath = "MasajId";

            cmbSala.ItemsSource = ctx.Salas.Local;
            cmbSala.DisplayMemberPath = "Strada";
            cmbSala.SelectedValuePath = "SalaId";


            // System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // angajatViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource masajViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("masajViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // masajViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource salaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // salaViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource programareViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("programareViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // programareViewSource.Source = [generic data source]
        }
    }
}
