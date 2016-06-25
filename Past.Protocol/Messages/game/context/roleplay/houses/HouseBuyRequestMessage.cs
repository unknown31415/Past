using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseBuyRequestMessage : NetworkMessage
	{
        public int proposedPrice;
        public override uint Id
        {
        	get { return 5738; }
        }
        public HouseBuyRequestMessage()
        {
        }
        public HouseBuyRequestMessage(int proposedPrice)
        {
            this.proposedPrice = proposedPrice;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(proposedPrice);
        }
        public override void Deserialize(IDataReader reader)
        {
            proposedPrice = reader.ReadInt();
            if (proposedPrice < 0)
                throw new Exception("Forbidden value on proposedPrice = " + proposedPrice + ", it doesn't respect the following condition : proposedPrice < 0");
		}
	}
}
