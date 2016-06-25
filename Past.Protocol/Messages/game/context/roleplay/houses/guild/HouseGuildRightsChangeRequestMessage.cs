using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseGuildRightsChangeRequestMessage : NetworkMessage
	{
        public uint rights;
        public override uint Id
        {
        	get { return 5702; }
        }
        public HouseGuildRightsChangeRequestMessage()
        {
        }
        public HouseGuildRightsChangeRequestMessage(uint rights)
        {
            this.rights = rights;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUInt(rights);
        }
        public override void Deserialize(IDataReader reader)
        {
            rights = reader.ReadUInt();
            if (rights < 0 || rights > 4294967295)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0 || rights > 4294967295");
		}
	}
}
