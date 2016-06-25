using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyUpdateMessage : NetworkMessage
	{
        public PartyMemberInformations memberInformations;
        public override uint Id
        {
        	get { return 5575; }
        }
        public PartyUpdateMessage()
        {
        }
        public PartyUpdateMessage(PartyMemberInformations memberInformations)
        {
            this.memberInformations = memberInformations;
        }
        public override void Serialize(IDataWriter writer)
        {
            memberInformations.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            memberInformations = new PartyMemberInformations();
            memberInformations.Deserialize(reader);
		}
	}
}
