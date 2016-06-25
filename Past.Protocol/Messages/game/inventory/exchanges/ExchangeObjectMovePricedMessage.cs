using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
	{
        public int price;
        public override uint Id
        {
        	get { return 5514; }
        }
        public ExchangeObjectMovePricedMessage()
        {
        }
        public ExchangeObjectMovePricedMessage(int objectUID, short quantity, int price) : base(objectUID, quantity)
        {
            this.price = price;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(price);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            price = reader.ReadInt();
		}
	}
}
