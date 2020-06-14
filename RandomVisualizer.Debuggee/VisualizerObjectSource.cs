using System;
using Periscope.Debuggee;

namespace RandomVisualizer.Debuggee {
    public class VisualizerObjectSource : VisualizerObjectSourceBase<Random, Config> {
        public override object GenerateResponse(Random rnd, Config config) => new Response(rnd, config);
    }
}
