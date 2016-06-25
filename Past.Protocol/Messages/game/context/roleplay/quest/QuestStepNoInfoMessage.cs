using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestStepNoInfoMessage : NetworkMessage
	{
        public short questId;
        public override uint Id
        {
        	get { return 5627; }
        }
        public QuestStepNoInfoMessage()
        {
        }
        public QuestStepNoInfoMessage(short questId)
        {
            this.questId = questId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(questId);
        }
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadShort();
            if (questId < 0)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
		}
	}
}
