using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PaddockMoveItemRequestMessage : NetworkMessage
	{
        public short oldCellId;
        public short newCellId;
        public override uint Id
        {
        	get { return 6052; }
        }
        public PaddockMoveItemRequestMessage()
        {
        }
        public PaddockMoveItemRequestMessage(short oldCellId, short newCellId)
        {
            this.oldCellId = oldCellId;
            this.newCellId = newCellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(oldCellId);
            writer.WriteShort(newCellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            oldCellId = reader.ReadShort();
            if (oldCellId < 0 || oldCellId > 559)
                throw new Exception("Forbidden value on oldCellId = " + oldCellId + ", it doesn't respect the following condition : oldCellId < 0 || oldCellId > 559");
            newCellId = reader.ReadShort();
            if (newCellId < 0 || newCellId > 559)
                throw new Exception("Forbidden value on newCellId = " + newCellId + ", it doesn't respect the following condition : newCellId < 0 || newCellId > 559");
		}
	}
}
