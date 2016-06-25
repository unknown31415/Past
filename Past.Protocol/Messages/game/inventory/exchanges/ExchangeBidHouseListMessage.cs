using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseListMessage : NetworkMessage
	{
        public int id;
        public override uint Id
        {
        	get { return 5807; }
        }
        public ExchangeBidHouseListMessage()
        {
        }
        public ExchangeBidHouseListMessage(int id)
        {
            this.id = id;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
		}
	}
}
