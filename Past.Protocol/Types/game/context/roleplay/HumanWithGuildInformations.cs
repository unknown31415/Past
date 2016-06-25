using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class HumanWithGuildInformations : HumanInformations
    {
        public GuildInformations guildInformations;
        public new const short Id = 153;
        public override short TypeId
        {
            get { return Id; }
        }
        public HumanWithGuildInformations()
        {
        }
        public HumanWithGuildInformations(EntityLook[] followingCharactersLook, sbyte emoteId, ushort emoteEndTime, ActorRestrictionsInformations restrictions, short titleId, GuildInformations guildInformations) : base(followingCharactersLook, emoteId, emoteEndTime, restrictions, titleId)
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
