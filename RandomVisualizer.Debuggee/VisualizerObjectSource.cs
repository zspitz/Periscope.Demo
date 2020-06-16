using System;
using Periscope.Debuggee;

namespace RandomVisualizer.Debuggee {
    public class VisualizerObjectSource : VisualizerObjectSourceBase<Random, Config> {
        static VisualizerObjectSource() => SubfolderAssemblyResolver.Hook("RandomVisualizer");

        public override object GetResponse(Random target, Config config) => new Response(target, config);
    }
}
