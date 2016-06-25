using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
	{
        public int fightId;
        public bool accept;
        public override uint Id
        {
        	get { return 5732; }
        }
        public GameRolePlayPlayerFightFriendlyAnswerMessage()
        {
        }
        public GameRolePlayPlayerFightFriendlyAnswerMessage(int fightId, bool accept)
        {
            this.fightId = fightId;
            this.accept = accept;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteBoolean(accept);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            accept = reader.ReadBoolean();
		}
	}
}
