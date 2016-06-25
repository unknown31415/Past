using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInvitationAnswerMessage : NetworkMessage
	{
        public bool accept;
        public override uint Id
        {
        	get { return 5556; }
        }
        public GuildInvitationAnswerMessage()
        {
        }
        public GuildInvitationAnswerMessage(bool accept)
        {
            this.accept = accept;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(accept);
        }
        public override void Deserialize(IDataReader reader)
        {
            accept = reader.ReadBoolean();
		}
	}
}
