using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AlignmentSubAreaUpdateMessage : NetworkMessage
	{
        public short subAreaId;
        public sbyte side;
        public bool quiet;
        public override uint Id
        {
        	get { return 6057; }
        }
        public AlignmentSubAreaUpdateMessage()
        {
        }
        public AlignmentSubAreaUpdateMessage(short subAreaId, sbyte side, bool quiet)
        {
            this.subAreaId = subAreaId;
            this.side = side;
            this.quiet = quiet;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(subAreaId);
            writer.WriteSByte(side);
            writer.WriteBoolean(quiet);
        }
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            side = reader.ReadSByte();
            quiet = reader.ReadBoolean();
		}
	}
}
