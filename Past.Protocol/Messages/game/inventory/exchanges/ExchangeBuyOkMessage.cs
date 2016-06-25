using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBuyOkMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5759; }
        }
        public ExchangeBuyOkMessage()
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
