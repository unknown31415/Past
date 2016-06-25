using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendSetWarnOnConnectionMessage : NetworkMessage
	{
        public bool enable;
        public override uint Id
        {
        	get { return 5602; }
        }
        public FriendSetWarnOnConnectionMessage()
        {
        }
        public FriendSetWarnOnConnectionMessage(bool enable)
        {
            this.enable = enable;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enable);
        }
        public override void Deserialize(IDataReader reader)
        {
            enable = reader.ReadBoolean();
		}
	}
}
