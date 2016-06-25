using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseGuildNoneMessage : NetworkMessage
	{
        public short houseId;
        public override uint Id
        {
        	get { return 5701; }
        }
        public HouseGuildNoneMessage()
        {
        }
        public HouseGuildNoneMessage(short houseId)
        {
            this.houseId = houseId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(houseId);
        }
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadShort();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
		}
	}
}
