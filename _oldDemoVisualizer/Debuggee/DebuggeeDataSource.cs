using System;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace _demoVisualizer {
    public class DebuggeeObjectSource : VisualizerObjectSource {
        public override void GetData(object target, Stream outgoingData) =>
            Serialize(outgoingData, "");

        public override void TransferData(object target, Stream incomingData, Stream outgoingData) {
            var config = (Config)Deserialize(incomingData);
            var serializationModel = new Response(DateTime.Now, config);
            Serialize(outgoingData, serializationModel);
        }
    }
}
