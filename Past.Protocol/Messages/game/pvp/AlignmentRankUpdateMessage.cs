using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AlignmentRankUpdateMessage : NetworkMessage
	{
        public sbyte alignmentRank;
        public bool verbose;
        public override uint Id
        {
        	get { return 6058; }
        }
        public AlignmentRankUpdateMessage()
        {
        }
        public AlignmentRankUpdateMessage(sbyte alignmentRank, bool verbose)
        {
            this.alignmentRank = alignmentRank;
            this.verbose = verbose;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(alignmentRank);
            writer.WriteBoolean(verbose);
        }
        public override void Deserialize(IDataReader reader)
        {
            alignmentRank = reader.ReadSByte();
            if (alignmentRank < 0)
                throw new Exception("Forbidden value on alignmentRank = " + alignmentRank + ", it doesn't respect the following condition : alignmentRank < 0");
            verbose = reader.ReadBoolean();
		}
	}
}
