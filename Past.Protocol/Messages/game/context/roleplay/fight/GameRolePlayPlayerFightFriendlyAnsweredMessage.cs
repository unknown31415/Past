using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayPlayerFightFriendlyAnsweredMessage : NetworkMessage
	{
        public int fightId;
        public int sourceId;
        public int targetId;
        public bool accept;
        public override uint Id
        {
        	get { return 5733; }
        }
        public GameRolePlayPlayerFightFriendlyAnsweredMessage()
        {
        }
        public GameRolePlayPlayerFightFriendlyAnsweredMessage(int fightId, int sourceId, int targetId, bool accept)
        {
            this.fightId = fightId;
            this.sourceId = sourceId;
            this.targetId = targetId;
            this.accept = accept;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteInt(sourceId);
            writer.WriteInt(targetId);
            writer.WriteBoolean(accept);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            sourceId = reader.ReadInt();
            if (sourceId < 0)
                throw new Exception("Forbidden value on sourceId = " + sourceId + ", it doesn't respect the following condition : sourceId < 0");
            targetId = reader.ReadInt();
            if (targetId < 0)
                throw new Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < 0");
            accept = reader.ReadBoolean();
		}
	}
}
