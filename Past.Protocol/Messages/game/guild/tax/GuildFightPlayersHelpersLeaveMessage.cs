using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildFightPlayersHelpersLeaveMessage : NetworkMessage
	{
        public double fightId;
        public int playerId;
        public override uint Id
        {
        	get { return 5719; }
        }
        public GuildFightPlayersHelpersLeaveMessage()
        {
        }
        public GuildFightPlayersHelpersLeaveMessage(double fightId, int playerId)
        {
            this.fightId = fightId;
            this.playerId = playerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(playerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
		}
	}
}
