using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismFightAttackerAddMessage : NetworkMessage
	{
        public double fightId;
        public CharacterMinimalPlusLookAndGradeInformations[] charactersDescription;
        public override uint Id
        {
        	get { return 5893; }
        }
        public PrismFightAttackerAddMessage()
        {
        }
        public PrismFightAttackerAddMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations[] charactersDescription)
        {
            this.fightId = fightId;
            this.charactersDescription = charactersDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort)charactersDescription.Length);
            foreach (var entry in charactersDescription)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            charactersDescription = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 charactersDescription[i] = new CharacterMinimalPlusLookAndGradeInformations();
                 charactersDescription[i].Deserialize(reader);
            }
		}
	}
}
