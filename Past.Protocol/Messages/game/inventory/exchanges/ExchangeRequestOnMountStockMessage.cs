using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRequestOnMountStockMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5986; }
        }
        public ExchangeRequestOnMountStockMessage()
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
