using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseGenericItemAddedMessage : NetworkMessage
	{
        public int objGenericId;
        public override uint Id
        {
        	get { return 5947; }
        }
        public ExchangeBidHouseGenericItemAddedMessage()
        {
        }
        public ExchangeBidHouseGenericItemAddedMessage(int objGenericId)
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
