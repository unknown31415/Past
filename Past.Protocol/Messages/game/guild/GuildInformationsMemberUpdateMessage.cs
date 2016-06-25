using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInformationsMemberUpdateMessage : NetworkMessage
	{
        public GuildMember member;
        public override uint Id
        {
        	get { return 5597; }
        }
        public GuildInformationsMemberUpdateMessage()
        {
        }
        public GuildInformationsMemberUpdateMessage(GuildMember member)
        {
            this.member = member;
        }
        public override void Serialize(IDataWriter writer)
        {
            member.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            member = new GuildMember();
            member.Deserialize(reader);
		}
	}
}
