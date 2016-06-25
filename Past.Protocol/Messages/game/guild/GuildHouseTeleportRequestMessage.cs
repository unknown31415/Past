using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildHouseTeleportRequestMessage : NetworkMessage
	{
        public int houseId;
        public override uint Id
        {
        	get { return 5712; }
        }
        public GuildHouseTeleportRequestMessage()
        {
        }
        public GuildHouseTeleportRequestMessage(int houseId)
        {
            this.houseId = houseId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(houseId);
        }
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
		}
	}
}
