using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class AtlasPointsInformations
    {
        public sbyte type;
        public MapCoordinatesExtended[] coords;
        public const short Id = 175;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public AtlasPointsInformations()
        {
        }
        public AtlasPointsInformations(sbyte type, MapCoordinatesExtended[] coords)
        {
            this.type = type;
            this.coords = coords;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteUShort((ushort)coords.Length);
            foreach (var entry in coords)
            {
                entry.Serialize(writer);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            var limit = reader.ReadUShort();
            coords = new MapCoordinatesExtended[limit];
            for (int i = 0; i < limit; i++)
            {
                coords[i] = new MapCoordinatesExtended();
                coords[i].Deserialize(reader);
            }
        }
    }
}
