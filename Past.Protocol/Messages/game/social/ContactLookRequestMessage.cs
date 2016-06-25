using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ContactLookRequestMessage : NetworkMessage
	{
        public byte requestId;
        public sbyte contactType;
        public override uint Id
        {
        	get { return 5932; }
        }
        public ContactLookRequestMessage()
        {
        }
        public ContactLookRequestMessage(byte requestId, sbyte contactType)
        {
            this.requestId = requestId;
            this.contactType = contactType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(requestId);
            writer.WriteSByte(contactType);
        }
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadByte();
            if (requestId < 0 || requestId > 255)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0 || requestId > 255");
            contactType = reader.ReadSByte();
            if (contactType < 0)
                throw new Exception("Forbidden value on contactType = " + contactType + ", it doesn't respect the following condition : contactType < 0");
		}
	}
}
