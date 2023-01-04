using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleshipWPF.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
    {
      if ( field != null && !field.Equals(value))
      {
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
      }
    }

    protected void Fire(params string[] names)
    {
      foreach (var name in names)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
    }
  }
}