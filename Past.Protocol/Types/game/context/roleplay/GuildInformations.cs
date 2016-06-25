using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GuildInformations
    {
        public string guildName;
        public GuildEmblem guildEmblem;
        public const short Id = 127;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public GuildInformations()
        {
        }
        public GuildInformations(string guildName, GuildEmblem guildEmblem)
        {
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(guildName);
            guildEmblem.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            guildName = reader.ReadUTF();
            guildEmblem = new Types.GuildEmblem();
            guildEmblem.Deserialize(reader);
        }
    }
}
