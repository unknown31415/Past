using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameRolePlayMerchantWithGuildInformations : GameRolePlayMerchantInformations
    {
        public GuildInformations guildInformations;
        public new const short Id = 146;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayMerchantWithGuildInformations()
        {
        }
        public GameRolePlayMerchantWithGuildInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, int sellType, GuildInformations guildInformations) : base(contextualId, look, disposition, name, sellType)
        {
            this.guildInformations = guildInformations;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            guildInformations.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guildInformations = new GuildInformations();
            guildInformations.Deserialize(reader);
        }
    }
}
