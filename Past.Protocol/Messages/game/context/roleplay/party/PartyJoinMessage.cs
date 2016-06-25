using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyJoinMessage : NetworkMessage
	{
        public int partyLeaderId;
        public PartyMemberInformations[] members;
        public override uint Id
        {
        	get { return 5576; }
        }
        public PartyJoinMessage()
        {
        }
        public PartyJoinMessage(int partyLeaderId, PartyMemberInformations[] members)
        {
            this.partyLeaderId = partyLeaderId;
            this.members = members;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(partyLeaderId);
            writer.WriteUShort((ushort)members.Length);
            foreach (var entry in members)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            partyLeaderId = reader.ReadInt();
            if (partyLeaderId < 0)
                throw new Exception("Forbidden value on partyLeaderId = " + partyLeaderId + ", it doesn't respect the following condition : partyLeaderId < 0");
            var limit = reader.ReadUShort();
            members = new PartyMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 members[i] = new PartyMemberInformations();
                 members[i].Deserialize(reader);
            }
		}
	}
}
