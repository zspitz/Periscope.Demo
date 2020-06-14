using System;
using System.Collections.Generic;

namespace Periscope.Demo {
    [Serializable]
    public class Response {
        public Response(Random rnd, Config config) {
            Config = config;
            for (var i = 0; i < config.NextNumbers; i++) {
                Numbers.Add(rnd.Next());
            }
        }

        public Config Config { get; set; }
        public List<int> Numbers { get; } = new List<int>();
    }
}
