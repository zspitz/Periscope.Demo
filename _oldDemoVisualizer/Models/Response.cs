using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using ZSpitz.Util;
using static System.DateTimeKind;

namespace _demoVisualizer {
    [Serializable]
    public class Response {
        public Instant? AsUtc { get; }
        public AppliedZoneResult? AsLocal { get; }

        // Using the Tzdb provider instead of the Bcl provider
        // see https://stackoverflow.com/questions/21029489/getting-the-systems-localdatetime-in-noda-time#comment85883649_21031514
        public string DebuggeeTimeZone { get; }

        public List<KeyValuePair<string, AppliedZoneResult?>> BclAdditional { get; }
        public List<KeyValuePair<string, AppliedZoneResult?>> TzdbAdditional { get; }

        public HashSet<string> AvailableWindowsIds { get; }
        public HashSet<string> AvailableTzdbIds { get; }
        public Config Config { get; }

        public Response(DateTime source, Config config) {
            Config = config;
            AvailableWindowsIds = DateTimeZoneProviders.Bcl.Ids.ToHashSet();
            AvailableTzdbIds = DateTimeZoneProviders.Tzdb.Ids.ToHashSet();

            var debuggeeTimeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            DebuggeeTimeZone = debuggeeTimeZone.Id;

            var local = LocalDateTime.FromDateTime(source);

            if (source.Kind.In(Utc, Unspecified)) {
                AsUtc = Instant.FromDateTimeUtc(source);
            }
            if (source.Kind.In(Local, Unspecified)) {
                AsLocal = new AppliedZoneResult(local, debuggeeTimeZone);
            }

            BclAdditional = buildResultsList(config.SelectedWindowsIds, DateTimeZoneProviders.Bcl);
            TzdbAdditional = buildResultsList(config.SelectedTzdbIds, DateTimeZoneProviders.Tzdb);

            List<KeyValuePair<string, AppliedZoneResult?>> buildResultsList(IEnumerable<string> ids, IDateTimeZoneProvider provider) =>
                ids.Select(id => {
                    AppliedZoneResult? result = null;
                    DateTimeZone? zone = provider.GetZoneOrNull(id);
                    if (zone is { }) {
                        result = new AppliedZoneResult(local, zone);
                    }
                    return new KeyValuePair<string, AppliedZoneResult?>(id, result);
                }).ToList();
        }
    }
}
