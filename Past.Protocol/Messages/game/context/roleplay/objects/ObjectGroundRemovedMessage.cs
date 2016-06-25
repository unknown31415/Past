using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectGroundRemovedMessage : NetworkMessage
	{
        public short cell;
        public override uint Id
        {
        	get { return 3014; }
        }
        public ObjectGroundRemovedMessage()
        {
        }
        public ObjectGroundRemovedMessage(short cell)
        {
            this.cell = cell;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(cell);
        }
        public override void Deserialize(IDataReader reader)
        {
            cell = reader.ReadShort();
            if (cell < 0 || cell > 559)
                throw new Exception("Forbidden value on cell = " + cell + ", it doesn't respect the following condition : cell < 0 || cell > 559");
		}
	}
}
