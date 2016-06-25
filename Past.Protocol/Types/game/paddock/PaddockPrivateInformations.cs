using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class PaddockPrivateInformations : PaddockAbandonnedInformations
    {
        public string guildName;
        public GuildEmblem guildEmblem;
        public new const short Id = 131;
        public override short TypeId
        {
            get { return Id; }
        }
        public PaddockPrivateInformations()
        {
        }
        public PaddockPrivateInformations(short maxOutdoorMount, short maxItems, int price, int guildId, string guildName, GuildEmblem guildEmblem) : base(maxOutdoorMount, maxItems, price, guildId)
        {
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(guildName);
            guildEmblem.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guildName = reader.ReadUTF();
            guildEmblem = new GuildEmblem();
            guildEmblem.Deserialize(reader);
        }
    }
}