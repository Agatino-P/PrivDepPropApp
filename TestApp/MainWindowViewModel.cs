using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public MainWindowViewModel()
        {
            VMInt = 104;
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
