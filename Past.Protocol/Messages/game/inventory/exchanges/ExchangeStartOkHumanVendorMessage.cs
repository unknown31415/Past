using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkHumanVendorMessage : NetworkMessage
	{
        public int sellerId;
        public ObjectItemToSell[] objectsInfos;
        public override uint Id
        {
        	get { return 5767; }
        }
        public ExchangeStartOkHumanVendorMessage()
        {
        }
        public ExchangeStartOkHumanVendorMessage(int sellerId, ObjectItemToSell[] objectsInfos)
        {
            this.sellerId = sellerId;
            this.objectsInfos = objectsInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(sellerId);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            sellerId = reader.ReadInt();
            if (sellerId < 0)
                throw new Exception("Forbidden value on sellerId = " + sellerId + ", it doesn't respect the following condition : sellerId < 0");
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
