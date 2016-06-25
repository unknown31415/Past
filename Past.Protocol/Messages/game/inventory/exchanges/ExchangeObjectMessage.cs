using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectMessage : NetworkMessage
	{
        public bool remote;
        public override uint Id
        {
        	get { return 5515; }
        }
        public ExchangeObjectMessage()
        {
        }
        public ExchangeObjectMessage(bool remote)
        {
            this.remote = remote;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(remote);
        }
        public override void Deserialize(IDataReader reader)
        {
            remote = reader.ReadBoolean();
		}
	}
}
