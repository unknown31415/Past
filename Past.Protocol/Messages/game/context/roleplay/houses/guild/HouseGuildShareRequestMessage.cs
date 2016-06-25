using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseGuildShareRequestMessage : NetworkMessage
	{
        public bool enable;
        public override uint Id
        {
        	get { return 5704; }
        }
        public HouseGuildShareRequestMessage()
        {
        }
        public HouseGuildShareRequestMessage(bool enable)
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
