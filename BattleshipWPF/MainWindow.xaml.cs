using BattleshipWPF.ViewModels;
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
using System.Windows.Threading;

namespace BattleshipWPF
{
  public partial class MainWindow : Window
  {
    private BattleshipVM _battleshipVM;
    private Random _random = new Random();
    public MainWindow()
    {
      _battleshipVM = new BattleshipVM();
      DataContext = _battleshipVM;
      InitializeComponent();
    }
    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
      var border = sender as Border;
      var cell = border.DataContext as CellVM;
      cell.ToShot();

      int x = _random.Next(10);
      int y = _random.Next(10);
      _battleshipVM.ShotToOurMap(x, y);
    }
  }
}
