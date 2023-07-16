using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace WpfDataWorks2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Node> nodes;
        Employee bob;

        public MainWindow()
        {
            InitializeComponent();

            nodes = new ObservableCollection<Node>()
            {
                new Node(){ Name = "File 1" },
                new Node(){ Name = "File 2" },
                new Node(){ Name = "Folder 1",
                            Nodes = new ObservableCollection<Node>()
                            {
                                new Node{ Name = "File 3" },
                                new Node{ Name = "File 4" },
                            }
                },
                new Node{ Name = "File 5" },
                new Node(){ Name = "Folder 2",
                            Nodes = new ObservableCollection<Node>()
                            {
                                new Node{ Name = "File 6" },
                                new Node{ Name = "Folder 3",
                                          Nodes = new ObservableCollection<Node>()
                                          {
                                              new Node{ Name = "File 7" },
                                              new Node{ Name = "File 8" },
                                          } 
                                        },
                            },
                          },
            };

            //treeFiles.ItemsSource = nodes;

            bob = new Employee();
            this.DataContext = bob;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Node>));
            using(FileStream fs = new("files.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, nodes);
            }
        }
    }
}
