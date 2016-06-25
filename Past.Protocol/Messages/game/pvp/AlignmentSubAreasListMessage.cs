using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AlignmentSubAreasListMessage : NetworkMessage
	{
        public short[] angelsSubAreas;
        public short[] evilsSubAreas;
        public override uint Id
        {
        	get { return 6059; }
        }
        public AlignmentSubAreasListMessage()
        {
        }
        public AlignmentSubAreasListMessage(short[] angelsSubAreas, short[] evilsSubAreas)
        {
            this.angelsSubAreas = angelsSubAreas;
            this.evilsSubAreas = evilsSubAreas;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)angelsSubAreas.Length);
            foreach (var entry in angelsSubAreas)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)evilsSubAreas.Length);
            foreach (var entry in evilsSubAreas)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            angelsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 angelsSubAreas[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            evilsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 evilsSubAreas[i] = reader.ReadShort();
            }
		}
	}
}
