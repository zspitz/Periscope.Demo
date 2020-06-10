using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSpitz.Util.Wpf;

namespace _demoVisualizer {
    public class ResponseVM : ViewModelBase<Response> {
        public ICommand? OpenInNewWindow { get; private set; }
        public RelayCommand? CopyWatchExpression { get; private set; }

        public ResponseVM(Response response, ICommand? openInNewWindow = null, RelayCommand? copyWatchExpression = null) : base(response) {
            OpenInNewWindow = openInNewWindow;
            CopyWatchExpression = copyWatchExpression;
        }
    }
}
