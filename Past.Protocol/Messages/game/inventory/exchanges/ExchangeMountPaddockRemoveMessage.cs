using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountPaddockRemoveMessage : NetworkMessage
	{
        public double mountId;
        public override uint Id
        {
        	get { return 6050; }
        }
        public ExchangeMountPaddockRemoveMessage()
        {
        }
        public ExchangeMountPaddockRemoveMessage(double mountId)
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
