using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public short firstNameId;
        public short lastNameId;
        public GuildInformations guildIdentity;
        public byte guildLevel;
        public new const short Id = 148;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayTaxCollectorInformations()
        {
        }
        public GameRolePlayTaxCollectorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, short firstNameId, short lastNameId, GuildInformations guildIdentity, byte guildLevel) : base(contextualId, look, disposition)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.guildIdentity = guildIdentity;
            this.guildLevel = guildLevel;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(firstNameId);
            writer.WriteShort(lastNameId);
            guildIdentity.Serialize(writer);
            writer.WriteByte(guildLevel);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            firstNameId = reader.ReadShort();
            if (firstNameId < 0)
                throw new Exception("Forbidden value on firstNameId = " + firstNameId + ", it doesn't respect the following condition : firstNameId < 0");
            lastNameId = reader.ReadShort();
            if (lastNameId < 0)
                throw new Exception("Forbidden value on lastNameId = " + lastNameId + ", it doesn't respect the following condition : lastNameId < 0");
            guildIdentity = new GuildInformations();
            guildIdentity.Deserialize(reader);
            guildLevel = reader.ReadByte();
            if (guildLevel < 0 || guildLevel > 255)
                throw new Exception("Forbidden value on guildLevel = " + guildLevel + ", it doesn't respect the following condition : guildLevel < 0 || guildLevel > 255");
        }
    }
}
