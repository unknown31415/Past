using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightUpdateTeamMessage : NetworkMessage
	{
        public short fightId;
        public FightTeamInformations team;
        public override uint Id
        {
        	get { return 5572; }
        }
        public GameFightUpdateTeamMessage()
        {
        }
        public GameFightUpdateTeamMessage(short fightId, FightTeamInformations team)
        {
            this.fightId = fightId;
            this.team = team;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(fightId);
            team.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            team = new FightTeamInformations();
            team.Deserialize(reader);
		}
	}
}
