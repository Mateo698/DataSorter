using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
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

namespace DataSorter
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedItem != null)
            {

            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                dataTable.ItemsSource = bindData(openFileDialog.FileName);
            }
        }

        public List<Municipality> filteredData(string path)
        {
            var lines = File.ReadAllLines(path);

            var data = from l in lines.Skip(1)
                       let split = l.Split(',')
                       if (true)
            {
                select new Municipality
                {
                    depCode = split[0],
                    munCode = split[1],
                    depName = split[2],
                    munName = split[3],
                    type = split[4]
                };
            };
                       
            return data.ToList();
        }

        public List<Municipality> bindData(string path)
        {
            var lines = File.ReadAllLines(path);

            List<String> deps = new List<String>();

            foreach (var line in lines.Skip(1))
            {
                string[] parts = line.Split(',');
                if(!deps.Contains(parts[2]))
                {
                    deps.Add(parts[2]);
                };
            }

            comboBox.ItemsSource = deps;

            var data = from l in lines.Skip(1)
                       let split = l.Split(',')
                        select new Municipality
                        {
                            depCode = split[0],
                            munCode = split[1],
                            depName = split[2],
                            munName = split[3],
                            type = split[4]
                        };
            return data.ToList();
        }
    }

    public class Municipality
    {
        public string depCode { get; set; }
        public string munCode { get; set; }    
        public string depName { get; set; }
        public string munName { get; set; }
        public string type { get; set; }

    }
}
