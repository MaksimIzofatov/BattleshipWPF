using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BattleshipWPF.ViewModels
{
  public class BattleshipVM : ViewModelBase
  {
    private DispatcherTimer _timer;
    private DateTime _startTime;
    private string _time;
    public string Time { get => _time; private set => Set(ref _time, value); }
    public CellVM[][] OurMap { get; private set; } 
    public CellVM[][] EnemyMap { get; private set; }

    private string _map = @"
**********
*XXXX***X*
******X***
XX*XX***XX
******X***
*XXX******
*****XXX**
**********
*X********
**********
";

    public BattleshipVM()
    {
      _timer = new DispatcherTimer();
      _timer.Interval = TimeSpan.FromMilliseconds(100);
      _timer.Tick += Timer_Tick;
      _time = "";

      OurMap = MapFactory(_map);
      EnemyMap = MapFactory(_map);
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
      var now = DateTime.Now;
      var dt = now - _startTime;
      Time = $"{(int)dt.TotalMinutes:D2}:{dt.Seconds:D2}";
    }

    public void Start()
    {
      _startTime = DateTime.Now;
      _timer.Start();
    }

    public void Stop()
    {
      _timer.Stop();
    }

    private CellVM[][] MapFactory(string shipMap)
    {
      var ships = shipMap.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
      var map = new CellVM[10][];

      for (int i = 0; i < map.Length; i++)
      {
        map[i] = new CellVM[10];
        for (int j = 0; j < map[i].Length; j++)
        {
          map[i][j] = new CellVM(ships[i][j]);
        }
      }

      return map;
    }

    public void ShotToOurMap(int x, int y)
    {
      OurMap[y][x].ToShot();
    }
  }
}
