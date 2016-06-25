using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeShopStockStartedMessage : NetworkMessage
	{
        public ObjectItemToSell[] objectsInfos;
        public override uint Id
        {
        	get { return 5910; }
        }
        public ExchangeShopStockStartedMessage()
        {
        }
        public ExchangeShopStockStartedMessage(ObjectItemToSell[] objectsInfos)
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
            objectsInfos = new ObjectItemToSell[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new ObjectItemToSell();
                 objectsInfos[i].Deserialize(reader);
            }
		}
	}
}
