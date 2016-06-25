using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
	{
        public int itemUID;
        public override uint Id
        {
        	get { return 5950; }
        }
        public ExchangeBidHouseInListRemovedMessage()
        {
        }
        public ExchangeBidHouseInListRemovedMessage(int itemUID)
        {
            this.itemUID = itemUID;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
        }
        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
		}
	}
}
