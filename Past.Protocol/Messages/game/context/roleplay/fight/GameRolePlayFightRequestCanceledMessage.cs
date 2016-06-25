using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
	{
        public int fightId;
        public int sourceId;
        public int targetId;
        public override uint Id
        {
        	get { return 5822; }
        }
        public GameRolePlayFightRequestCanceledMessage()
        {
        }
        public GameRolePlayFightRequestCanceledMessage(int fightId, int sourceId, int targetId)
        {
            this.fightId = fightId;
            this.sourceId = sourceId;
            this.targetId = targetId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteInt(sourceId);
            writer.WriteInt(targetId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            sourceId = reader.ReadInt();
            if (sourceId < 0)
                throw new Exception("Forbidden value on sourceId = " + sourceId + ", it doesn't respect the following condition : sourceId < 0");
            targetId = reader.ReadInt();
		}
	}
}
