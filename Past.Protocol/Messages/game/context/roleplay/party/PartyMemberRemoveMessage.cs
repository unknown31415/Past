using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyMemberRemoveMessage : NetworkMessage
	{
        public int leavingPlayerId;
        public override uint Id
        {
        	get { return 5579; }
        }
        public PartyMemberRemoveMessage()
        {
        }
        public PartyMemberRemoveMessage(int leavingPlayerId)
        {
            this.leavingPlayerId = leavingPlayerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(leavingPlayerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            leavingPlayerId = reader.ReadInt();
            if (leavingPlayerId < 0)
                throw new Exception("Forbidden value on leavingPlayerId = " + leavingPlayerId + ", it doesn't respect the following condition : leavingPlayerId < 0");
		}
	}
}
