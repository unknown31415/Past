using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
	{
        public short markId;
        public int triggeringCharacterId;
        public short triggeredSpellId;
        public override uint Id
        {
        	get { return 5741; }
        }
        public GameActionFightTriggerGlyphTrapMessage()
        {
        }
        public GameActionFightTriggerGlyphTrapMessage(short actionId, int sourceId, short markId, int triggeringCharacterId, short triggeredSpellId) : base(actionId, sourceId)
        {
            this.markId = markId;
            this.triggeringCharacterId = triggeringCharacterId;
            this.triggeredSpellId = triggeredSpellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(markId);
            writer.WriteInt(triggeringCharacterId);
            writer.WriteShort(triggeredSpellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            markId = reader.ReadShort();
            triggeringCharacterId = reader.ReadInt();
            triggeredSpellId = reader.ReadShort();
            if (triggeredSpellId < 0)
                throw new Exception("Forbidden value on triggeredSpellId = " + triggeredSpellId + ", it doesn't respect the following condition : triggeredSpellId < 0");
		}
	}
}
