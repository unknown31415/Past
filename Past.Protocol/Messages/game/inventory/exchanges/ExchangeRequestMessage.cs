using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRequestMessage : NetworkMessage
	{
        public sbyte exchangeType;
        public override uint Id
        {
        	get { return 5505; }
        }
        public ExchangeRequestMessage()
        {
        }
        public ExchangeRequestMessage(sbyte exchangeType)
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
