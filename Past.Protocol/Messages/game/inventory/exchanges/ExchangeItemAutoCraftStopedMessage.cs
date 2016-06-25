using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
	{
        public sbyte reason;
        public override uint Id
        {
        	get { return 5810; }
        }
        public ExchangeItemAutoCraftStopedMessage()
        {
        }
        public ExchangeItemAutoCraftStopedMessage(sbyte reason)
        {
            this.reason = reason;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(reason);
        }
        public override void Deserialize(IDataReader reader)
        {
            reason = reader.ReadSByte();
		}
	}
}
