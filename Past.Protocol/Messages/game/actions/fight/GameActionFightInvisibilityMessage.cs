using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
	{
        public int targetId;
        public sbyte state;
        public override uint Id
        {
        	get { return 5821; }
        }
        public GameActionFightInvisibilityMessage()
        {
        }
        public GameActionFightInvisibilityMessage(short actionId, int sourceId, int targetId, sbyte state) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.state = state;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteSByte(state);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            state = reader.ReadSByte();
		}
	}
}
