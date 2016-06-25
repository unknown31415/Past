using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildJoinedMessage : NetworkMessage
	{
        public string guildName;
        public GuildEmblem guildEmblem;
        public uint memberRights;
        public override uint Id
        {
        	get { return 5564; }
        }
        public GuildJoinedMessage()
        {
        }
        public GuildJoinedMessage(string guildName, GuildEmblem guildEmblem, uint memberRights)
        {
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;
            this.memberRights = memberRights;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(guildName);
            guildEmblem.Serialize(writer);
            writer.WriteUInt(memberRights);
        }
        public override void Deserialize(IDataReader reader)
        {
            guildName = reader.ReadUTF();
            guildEmblem = new GuildEmblem();
            guildEmblem.Deserialize(reader);
            memberRights = reader.ReadUInt();
            if (memberRights < 0 || memberRights > 4294967295)
                throw new Exception("Forbidden value on memberRights = " + memberRights + ", it doesn't respect the following condition : memberRights < 0 || memberRights > 4294967295");
		}
	}
}
