using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ContactLookErrorMessage : NetworkMessage
	{
        public int requestId;
        public override uint Id
        {
        	get { return 6045; }
        }
        public ContactLookErrorMessage()
        {
        }
        public ContactLookErrorMessage(int requestId)
        {
            this.requestId = requestId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requestId);
        }
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadInt();
            if (requestId < 0)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
		}
	}
}
