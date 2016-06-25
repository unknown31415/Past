using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseSearchMessage : NetworkMessage
	{
        public int type;
        public int genId;
        public override uint Id
        {
        	get { return 5806; }
        }
        public ExchangeBidHouseSearchMessage()
        {
        }
        public ExchangeBidHouseSearchMessage(int type, int genId)
        {
            this.type = type;
            this.genId = genId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(type);
            writer.WriteInt(genId);
        }
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadInt();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            genId = reader.ReadInt();
            if (genId < 0)
                throw new Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
		}
	}
}
