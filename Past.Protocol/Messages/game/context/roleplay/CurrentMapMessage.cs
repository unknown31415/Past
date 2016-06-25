using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CurrentMapMessage : NetworkMessage
	{
        public int mapId;
        public override uint Id
        {
        	get { return 220; }
        }
        public CurrentMapMessage()
        {
        }
        public CurrentMapMessage(int mapId)
        {
            this.mapId = mapId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
		}
	}
}
