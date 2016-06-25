using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightChangeLookMessage : AbstractGameActionMessage
	{
        public int targetId;
        public EntityLook entityLook;
        public override uint Id
        {
        	get { return 5532; }
        }
        public GameActionFightChangeLookMessage()
        {
        }
        public GameActionFightChangeLookMessage(short actionId, int sourceId, int targetId, EntityLook entityLook) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.entityLook = entityLook;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            entityLook.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            entityLook = new EntityLook();
            entityLook.Deserialize(reader);
		}
	}
}
