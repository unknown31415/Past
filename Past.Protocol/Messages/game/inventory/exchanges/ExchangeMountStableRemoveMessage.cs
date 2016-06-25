using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountStableRemoveMessage : NetworkMessage
	{
        public double mountId;
        public override uint Id
        {
        	get { return 5964; }
        }
        public ExchangeMountStableRemoveMessage()
        {
        }
        public ExchangeMountStableRemoveMessage(double mountId)
        {
            this.mountId = mountId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(mountId);
        }
        public override void Deserialize(IDataReader reader)
        {
            mountId = reader.ReadDouble();
		}
	}
}
