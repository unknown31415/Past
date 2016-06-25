using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildMemberOnlineStatusMessage : NetworkMessage
	{
        public int memberId;
        public bool online;
        public override uint Id
        {
        	get { return 6061; }
        }
        public GuildMemberOnlineStatusMessage()
        {
        }
        public GuildMemberOnlineStatusMessage(int memberId, bool online)
        {
            this.memberId = memberId;
            this.online = online;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(memberId);
            writer.WriteBoolean(online);
        }
        public override void Deserialize(IDataReader reader)
        {
            memberId = reader.ReadInt();
            if (memberId < 0)
                throw new Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0");
            online = reader.ReadBoolean();
		}
	}
}
