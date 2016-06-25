using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobAllowMultiCraftRequestMessage : NetworkMessage
	{
        public bool enabled;
        public override uint Id
        {
        	get { return 5748; }
        }
        public JobAllowMultiCraftRequestMessage()
        {
        }
        public JobAllowMultiCraftRequestMessage(bool enabled)
        {
            this.enabled = enabled;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enabled);
        }
        public override void Deserialize(IDataReader reader)
        {
            enabled = reader.ReadBoolean();
		}
	}
}
