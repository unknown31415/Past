using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectMovementMessage : NetworkMessage
	{
        public int objectUID;
        public byte position;
        public override uint Id
        {
        	get { return 3010; }
        }
        public ObjectMovementMessage()
        {
        }
        public ObjectMovementMessage(int objectUID, byte position)
        {
            this.objectUID = objectUID;
            this.position = position;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectUID);
            writer.WriteByte(position);
        }
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            position = reader.ReadByte();
            if (position < 0 || position > 255)
                throw new Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 255");
		}
	}
}
