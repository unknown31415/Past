using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseGuildRightsMessage : NetworkMessage
	{
        public short houseId;
        public string guildName;
        public GuildEmblem guildEmblem;
        public uint rights;
        public override uint Id
        {
        	get { return 5703; }
        }
        public HouseGuildRightsMessage()
        {
        }
        public HouseGuildRightsMessage(short houseId, string guildName, GuildEmblem guildEmblem, uint rights)
        {
            this.houseId = houseId;
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;
            this.rights = rights;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(houseId);
            writer.WriteUTF(guildName);
            guildEmblem.Serialize(writer);
            writer.WriteUInt(rights);
        }
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadShort();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            guildName = reader.ReadUTF();
            guildEmblem = new GuildEmblem();
            guildEmblem.Deserialize(reader);
            rights = reader.ReadUInt();
            if (rights < 0 || rights > 4294967295)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0 || rights > 4294967295");
		}
	}
}
