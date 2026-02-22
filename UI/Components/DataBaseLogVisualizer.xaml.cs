using DataLayer.Model;
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

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for DataBaseLogVisualizer.xaml
    /// </summary>
    public partial class DataBaseLogVisualizer : UserControl
    {
        public DataBaseLogVisualizer()
        {
            InitializeComponent();

            using (var ctx = new DataLayer.Database.DatabaseContext())
            {
                var records = ctx.UserLogs.ToList();
                Logs.DataContext = records;

            }
        }

        private void ExpandLogData(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow)
            {
                var row = (DataGridRow)sender;
                var log = (DatabaseUserLog)row.Item;
                MessageBox.Show(log.LogMessage);
            }
        }
    }
}
