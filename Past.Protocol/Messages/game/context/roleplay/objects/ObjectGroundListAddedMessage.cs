using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectGroundListAddedMessage : NetworkMessage
	{
        public short[] cells;
        public int[] referenceIds;
        public override uint Id
        {
        	get { return 5925; }
        }
        public ObjectGroundListAddedMessage()
        {
        }
        public ObjectGroundListAddedMessage(short[] cells, int[] referenceIds)
        {
            this.cells = cells;
            this.referenceIds = referenceIds;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)referenceIds.Length);
            foreach (var entry in referenceIds)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            referenceIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 referenceIds[i] = reader.ReadInt();
            }
		}
	}
}
