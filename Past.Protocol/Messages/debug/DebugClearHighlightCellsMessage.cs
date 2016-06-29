using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
    public class DebugClearHighlightCellsMessage : NetworkMessage
    {
        public override uint Id
        {
            get { return 2002; }
        }
        public DebugClearHighlightCellsMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
        }
    }
}
