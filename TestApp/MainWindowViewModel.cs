using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;

namespace TestApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _vmInt;
        public int VMInt
        {
            get => _vmInt;
            set
            {
                Set(() => VMInt, ref _vmInt, value);
            }
        }

        private IEnumerable<int> _VMNumbers; 
        public IEnumerable<int> VMNumbers { get => _VMNumbers; set { Set(() => VMNumbers, ref _VMNumbers, value); }}

        public MainWindowViewModel()
        {
            VMInt = 104;
            VMNumbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        }

        private RelayCommand _showCmd;
        public RelayCommand ShowCmd => _showCmd ?? (_showCmd = new RelayCommand(
            () => show(),
            () => true,
            keepTargetAlive: true
            ));
        private void show()
        {
            MessageBox.Show(VMInt.ToString());
        }

    }
}
