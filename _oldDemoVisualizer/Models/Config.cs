using Periscope.Debuggee;
using System;
using System.Collections.Generic;
using ZSpitz.Util;

namespace _demoVisualizer {
    [Serializable]
    public class Config : ConfigBase<Config> {
        public HashSet<string> SelectedTzdbIds { get; } = new HashSet<string>();
        public HashSet<string> SelectedWindowsIds { get; } = new HashSet<string>();
        public Config(IEnumerable<string>? tzdbIdentifiers, IEnumerable<string>? windowsIdentifiers) {
            if (tzdbIdentifiers is null || windowsIdentifiers is null) { return; }
            SelectedTzdbIds.AddRange(tzdbIdentifiers);
            SelectedWindowsIds.AddRange(windowsIdentifiers);
        }

        public override Config Clone() => new Config(SelectedTzdbIds, SelectedWindowsIds);
        public override ConfigDiffStates Diff(Config baseline) =>
            //(
            //    SelectedTzdbIds.SetEquals(baseline.SelectedTzdbIds) &&
            //    SelectedWindowsIds.SetEquals(baseline.SelectedWindowsIds)
            //) ? default : ConfigDiffStates.NeedsTransfer;
            ConfigDiffStates.NeedsTransfer;
    }
}
