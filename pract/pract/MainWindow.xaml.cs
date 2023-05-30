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
using Entity;
using Controller;

namespace pract
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public List<Researcher> Researchers
        {
            get
            {
                ResearcherController researcherController = new ResearcherController();
                return researcherController.LoadAllResearchers();
            }
        }



        public List<Publication> Publications
        {
            get
            {
                PublicationController publicationController = new PublicationController();
                return publicationController.LoadAll();
            }
        }




        private void ResearcherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
