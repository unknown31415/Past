using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeWaitingResultMessage : NetworkMessage
	{
        public bool bwait;
        public override uint Id
        {
        	get { return 5786; }
        }
        public ExchangeWaitingResultMessage()
        {
        }
        public ExchangeWaitingResultMessage(bool bwait)
        {
            this.bwait = bwait;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(bwait);
        }
        public override void Deserialize(IDataReader reader)
        {
            bwait = reader.ReadBoolean();
		}
	}
}
