using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInformationsMembersMessage : NetworkMessage
	{
        public GuildMember[] members;
        public override uint Id
        {
        	get { return 5558; }
        }
        public GuildInformationsMembersMessage()
        {
        }
        public GuildInformationsMembersMessage(GuildMember[] members)
        {
            this.members = members;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)members.Length);
            foreach (var entry in members)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            members = new GuildMember[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = new GuildMember();
                 members[i].Deserialize(reader);
            }
		}
	}
}
