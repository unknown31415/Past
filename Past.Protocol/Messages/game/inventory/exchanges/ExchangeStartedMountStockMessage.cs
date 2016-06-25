using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartedMountStockMessage : NetworkMessage
	{
        public ObjectItem[] objectsInfos;
        public override uint Id
        {
        	get { return 5984; }
        }
        public ExchangeStartedMountStockMessage()
        {
        }
        public ExchangeStartedMountStockMessage(ObjectItem[] objectsInfos)
        {
            this.objectsInfos = objectsInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new ObjectItem();
                 objectsInfos[i].Deserialize(reader);
            }
		}
	}
}
