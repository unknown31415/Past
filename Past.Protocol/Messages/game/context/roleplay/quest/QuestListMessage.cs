using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestListMessage : NetworkMessage
	{
        public short[] finishedQuestsIds;
        public short[] activeQuestsIds;
        public override uint Id
        {
        	get { return 5626; }
        }
        public QuestListMessage()
        {
        }
        public QuestListMessage(short[] finishedQuestsIds, short[] activeQuestsIds)
        {
            this.finishedQuestsIds = finishedQuestsIds;
            this.activeQuestsIds = activeQuestsIds;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)finishedQuestsIds.Length);
            foreach (var entry in finishedQuestsIds)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)activeQuestsIds.Length);
            foreach (var entry in activeQuestsIds)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            finishedQuestsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedQuestsIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            activeQuestsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 activeQuestsIds[i] = reader.ReadShort();
            }
		}
	}
}
