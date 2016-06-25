using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRequestedMessage : NetworkMessage
	{
        public sbyte exchangeType;
        public override uint Id
        {
        	get { return 5522; }
        }
        public ExchangeRequestedMessage()
        {
        }
        public ExchangeRequestedMessage(sbyte exchangeType)
        {
            this.exchangeType = exchangeType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(exchangeType);
        }
        public override void Deserialize(IDataReader reader)
        {
            exchangeType = reader.ReadSByte();
		}
	}
}
