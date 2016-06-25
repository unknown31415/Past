using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildLeftMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5562; }
        }
        public GuildLeftMessage()
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
