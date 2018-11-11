using ComputerShop.ViewModel;
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

namespace ComputerShop.View
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : UserControl
    {
        public AddItemView()
        {
            InitializeComponent();
            this.DataContext = new AddItemViewModel();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxTypee.SelectedItem)
            {
                case "GPU":
                    lblGpu1.Visibility = Visibility.Visible;
                    lblGpu2.Visibility = Visibility.Visible;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Visible;
                    break;
                case "Case":
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Visible;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Hidden;
                    break;
                case "CPU":
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Visible;
                    lblCpu2.Visibility = Visibility.Visible;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Visible;
                    break;
                case "RAM":
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Visible;
                    lblRam2.Visibility = Visibility.Visible;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Visible;
                    break;
                case "Motherboard":
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Visible;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Hidden;
                    break;
                case "Memory":
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Visible;
                    lblMemory2.Visibility = Visibility.Visible;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Visible;
                    tbInput2.Visibility = Visibility.Visible;
                    break;
                default:
                    lblGpu1.Visibility = Visibility.Hidden;
                    lblGpu2.Visibility = Visibility.Hidden;
                    lblCase.Visibility = Visibility.Hidden;
                    lblCpu1.Visibility = Visibility.Hidden;
                    lblCpu2.Visibility = Visibility.Hidden;
                    lblMb.Visibility = Visibility.Hidden;
                    lblMemory1.Visibility = Visibility.Hidden;
                    lblMemory2.Visibility = Visibility.Hidden;
                    lblRam1.Visibility = Visibility.Hidden;
                    lblRam2.Visibility = Visibility.Hidden;
                    tbInput1.Visibility = Visibility.Hidden;
                    tbInput2.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
