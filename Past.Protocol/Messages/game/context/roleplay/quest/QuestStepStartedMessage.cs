using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestStepStartedMessage : NetworkMessage
	{
        public ushort questId;
        public ushort stepId;
        public override uint Id
        {
        	get { return 6096; }
        }
        public QuestStepStartedMessage()
        {
        }
        public QuestStepStartedMessage(ushort questId, ushort stepId)
        {
            this.questId = questId;
            this.stepId = stepId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(questId);
            writer.WriteUShort(stepId);
        }
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadUShort();
            if (questId < 0 || questId > 65535)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0 || questId > 65535");
            stepId = reader.ReadUShort();
            if (stepId < 0 || stepId > 65535)
                throw new Exception("Forbidden value on stepId = " + stepId + ", it doesn't respect the following condition : stepId < 0 || stepId > 65535");
		}
	}
}
