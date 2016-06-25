using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildFightPlayersEnemiesListMessage : NetworkMessage
	{
        public double fightId;
        public CharacterMinimalPlusLookInformations[] playerInfo;
        public override uint Id
        {
        	get { return 5928; }
        }
        public GuildFightPlayersEnemiesListMessage()
        {
        }
        public GuildFightPlayersEnemiesListMessage(double fightId, CharacterMinimalPlusLookInformations[] playerInfo)
        {
            this.fightId = fightId;
            this.playerInfo = playerInfo;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort)playerInfo.Length);
            foreach (var entry in playerInfo)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadUShort();
            playerInfo = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 playerInfo[i] = new CharacterMinimalPlusLookInformations();
                 playerInfo[i].Deserialize(reader);
            }
		}
	}
}
