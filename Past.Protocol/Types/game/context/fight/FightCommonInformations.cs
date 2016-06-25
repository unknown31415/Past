using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FightCommonInformations
    {
        public int fightId;
        public sbyte fightType;
        public FightTeamInformations[] fightTeams;
        public short[] fightTeamsPositions;
        public FightOptionsInformations[] fightTeamsOptions;
        public const short Id = 43;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public FightCommonInformations()
        {
        }
        public FightCommonInformations(int fightId, sbyte fightType, FightTeamInformations[] fightTeams, short[] fightTeamsPositions, FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightTeams = fightTeams;
            this.fightTeamsPositions = fightTeamsPositions;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteSByte(fightType);
            writer.WriteUShort((ushort)fightTeams.Length);
            foreach (var entry in fightTeams)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)fightTeamsPositions.Length);
            foreach (var entry in fightTeamsPositions)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)fightTeamsOptions.Length);
            foreach (var entry in fightTeamsOptions)
            {
                entry.Serialize(writer);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            fightType = reader.ReadSByte();
            if (fightType < 0)
                throw new Exception("Forbidden value on fightType = " + fightType + ", it doesn't respect the following condition : fightType < 0");
            var limit = reader.ReadUShort();
            fightTeams = new Types.FightTeamInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeams[i] = (FightTeamInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                fightTeams[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fightTeamsPositions = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeamsPositions[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            fightTeamsOptions = new Types.FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeamsOptions[i] = new Types.FightOptionsInformations();
                fightTeamsOptions[i].Deserialize(reader);
            }
        }
    }
}
                              
