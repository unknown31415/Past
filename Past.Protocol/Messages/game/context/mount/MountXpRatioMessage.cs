using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountXpRatioMessage : NetworkMessage
	{
        public sbyte ratio;
        public override uint Id
        {
        	get { return 5970; }
        }
        public MountXpRatioMessage()
        {
        }
        public MountXpRatioMessage(sbyte ratio)
        {
            this.ratio = ratio;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ratio);
        }
        public override void Deserialize(IDataReader reader)
        {
            ratio = reader.ReadSByte();
            if (ratio < 0)
                throw new Exception("Forbidden value on ratio = " + ratio + ", it doesn't respect the following condition : ratio < 0");
		}
	}
}
