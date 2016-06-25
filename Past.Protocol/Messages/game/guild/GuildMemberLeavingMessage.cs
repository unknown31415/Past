using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildMemberLeavingMessage : NetworkMessage
	{
        public bool kicked;
        public int memberId;
        public override uint Id
        {
        	get { return 5923; }
        }
        public GuildMemberLeavingMessage()
        {
        }
        public GuildMemberLeavingMessage(bool kicked, int memberId)
        {
            this.kicked = kicked;
            this.memberId = memberId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(kicked);
            writer.WriteInt(memberId);
        }
        public override void Deserialize(IDataReader reader)
        {
            kicked = reader.ReadBoolean();
            memberId = reader.ReadInt();
		}
	}
}
