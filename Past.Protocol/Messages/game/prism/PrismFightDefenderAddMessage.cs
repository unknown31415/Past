using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismFightDefenderAddMessage : NetworkMessage
	{
        public double fightId;
        public CharacterMinimalPlusLookAndGradeInformations fighterMovementInformations;
        public bool inMain;
        public override uint Id
        {
        	get { return 5895; }
        }
        public PrismFightDefenderAddMessage()
        {
        }
        public PrismFightDefenderAddMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations fighterMovementInformations, bool inMain)
        {
            this.fightId = fightId;
            this.fighterMovementInformations = fighterMovementInformations;
            this.inMain = inMain;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            fighterMovementInformations.Serialize(writer);
            writer.WriteBoolean(inMain);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            fighterMovementInformations = new CharacterMinimalPlusLookAndGradeInformations();
            fighterMovementInformations.Deserialize(reader);
            inMain = reader.ReadBoolean();
		}
	}
}
