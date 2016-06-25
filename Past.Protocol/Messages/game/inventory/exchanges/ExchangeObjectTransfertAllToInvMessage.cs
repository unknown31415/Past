using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectTransfertAllToInvMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6032; }
        }
        public ExchangeObjectTransfertAllToInvMessage()
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
