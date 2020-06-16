using Periscope.Debuggee;
using RandomVisualizer;
using RandomVisualizer.Debuggee;
using System;
using System.Diagnostics;

[assembly: DebuggerVisualizer(
    visualizer: typeof(Visualizer),
    visualizerObjectSource: typeof(VisualizerObjectSource),
    Target = typeof(Random),
    Description = "Random visualizer")]

namespace RandomVisualizer {
    public class Visualizer : Periscope.VisualizerBase<VisualizerWindow, Config> {
        static Visualizer() => SubfolderAssemblyResolver.Hook("RandomVisualizer"); 
    }
}
