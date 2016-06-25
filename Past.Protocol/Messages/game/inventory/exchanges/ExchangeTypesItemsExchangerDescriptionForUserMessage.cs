using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
	{
        public BidExchangerObjectInfo[] itemTypeDescriptions;
        public override uint Id
        {
        	get { return 5752; }
        }
        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }
        public ExchangeTypesItemsExchangerDescriptionForUserMessage(BidExchangerObjectInfo[] itemTypeDescriptions)
        {
            this.itemTypeDescriptions = itemTypeDescriptions;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)itemTypeDescriptions.Length);
            foreach (var entry in itemTypeDescriptions)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            itemTypeDescriptions = new BidExchangerObjectInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 itemTypeDescriptions[i] = new BidExchangerObjectInfo();
                 itemTypeDescriptions[i].Deserialize(reader);
            }
		}
	}
}
