using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyFollowMemberRequestMessage : NetworkMessage
	{
        public int playerId;
        public override uint Id
        {
        	get { return 5577; }
        }
        public PartyFollowMemberRequestMessage()
        {
        }
        public PartyFollowMemberRequestMessage(int playerId)
        {
            this.playerId = playerId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(playerId);
        }
        public override void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
		}
	}
}
