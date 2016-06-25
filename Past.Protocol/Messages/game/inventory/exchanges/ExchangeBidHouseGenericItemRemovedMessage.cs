using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
	{
        public int objGenericId;
        public override uint Id
        {
        	get { return 5948; }
        }
        public ExchangeBidHouseGenericItemRemovedMessage()
        {
        }
        public ExchangeBidHouseGenericItemRemovedMessage(int objGenericId)
        {
            this.objGenericId = objGenericId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objGenericId);
        }
        public override void Deserialize(IDataReader reader)
        {
            objGenericId = reader.ReadInt();
		}
	}
}
