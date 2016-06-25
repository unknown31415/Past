using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectDeletedMessage : NetworkMessage
	{
        public int objectUID;
        public override uint Id
        {
        	get { return 3024; }
        }
        public ObjectDeletedMessage()
        {
        }
        public ObjectDeletedMessage(int objectUID)
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
