using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class MapCoordinatesExtended : MapCoordinates
    {
        public int mapId;
        public new const short Id = 176;
        public override short TypeId
        {
            get { return Id; }
        }
        public MapCoordinatesExtended()
        {
        }
        public MapCoordinatesExtended(short worldX, short worldY, int mapId) : base(worldX, worldY)
        {
            this.mapId = mapId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(mapId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
        }
    }
}
