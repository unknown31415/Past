using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
	{
        public double fightId;
        public CharacterMinimalPlusLookInformations playerInfo;
        public override uint Id
        {
        	get { return 5720; }
        }
        public GuildFightPlayersHelpersJoinMessage()
        {
        }
        public GuildFightPlayersHelpersJoinMessage(double fightId, CharacterMinimalPlusLookInformations playerInfo)
        {
            this.fightId = fightId;
            this.playerInfo = playerInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            playerInfo.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            playerInfo = new CharacterMinimalPlusLookInformations();
            playerInfo.Deserialize(reader);
		}
	}
}
