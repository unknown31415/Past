using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountStableErrorMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5981; }
        }
        public ExchangeMountStableErrorMessage()
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
