using _demoVisualizer.ViewModels;
using Periscope;
using System;
using System.Windows.Input;

namespace _demoVisualizer {
    public partial class VisualizerWindow : VisualizerWindowBase {
        public VisualizerWindow() => InitializeComponent();

        protected override void TransformConfig(Config config, object parameter) => throw new NotImplementedException();
        protected override (object windowContext, object optionsContext, Config config) GetViewState(object r, ICommand? OpenInNewWindow) {
            var response = (Response)r;
            return (
                new ResponseVM(response, OpenInNewWindow, Periscope.Visualizer.CopyWatchExpression),
                new ConfigVM(response.Config, response.AvailableWindowsIds, response.AvailableTzdbIds),
                response.Config
            );
        }
    }
}
