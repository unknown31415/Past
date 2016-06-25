using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyLeaderUpdateMessage : NetworkMessage
	{
        public int partyLeaderId;
        public override uint Id
        {
        	get { return 5578; }
        }
        public PartyLeaderUpdateMessage()
        {
        }
        public PartyLeaderUpdateMessage(int partyLeaderId)
        {
            this.partyLeaderId = partyLeaderId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(partyLeaderId);
        }
        public override void Deserialize(IDataReader reader)
        {
            partyLeaderId = reader.ReadInt();
            if (partyLeaderId < 0)
                throw new Exception("Forbidden value on partyLeaderId = " + partyLeaderId + ", it doesn't respect the following condition : partyLeaderId < 0");
		}
	}
}
