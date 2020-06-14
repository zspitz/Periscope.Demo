using Periscope.Debuggee;
using System;

namespace RandomVisualizer.Debuggee {
    [Serializable]
    public class Config : ConfigBase<Config> {
        public int NextNumbers { get; set; }
        public override Config Clone() => new Config { NextNumbers = NextNumbers };
        public override ConfigDiffStates Diff(Config baseline) =>
            NextNumbers == baseline.NextNumbers ?
                ConfigDiffStates.NoAction :
                ConfigDiffStates.NeedsTransfer;
    }
}
