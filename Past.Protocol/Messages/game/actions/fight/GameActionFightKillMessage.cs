using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightKillMessage : AbstractGameActionMessage
	{
        public int targetId;
        public override uint Id
        {
        	get { return 5571; }
        }
        public GameActionFightKillMessage()
        {
        }
        public GameActionFightKillMessage(short actionId, int sourceId, int targetId) : base(actionId, sourceId)
        {
            this.targetId = targetId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
		}
	}
}
