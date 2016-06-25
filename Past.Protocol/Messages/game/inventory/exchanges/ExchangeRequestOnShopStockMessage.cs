using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRequestOnShopStockMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5753; }
        }
        public ExchangeRequestOnShopStockMessage()
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
