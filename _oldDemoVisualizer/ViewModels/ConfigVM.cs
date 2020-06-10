using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSpitz.Util;
using ZSpitz.Util.Wpf;

namespace _demoVisualizer.ViewModels {
    public class ConfigVM : ViewModelBase<Config> {
        public ReadOnlyCollection<Selectable<string>> AvailableWindowsIds { get; }
        public ReadOnlyCollection<Selectable<string>> AvailableTzdbIds { get; }

        public ConfigVM(Config config, IEnumerable<string> availableWindowsIds, IEnumerable<string> availableTzdbIds) : base(config) {
            AvailableWindowsIds = buildSelectables(availableWindowsIds, Model.SelectedWindowsIds);
            AvailableTzdbIds = buildSelectables(availableTzdbIds, Model.SelectedTzdbIds);

            ReadOnlyCollection<Selectable<string>> buildSelectables(IEnumerable<string> availables, HashSet<string> selected) =>
                availables.Ordered().Select(id => {
                    var ret = new Selectable<string>(id) {
                        IsSelected = id.In(selected)
                    };
                    ret.PropertyChanged += (s, e) => {
                        if (e.PropertyName != "IsSelected") { return; }
                        selected.AddRemove(ret.IsSelected, ret.Model);
                    };
                    return ret;
                }).ToReadOnlyCollection();
        }
    }
}
