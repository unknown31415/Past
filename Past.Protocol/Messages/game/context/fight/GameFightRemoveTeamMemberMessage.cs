using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightRemoveTeamMemberMessage : NetworkMessage
	{
        public short fightId;
        public sbyte teamId;
        public int charId;
        public override uint Id
        {
        	get { return 711; }
        }
        public GameFightRemoveTeamMemberMessage()
        {
        }
        public GameFightRemoveTeamMemberMessage(short fightId, sbyte teamId, int charId)
        {
            this.fightId = fightId;
            this.teamId = teamId;
            this.charId = charId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(fightId);
            writer.WriteSByte(teamId);
            writer.WriteInt(charId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            charId = reader.ReadInt();
		}
	}
}
