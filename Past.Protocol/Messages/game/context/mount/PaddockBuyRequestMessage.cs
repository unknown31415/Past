using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PaddockBuyRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5951; }
        }
        public PaddockBuyRequestMessage()
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
