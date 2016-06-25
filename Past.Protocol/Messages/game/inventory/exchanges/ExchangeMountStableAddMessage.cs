using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountStableAddMessage : NetworkMessage
	{
        public MountClientData mountDescription;
        public override uint Id
        {
        	get { return 5971; }
        }
        public ExchangeMountStableAddMessage()
        {
        }
        public ExchangeMountStableAddMessage(MountClientData mountDescription)
        {
            this.mountDescription = mountDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            mountDescription.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            mountDescription = new MountClientData();
            mountDescription.Deserialize(reader);
		}
	}
}
