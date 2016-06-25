using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismInfoCloseMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5853; }
        }
        public PrismInfoCloseMessage()
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
