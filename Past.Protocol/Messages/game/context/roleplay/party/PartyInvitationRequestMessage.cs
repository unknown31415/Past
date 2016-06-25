using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyInvitationRequestMessage : NetworkMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 5585; }
        }
        public PartyInvitationRequestMessage()
        {
        }
        public PartyInvitationRequestMessage(string name)
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
