using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightStateChangeMessage : AbstractGameActionMessage
	{
        public int targetId;
        public short stateId;
        public bool active;
        public override uint Id
        {
        	get { return 5569; }
        }
        public GameActionFightStateChangeMessage()
        {
        }
        public GameActionFightStateChangeMessage(short actionId, int sourceId, int targetId, short stateId, bool active) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.stateId = stateId;
            this.active = active;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(stateId);
            writer.WriteBoolean(active);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            stateId = reader.ReadShort();
            active = reader.ReadBoolean();
		}
	}
}
