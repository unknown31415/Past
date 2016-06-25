using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ShowCellMessage : NetworkMessage
	{
        public int sourceId;
        public short cellId;
        public override uint Id
        {
        	get { return 5612; }
        }
        public ShowCellMessage()
        {
        }
        public ShowCellMessage(int sourceId, short cellId)
        {
            this.sourceId = sourceId;
            this.cellId = cellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(sourceId);
            writer.WriteShort(cellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            sourceId = reader.ReadInt();
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
		}
	}
}
