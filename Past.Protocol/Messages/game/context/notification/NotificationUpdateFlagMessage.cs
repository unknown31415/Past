using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NotificationUpdateFlagMessage : NetworkMessage
	{
        public short index;
        public override uint Id
        {
        	get { return 6090; }
        }
        public NotificationUpdateFlagMessage()
        {
        }
        public NotificationUpdateFlagMessage(short index)
        {
            this.index = index;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(index);
        }
        public override void Deserialize(IDataReader reader)
        {
            index = reader.ReadShort();
            if (index < 0)
                throw new Exception("Forbidden value on index = " + index + ", it doesn't respect the following condition : index < 0");
		}
	}
}
