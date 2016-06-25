using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NotificationListMessage : NetworkMessage
	{
        public int[] flags;
        public override uint Id
        {
        	get { return 6087; }
        }
        public NotificationListMessage()
        {
        }
        public NotificationListMessage(int[] flags)
        {
            this.flags = flags;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)flags.Length);
            foreach (var entry in flags)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            flags = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 flags[i] = reader.ReadInt();
            }
		}
	}
}
