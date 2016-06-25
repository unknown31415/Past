using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightPassNextTurnsMessage : AbstractGameActionMessage
	{
        public int targetId;
        public sbyte turnCount;
        public override uint Id
        {
        	get { return 5529; }
        }
        public GameActionFightPassNextTurnsMessage()
        {
        }
        public GameActionFightPassNextTurnsMessage(short actionId, int sourceId, int targetId, sbyte turnCount) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.turnCount = turnCount;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteSByte(turnCount);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            turnCount = reader.ReadSByte();
            if (turnCount < 0)
                throw new Exception("Forbidden value on turnCount = " + turnCount + ", it doesn't respect the following condition : turnCount < 0");
		}
	}
}
