using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _demoVisualizer {
    [Serializable]
    public class AppliedZoneResult {
        public Instant? AsLocal1 { get; }
        public Instant? AsLocal2 { get; }
        public AppliedZoneResult(LocalDateTime local, DateTimeZone dateTimeZone) {
            try {
                AsLocal1 = local.InZoneStrictly(dateTimeZone).ToInstant();
            } catch (AmbiguousTimeException ambiguousTimeException) {
                AsLocal1 = ambiguousTimeException.EarlierMapping.ToInstant();
                AsLocal2 = ambiguousTimeException.LaterMapping.ToInstant();
            } catch (SkippedTimeException) {
                // intentionally blank
            }
        }
    }
}
