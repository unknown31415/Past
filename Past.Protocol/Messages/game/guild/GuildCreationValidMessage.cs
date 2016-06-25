using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildCreationValidMessage : NetworkMessage
	{
        public string guildName;
        public GuildEmblem guildEmblem;
        public override uint Id
        {
        	get { return 5546; }
        }
        public GuildCreationValidMessage()
        {
        }
        public GuildCreationValidMessage(string guildName, GuildEmblem guildEmblem)
        {
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(guildName);
            guildEmblem.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            guildName = reader.ReadUTF();
            guildEmblem = new GuildEmblem();
            guildEmblem.Deserialize(reader);
		}
	}
}
