using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ObjectsDeletedMessage : NetworkMessage
	{
        public int[] objectUID;
        public override uint Id
        {
        	get { return 6034; }
        }
        public ObjectsDeletedMessage()
        {
        }
        public ObjectsDeletedMessage(int[] objectUID)
        {
            this.objectUID = objectUID;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectUID.Length);
            foreach (var entry in objectUID)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectUID = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUID[i] = reader.ReadInt();
            }
		}
	}
}
