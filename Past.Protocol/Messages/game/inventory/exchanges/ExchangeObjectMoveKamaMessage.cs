using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectMoveKamaMessage : NetworkMessage
	{
        public int quantity;
        public override uint Id
        {
        	get { return 5520; }
        }
        public ExchangeObjectMoveKamaMessage()
        {
        }
        public ExchangeObjectMoveKamaMessage(int quantity)
        {
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            quantity = reader.ReadInt();
		}
	}
}
