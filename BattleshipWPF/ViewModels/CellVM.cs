using System.Windows;

namespace BattleshipWPF.ViewModels
{
  public class CellVM : ViewModelBase
  {
    private bool _ship, _shot;

    public CellVM(char state)
    {
      _ship = state == 'X';
    }

    public Visibility Miss => _shot && !_ship ? Visibility.Visible : Visibility.Collapsed;

    public Visibility Shot => _shot && _ship ? Visibility.Visible : Visibility.Collapsed;

    public void ToShot()
    {
      _shot = true;
      Fire("Miss", "Shot");
    }

    
  }
}