using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class HouseInformationsExtended : HouseInformations
    {
        public string guildName;
        public GuildEmblem guildEmblem;
        public new const short Id = 112;
        public override short TypeId
        {
            get { return Id; }
        }
        public HouseInformationsExtended()
        {
        }
        public HouseInformationsExtended(int houseId, int[] doorsOnMap, string ownerName, bool isOnSale, short modelId, string guildName, GuildEmblem guildEmblem) : base(houseId, doorsOnMap, ownerName, isOnSale, modelId)
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
            guildEmblem = new Types.GuildEmblem();
            guildEmblem.Deserialize(reader);
        }
    }
}
