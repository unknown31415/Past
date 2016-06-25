using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyKickedByMessage : NetworkMessage
	{
        public int kickerId;
        public override uint Id
        {
        	get { return 5590; }
        }
        public PartyKickedByMessage()
        {
        }
        public PartyKickedByMessage(int kickerId)
        {
            this.kickerId = kickerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(kickerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            kickerId = reader.ReadInt();
            if (kickerId < 0)
                throw new Exception("Forbidden value on kickerId = " + kickerId + ", it doesn't respect the following condition : kickerId < 0");
		}
	}
}
