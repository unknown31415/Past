using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ContactLookRequestByIdMessage : ContactLookRequestMessage
	{
        public int playerId;
        public override uint Id
        {
        	get { return 5935; }
        }
        public ContactLookRequestByIdMessage()
        {
        }
        public ContactLookRequestByIdMessage(byte requestId, sbyte contactType, int playerId) : base(requestId, contactType)
        {
            this.playerId = playerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(playerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
		}
	}
}
