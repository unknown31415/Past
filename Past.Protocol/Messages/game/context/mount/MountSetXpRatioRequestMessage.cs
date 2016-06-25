using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountSetXpRatioRequestMessage : NetworkMessage
	{
        public sbyte xpRatio;
        public override uint Id
        {
        	get { return 5989; }
        }
        public MountSetXpRatioRequestMessage()
        {
        }
        public MountSetXpRatioRequestMessage(sbyte xpRatio)
        {
            this.xpRatio = xpRatio;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(xpRatio);
        }
        public override void Deserialize(IDataReader reader)
        {
            xpRatio = reader.ReadSByte();
            if (xpRatio < 0)
                throw new Exception("Forbidden value on xpRatio = " + xpRatio + ", it doesn't respect the following condition : xpRatio < 0");
		}
	}
}
