using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismFightDefendersStateMessage : NetworkMessage
	{
        public double fightId;
        public CharacterMinimalPlusLookAndGradeInformations[] mainFighters;
        public CharacterMinimalPlusLookAndGradeInformations[] reserveFighters;
        public override uint Id
        {
        	get { return 5899; }
        }
        public PrismFightDefendersStateMessage()
        {
        }
        public PrismFightDefendersStateMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations[] mainFighters, CharacterMinimalPlusLookAndGradeInformations[] reserveFighters)
        {
            this.fightId = fightId;
            this.mainFighters = mainFighters;
            this.reserveFighters = reserveFighters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort)mainFighters.Length);
            foreach (var entry in mainFighters)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)reserveFighters.Length);
            foreach (var entry in reserveFighters)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            mainFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 mainFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                 mainFighters[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            reserveFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 reserveFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                 reserveFighters[i].Deserialize(reader);
            }
		}
	}
}
