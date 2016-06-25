using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChannelEnablingChangeMessage : NetworkMessage
	{
        public sbyte channel;
        public bool enable;
        public override uint Id
        {
        	get { return 891; }
        }
        public ChannelEnablingChangeMessage()
        {
        }
        public ChannelEnablingChangeMessage(sbyte channel, bool enable)
        {
            this.channel = channel;
            this.enable = enable;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(channel);
            writer.WriteBoolean(enable);
        }
        public override void Deserialize(IDataReader reader)
        {
            channel = reader.ReadSByte();
            if (channel < 0)
                throw new Exception("Forbidden value on channel = " + channel + ", it doesn't respect the following condition : channel < 0");
            enable = reader.ReadBoolean();
		}
	}
}
