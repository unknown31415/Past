using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TeleportRequestMessage : NetworkMessage
	{
        public sbyte teleporterType;
        public int mapId;
        public override uint Id
        {
        	get { return 5961; }
        }
        public TeleportRequestMessage()
        {
        }
        public TeleportRequestMessage(sbyte teleporterType, int mapId)
        {
            this.teleporterType = teleporterType;
            this.mapId = mapId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(teleporterType);
            writer.WriteInt(mapId);
        }
        public override void Deserialize(IDataReader reader)
        {
            teleporterType = reader.ReadSByte();
            if (teleporterType < 0)
                throw new Exception("Forbidden value on teleporterType = " + teleporterType + ", it doesn't respect the following condition : teleporterType < 0");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
		}
	}
}
