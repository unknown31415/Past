using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StorageObjectRemoveMessage : NetworkMessage
	{
        public int objectUID;
        public override uint Id
        {
        	get { return 5648; }
        }
        public StorageObjectRemoveMessage()
        {
        }
        public StorageObjectRemoveMessage(int objectUID)
        {
            this.objectUID = objectUID;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectUID);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
		}
	}
}
