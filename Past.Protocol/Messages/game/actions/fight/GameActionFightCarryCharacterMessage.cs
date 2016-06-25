using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightCarryCharacterMessage : AbstractGameActionMessage
	{
        public int targetId;
        public override uint Id
        {
        	get { return 5830; }
        }
        public GameActionFightCarryCharacterMessage()
        {
        }
        public GameActionFightCarryCharacterMessage(short actionId, int sourceId, int targetId) : base(actionId, sourceId)
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
