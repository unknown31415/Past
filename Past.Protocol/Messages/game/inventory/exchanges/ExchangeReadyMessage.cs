using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeReadyMessage : NetworkMessage
	{
        public bool ready;
        public override uint Id
        {
        	get { return 5511; }
        }
        public ExchangeReadyMessage()
        {
        }
        public ExchangeReadyMessage(bool ready)
        {
            this.ready = ready;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ready);
        }
        public override void Deserialize(IDataReader reader)
        {
            ready = reader.ReadBoolean();
		}
	}
}
