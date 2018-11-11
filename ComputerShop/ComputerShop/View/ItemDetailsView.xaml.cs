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
    /// Interaction logic for ItemDetailsView.xaml
    /// </summary>
    public partial class ItemDetailsView : UserControl
    {
        public ItemDetailsView()
        {
            InitializeComponent();

            this.DataContext = new ItemDetailsViewModel();

            Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbxCount.IsReadOnly = false;
            tbxLocation.IsReadOnly = false;
            tbxModel.IsReadOnly = false;
            tbxName.IsReadOnly = false;
            tbInput2.IsReadOnly = false;
            cbxTypee.IsReadOnly = true;
            tbInput1.IsReadOnly = false;
            tbxPrice.IsReadOnly = false;
        }

        private void Initialize()
        {
            tbxCount.IsReadOnly = true;
            tbxLocation.IsReadOnly = true;
            tbxModel.IsReadOnly = true;
            tbxName.IsReadOnly = true;
            tbInput2.IsReadOnly = true;
            tbInput1.IsReadOnly = true;
            cbxTypee.IsReadOnly = true;
            tbxPrice.IsReadOnly = true;

            switch (cbxTypee.Text)
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
