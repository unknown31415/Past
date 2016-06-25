using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NpcDialogCreationMessage : NetworkMessage
	{
        public int mapId;
        public int npcId;
        public override uint Id
        {
        	get { return 5618; }
        }
        public NpcDialogCreationMessage()
        {
        }
        public NpcDialogCreationMessage(int mapId, int npcId)
        {
            this.mapId = mapId;
            this.npcId = npcId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteInt(npcId);
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            npcId = reader.ReadInt();
		}
	}
}
