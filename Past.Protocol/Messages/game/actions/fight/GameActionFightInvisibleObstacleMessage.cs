using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightInvisibleObstacleMessage : AbstractGameActionMessage
	{
        public int sourceSpellId;
        public override uint Id
        {
        	get { return 5820; }
        }
        public GameActionFightInvisibleObstacleMessage()
        {
        }
        public GameActionFightInvisibleObstacleMessage(short actionId, int sourceId, int sourceSpellId) : base(actionId, sourceId)
        {
            this.sourceSpellId = sourceSpellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(sourceSpellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            sourceSpellId = reader.ReadInt();
            if (sourceSpellId < 0)
                throw new Exception("Forbidden value on sourceSpellId = " + sourceSpellId + ", it doesn't respect the following condition : sourceSpellId < 0");
		}
	}
}
