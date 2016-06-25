using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class InventoryContentMessage : NetworkMessage
	{
        public ObjectItem[] objects;
        public int kamas;
        public override uint Id
        {
        	get { return 3016; }
        }
        public InventoryContentMessage()
        {
        }
        public InventoryContentMessage(ObjectItem[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
            writer.WriteInt(kamas);
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objects = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = new ObjectItem();
                 objects[i].Deserialize(reader);
            }
            kamas = reader.ReadInt();
            if (kamas < 0)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
		}
	}
}
