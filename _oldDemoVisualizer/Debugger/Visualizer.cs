using Microsoft.VisualStudio.DebuggerVisualizers;
using Periscope;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: DebuggerVisualizer(
    visualizer: typeof(_demoVisualizer.Visualizer),
    visualizerObjectSource: typeof(_demoVisualizer.DebuggeeObjectSource),
    Target = typeof(int),
    Description = "Demo visualizer")]


namespace _demoVisualizer {
    public class Visualizer : DialogDebuggerVisualizer {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider) =>
            Periscope.Visualizer.Show<VisualizerWindow, Config>(GetType(), objectProvider, new GithubProjectInfo("zspitz", "expressiontreevisualizer"));
        //Periscope.Visualizer.Show<VisualizerWindow, Config>(GetType(), objectProvider);
    }
}
