using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StorageObjectsRemoveMessage : NetworkMessage
	{
        public int[] objectUIDList;
        public override uint Id
        {
        	get { return 6035; }
        }
        public StorageObjectsRemoveMessage()
        {
        }
        public StorageObjectsRemoveMessage(int[] objectUIDList)
        {
            this.objectUIDList = objectUIDList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectUIDList.Length);
            foreach (var entry in objectUIDList)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectUIDList = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUIDList[i] = reader.ReadInt();
            }
		}
	}
}
