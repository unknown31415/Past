using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SetEnablePVPRequestMessage : NetworkMessage
	{
        public bool enable;
        public override uint Id
        {
        	get { return 1810; }
        }
        public SetEnablePVPRequestMessage()
        {
        }
        public SetEnablePVPRequestMessage(bool enable)
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
