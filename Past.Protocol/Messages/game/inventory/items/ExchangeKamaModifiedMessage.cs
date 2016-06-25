using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
	{
        public int quantity;
        public override uint Id
        {
        	get { return 5521; }
        }
        public ExchangeKamaModifiedMessage()
        {
        }
        public ExchangeKamaModifiedMessage(bool remote, int quantity) : base(remote)
        {
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
		}
	}
}
