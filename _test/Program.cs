using Microsoft.VisualStudio.DebuggerVisualizers;
using RandomVisualizer;
using System;

namespace _test {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            var rnd = new Random();
            var visualizerHost = new VisualizerDevelopmentHost(rnd, typeof(Visualizer), typeof(RandomVisualizer.Debuggee.VisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }
    }
}
