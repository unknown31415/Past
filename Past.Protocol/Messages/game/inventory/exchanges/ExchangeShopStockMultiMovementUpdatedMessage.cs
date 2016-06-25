using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
	{
        public ObjectItemToSell[] objectInfoList;
        public override uint Id
        {
        	get { return 6038; }
        }
        public ExchangeShopStockMultiMovementUpdatedMessage()
        {
        }
        public ExchangeShopStockMultiMovementUpdatedMessage(ObjectItemToSell[] objectInfoList)
        {
            this.objectInfoList = objectInfoList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectInfoList.Length);
            foreach (var entry in objectInfoList)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectInfoList = new ObjectItemToSell[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectInfoList[i] = new ObjectItemToSell();
                 objectInfoList[i].Deserialize(reader);
            }
		}
	}
}
