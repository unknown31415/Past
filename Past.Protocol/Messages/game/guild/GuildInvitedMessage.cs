using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInvitedMessage : NetworkMessage
	{
        public int recruterId;
        public string recruterName;
        public string guildName;
        public override uint Id
        {
        	get { return 5552; }
        }
        public GuildInvitedMessage()
        {
        }
        public GuildInvitedMessage(int recruterId, string recruterName, string guildName)
        {
            this.recruterId = recruterId;
            this.recruterName = recruterName;
            this.guildName = guildName;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(recruterId);
            writer.WriteUTF(recruterName);
            writer.WriteUTF(guildName);
        }
        public override void Deserialize(IDataReader reader)
        {
            recruterId = reader.ReadInt();
            if (recruterId < 0)
                throw new Exception("Forbidden value on recruterId = " + recruterId + ", it doesn't respect the following condition : recruterId < 0");
            recruterName = reader.ReadUTF();
            guildName = reader.ReadUTF();
		}
	}
}
