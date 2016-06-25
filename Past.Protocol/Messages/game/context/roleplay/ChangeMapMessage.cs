using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChangeMapMessage : NetworkMessage
	{
        public int mapId;
        public override uint Id
        {
        	get { return 221; }
        }
        public ChangeMapMessage()
        {
        }
        public ChangeMapMessage(int mapId)
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
