using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestValidatedMessage : NetworkMessage
	{
        public ushort questId;
        public override uint Id
        {
        	get { return 6097; }
        }
        public QuestValidatedMessage()
        {
        }
        public QuestValidatedMessage(ushort questId)
        {
            this.questId = questId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(questId);
        }
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadUShort();
            if (questId < 0 || questId > 65535)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0 || questId > 65535");
		}
	}
}
