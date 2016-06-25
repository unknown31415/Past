using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildMembershipMessage : GuildJoinedMessage
	{
        public override uint Id
        {
        	get { return 5835; }
        }
        public GuildMembershipMessage()
        {
        }
        public GuildMembershipMessage(string guildName, GuildEmblem guildEmblem, uint memberRights) : base(guildName, guildEmblem, memberRights)
        {
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
		}
	}
}
