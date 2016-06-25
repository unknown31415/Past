using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
	{
        public int targetId;
        public short delta;
        public override uint Id
        {
        	get { return 1030; }
        }
        public GameActionFightPointsVariationMessage()
        {
        }
        public GameActionFightPointsVariationMessage(short actionId, int sourceId, int targetId, short delta) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.delta = delta;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(delta);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            delta = reader.ReadShort();
		}
	}
}
