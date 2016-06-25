using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
    {
        public short firstNameId;
        public short lastNameId;
        public byte level;
        public new const short Id = 177;
        public override short TypeId
        {
            get { return Id; }
        }
        public FightTeamMemberTaxCollectorInformations()
        {
        }
        public FightTeamMemberTaxCollectorInformations(int id, short firstNameId, short lastNameId, byte level) : base(id)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.level = level;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(firstNameId);
            writer.WriteShort(lastNameId);
            writer.WriteByte(level);
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
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
        }
    }
}