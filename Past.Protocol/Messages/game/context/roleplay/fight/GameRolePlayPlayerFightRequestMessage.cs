using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
	{
        public int targetId;
        public bool friendly;
        public override uint Id
        {
        	get { return 5731; }
        }
        public GameRolePlayPlayerFightRequestMessage()
        {
        }
        public GameRolePlayPlayerFightRequestMessage(int targetId, bool friendly)
        {
            this.targetId = targetId;
            this.friendly = friendly;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(targetId);
            writer.WriteBoolean(friendly);
        }
        public override void Deserialize(IDataReader reader)
        {
            targetId = reader.ReadInt();
            if (targetId < 0)
                throw new Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < 0");
            friendly = reader.ReadBoolean();
		}
	}
}
