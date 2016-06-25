using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AlignmentAreaUpdateMessage : NetworkMessage
	{
        public short areaId;
        public sbyte side;
        public override uint Id
        {
        	get { return 6060; }
        }
        public AlignmentAreaUpdateMessage()
        {
        }
        public AlignmentAreaUpdateMessage(short areaId, sbyte side)
        {
            this.areaId = areaId;
            this.side = side;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(areaId);
            writer.WriteSByte(side);
        }
        public override void Deserialize(IDataReader reader)
        {
            areaId = reader.ReadShort();
            if (areaId < 0)
                throw new Exception("Forbidden value on areaId = " + areaId + ", it doesn't respect the following condition : areaId < 0");
            side = reader.ReadSByte();
		}
	}
}
