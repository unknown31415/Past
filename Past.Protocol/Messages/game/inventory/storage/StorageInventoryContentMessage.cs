using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StorageInventoryContentMessage : InventoryContentMessage
	{
        public override uint Id
        {
        	get { return 5646; }
        }
        public StorageInventoryContentMessage()
        {
        }
        public StorageInventoryContentMessage(ObjectItem[] objects, int kamas) : base(objects, kamas)
        {
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
		}
	}
}
