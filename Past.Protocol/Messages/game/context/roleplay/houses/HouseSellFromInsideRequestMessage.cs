using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
	{
        public override uint Id
        {
        	get { return 5884; }
        }
        public HouseSellFromInsideRequestMessage()
        {
        }
        public HouseSellFromInsideRequestMessage(int amount) : base(amount)
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
