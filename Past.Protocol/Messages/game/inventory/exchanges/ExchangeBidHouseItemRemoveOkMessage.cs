using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
	{
        public int sellerId;
        public override uint Id
        {
        	get { return 5946; }
        }
        public ExchangeBidHouseItemRemoveOkMessage()
        {
        }
        public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            this.sellerId = sellerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(sellerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            sellerId = reader.ReadInt();
		}
	}
}
