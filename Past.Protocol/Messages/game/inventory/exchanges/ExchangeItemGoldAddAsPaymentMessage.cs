using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeItemGoldAddAsPaymentMessage : NetworkMessage
	{
        public sbyte paymentType;
        public int quantity;
        public override uint Id
        {
        	get { return 5770; }
        }
        public ExchangeItemGoldAddAsPaymentMessage()
        {
        }
        public ExchangeItemGoldAddAsPaymentMessage(sbyte paymentType, int quantity)
        {
            this.paymentType = paymentType;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(paymentType);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            paymentType = reader.ReadSByte();
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
		}
	}
}
