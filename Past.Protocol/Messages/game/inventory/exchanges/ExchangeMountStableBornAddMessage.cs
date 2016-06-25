using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeMountStableBornAddMessage : ExchangeMountStableAddMessage
	{
        public override uint Id
        {
        	get { return 5966; }
        }
        public ExchangeMountStableBornAddMessage()
        {
        }
        public ExchangeMountStableBornAddMessage(MountClientData mountDescription) : base(mountDescription)
        {
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
		}
	}
}
