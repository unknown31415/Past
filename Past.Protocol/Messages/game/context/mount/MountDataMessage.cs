using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountDataMessage : NetworkMessage
	{
        public MountClientData mountData;
        public override uint Id
        {
        	get { return 5973; }
        }
        public MountDataMessage()
        {
        }
        public MountDataMessage(MountClientData mountData)
        {
            this.mountData = mountData;
        }
        public override void Serialize(IDataWriter writer)
        {
            mountData.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            mountData = new MountClientData();
            mountData.Deserialize(reader);
		}
	}
}
