using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StorageObjectsUpdateMessage : NetworkMessage
	{
        public ObjectItem[] objectList;
        public override uint Id
        {
        	get { return 6036; }
        }
        public StorageObjectsUpdateMessage()
        {
        }
        public StorageObjectsUpdateMessage(ObjectItem[] objectList)
        {
            this.objectList = objectList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectList.Length);
            foreach (var entry in objectList)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectList = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectList[i] = new ObjectItem();
                 objectList[i].Deserialize(reader);
            }
		}
	}
}
