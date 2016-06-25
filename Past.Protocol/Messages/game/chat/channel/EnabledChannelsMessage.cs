using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EnabledChannelsMessage : NetworkMessage
	{
        public sbyte[] channels;
        public sbyte[] disallowed;
        public override uint Id
        {
        	get { return 892; }
        }
        public EnabledChannelsMessage()
        {
        }
        public EnabledChannelsMessage(sbyte[] channels, sbyte[] disallowed)
        {
            this.channels = channels;
            this.disallowed = disallowed;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)channels.Length);
            foreach (var entry in channels)
            {
                 writer.WriteSByte(entry);
            }
            writer.WriteUShort((ushort)disallowed.Length);
            foreach (var entry in disallowed)
            {
                 writer.WriteSByte(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            channels = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 channels[i] = reader.ReadSByte();
            }
            limit = reader.ReadUShort();
            disallowed = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 disallowed[i] = reader.ReadSByte();
            }
		}
	}
}
