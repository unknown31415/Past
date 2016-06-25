using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
	{
        public int mapId;
        public int[] npcsIdsCanGiveQuest;
        public int[] npcsIdsCannotGiveQuest;
        public override uint Id
        {
        	get { return 5642; }
        }
        public MapNpcsQuestStatusUpdateMessage()
        {
        }
        public MapNpcsQuestStatusUpdateMessage(int mapId, int[] npcsIdsCanGiveQuest, int[] npcsIdsCannotGiveQuest)
        {
            this.mapId = mapId;
            this.npcsIdsCanGiveQuest = npcsIdsCanGiveQuest;
            this.npcsIdsCannotGiveQuest = npcsIdsCannotGiveQuest;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort)npcsIdsCanGiveQuest.Length);
            foreach (var entry in npcsIdsCanGiveQuest)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort)npcsIdsCannotGiveQuest.Length);
            foreach (var entry in npcsIdsCannotGiveQuest)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            var limit = reader.ReadUShort();
            npcsIdsCanGiveQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 npcsIdsCanGiveQuest[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            npcsIdsCannotGiveQuest = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 npcsIdsCannotGiveQuest[i] = reader.ReadInt();
            }
		}
	}
}
