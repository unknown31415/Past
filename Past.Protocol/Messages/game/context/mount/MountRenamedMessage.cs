using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountRenamedMessage : NetworkMessage
	{
        public double mountId;
        public string name;
        public override uint Id
        {
        	get { return 5983; }
        }
        public MountRenamedMessage()
        {
        }
        public MountRenamedMessage(double mountId, string name)
        {
            this.mountId = mountId;
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(mountId);
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            mountId = reader.ReadDouble();
            name = reader.ReadUTF();
		}
	}
}
