using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectGroundAddedMessage : NetworkMessage
	{
        public short cellId;
        public short objectGID;
        public override uint Id
        {
        	get { return 3017; }
        }
        public ObjectGroundAddedMessage()
        {
        }
        public ObjectGroundAddedMessage(short cellId, short objectGID)
        {
            this.cellId = cellId;
            this.objectGID = objectGID;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(cellId);
            writer.WriteShort(objectGID);
        }
        public override void Deserialize(IDataReader reader)
        {
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
            objectGID = reader.ReadShort();
            if (objectGID < 0)
                throw new Exception("Forbidden value on objectGID = " + objectGID + ", it doesn't respect the following condition : objectGID < 0");
		}
	}
}
