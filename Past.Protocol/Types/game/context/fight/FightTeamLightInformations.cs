using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public sbyte teamMembersCount;
        public new const short Id = 115;
        public override short TypeId
        {
            get { return Id; }
        }
        public FightTeamLightInformations()
        {
        }
        public FightTeamLightInformations(sbyte teamId, int leaderId, sbyte teamSide, sbyte teamMembersCount) : base(teamId, leaderId, teamSide)
        {
            this.teamMembersCount = teamMembersCount;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(teamMembersCount);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            teamMembersCount = reader.ReadSByte();
            if (teamMembersCount < 0)
                throw new Exception("Forbidden value on teamMembersCount = " + teamMembersCount + ", it doesn't respect the following condition : teamMembersCount < 0");
        }
    }
}
