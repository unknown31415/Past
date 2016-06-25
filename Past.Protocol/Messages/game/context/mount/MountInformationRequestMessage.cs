using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountInformationRequestMessage : NetworkMessage
	{
        public double id;
        public double time;
        public override uint Id
        {
        	get { return 5972; }
        }
        public MountInformationRequestMessage()
        {
        }
        public MountInformationRequestMessage(double id, double time)
        {
            this.id = id;
            this.time = time;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(id);
            writer.WriteDouble(time);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadDouble();
            time = reader.ReadDouble();
		}
	}
}
