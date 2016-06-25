using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TeleportOnSameMapMessage : NetworkMessage
	{
        public int targetId;
        public short cellId;
        public override uint Id
        {
        	get { return 6048; }
        }
        public TeleportOnSameMapMessage()
        {
        }
        public TeleportOnSameMapMessage(int targetId, short cellId)
        {
            this.targetId = targetId;
            this.cellId = cellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(targetId);
            writer.WriteShort(cellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            targetId = reader.ReadInt();
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
		}
	}
}
