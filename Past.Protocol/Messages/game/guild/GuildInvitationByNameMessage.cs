using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInvitationByNameMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 6115; }
        }
        public GuildInvitationByNameMessage()
        {
        }
        public GuildInvitationByNameMessage(string name)
        {
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
		}
	}
}
