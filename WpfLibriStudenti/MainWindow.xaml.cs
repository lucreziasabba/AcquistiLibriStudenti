using System;
using System.Collections.Generic;
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
using Classi;

namespace WpfLibriStudenti
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Studente> studenti = new List<Studente>();
        public List<Libro> libri = new List<Libro>();

        int matricola = 1;
        int i = 1;
        

        private void btnCaricaStudente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNome.Text == "" || txtCognome.Text == "")
                {
                    MessageBox.Show("Inserire i valori", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtNome.Text = "";
                    txtCognome.Text = "";
                    txtNome.Focus();
                }
                else
                {
                    string nome = txtNome.Text;
                    string cognome = txtCognome.Text;
                    Studente s = new Studente(nome, cognome, matricola);
                    studenti.Add(s);
                    cmbStudenti.Items.Add(s.GetProprieta());
                    matricola++;
                    txtNome.Text = " ";
                    txtCognome.Text = " ";
                    txtNome.Focus();
                    cmbStudenti.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNome.Text = " ";
                txtCognome.Text = " ";
                txtNome.Focus();
            }
        }

        private void btnCaricaLibro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbMaterie.Text == "" || txtPrezzo.Text == "")
                {
                    MessageBox.Show("Inserire tutti i valori", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    cmbMaterie.Text = "";
                    txtPrezzo.Text = "";
                    cmbMaterie.Focus();
                }
                else
                {
                    string materia = cmbMaterie.Text;
                    double prezzo = double.Parse(txtPrezzo.Text);
                    string isbn = "lib2020-2021" + i.ToString();
                    i++;
                    Libro l = new Libro(materia, prezzo, isbn);

                    libri.Add(l);
                    cmbLibro.Items.Add(l.GetProprieta());
                    cmbMaterie.Text = "";
                    txtPrezzo.Text = "";
                    cmbMaterie.Focus();
                    cmbLibro.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmbMaterie.Text = "";
                txtPrezzo.Text = "";
                cmbMaterie.Focus();
            }
        }
    }
}
