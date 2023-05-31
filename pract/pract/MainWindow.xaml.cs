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
                if (ResearcherListView.SelectedItem != null)
                {
                    PublicationController publicationController = new PublicationController();
                    List<Publication> publications = publicationController.SearchByResearcher(ResearcherListView.SelectedItem as Researcher);
                    return publications;
                }
                else
                {
                    return null;
                }
            }
        }

        private void EmploymentLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] != null)
            {
                if (e.AddedItems[0].ToString().EndsWith("Student"))
                {
                    ResearcherListView.ItemsSource = ResearcherController.FilterByType(true, Researchers);
                }
                else if (e.AddedItems[0].ToString().EndsWith("Staff"))
                {
                    ResearcherListView.ItemsSource = ResearcherController.FilterByType(false, Researchers);
                }
                else
                {
                    ResearcherListView.ItemsSource = Researchers;
                }
            }
        }

        private void PublicationsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PublicationsListView.SelectedItem != null)
            {
                PublicationDetailsStackPanel.DataContext = PublicationsListView.SelectedItem as Publication;
            }
        }

        private void ResearcherListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                PublicationsListView.ItemsSource = Publications;

                if (e.AddedItems[0] is Researcher researcher)
                {
                    var photo = new Image();

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(researcher.Photo);
                    bitmap.EndInit();
                    ImageSource imageSource = bitmap;

                    ResearcherPhoto.Source = imageSource;
                }
            }
        }
    }
}
