using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildCreationStartedMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5920; }
        }
        public GuildCreationStartedMessage()
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
