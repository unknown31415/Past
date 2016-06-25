using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestObjectiveValidationMessage : NetworkMessage
	{
        public short questId;
        public short objectiveId;
        public override uint Id
        {
        	get { return 6085; }
        }
        public QuestObjectiveValidationMessage()
        {
        }
        public QuestObjectiveValidationMessage(short questId, short objectiveId)
        {
            this.questId = questId;
            this.objectiveId = objectiveId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(questId);
            writer.WriteShort(objectiveId);
        }
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadShort();
            if (questId < 0)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            objectiveId = reader.ReadShort();
            if (objectiveId < 0)
                throw new Exception("Forbidden value on objectiveId = " + objectiveId + ", it doesn't respect the following condition : objectiveId < 0");
		}
	}
}
