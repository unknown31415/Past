using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountRenameRequestMessage : NetworkMessage
	{
        public string name;
        public double mountId;
        public override uint Id
        {
        	get { return 5987; }
        }
        public MountRenameRequestMessage()
        {
        }
        public MountRenameRequestMessage(string name, double mountId)
        {
            this.name = name;
            this.mountId = mountId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteDouble(mountId);
        }
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            mountId = reader.ReadDouble();
		}
	}
}
