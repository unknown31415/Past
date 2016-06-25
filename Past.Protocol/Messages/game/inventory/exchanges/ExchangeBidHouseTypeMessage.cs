using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseTypeMessage : NetworkMessage
	{
        public int type;
        public override uint Id
        {
        	get { return 5803; }
        }
        public ExchangeBidHouseTypeMessage()
        {
        }
        public ExchangeBidHouseTypeMessage(int type)
        {
            this.type = type;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(type);
        }
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadInt();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
		}
	}
}
