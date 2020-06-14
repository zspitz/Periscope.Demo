using System;
using System.Windows.Input;

namespace Periscope.Demo {
    public abstract class VisualizerWindowBase : VisualizerWindowBase<VisualizerWindow, Config> {
        protected override (object windowContext, object optionsContext, Config config) GetViewState(object r, ICommand? OpenInNewWindow) {
            var response = (Response)r;
            return (response, response.Config, response.Config);
        }

        // we don't need this unless we're allowing OpenInNewWindow
        protected override void TransformConfig(Config config, object parameter) => throw new NotImplementedException();
    }
}
