using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeReplayStopMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6001; }
        }
        public ExchangeReplayStopMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
