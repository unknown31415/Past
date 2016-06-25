using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildFightJoinRequestMessage : NetworkMessage
	{
        public int taxCollectorId;
        public override uint Id
        {
        	get { return 5717; }
        }
        public GuildFightJoinRequestMessage()
        {
        }
        public GuildFightJoinRequestMessage(int taxCollectorId)
        {
            this.taxCollectorId = taxCollectorId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(taxCollectorId);
        }
        public override void Deserialize(IDataReader reader)
        {
            taxCollectorId = reader.ReadInt();
		}
	}
}
