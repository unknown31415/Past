using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
	{
        public bool enabled;
        public override uint Id
        {
        	get { return 5588; }
        }
        public PartyFollowThisMemberRequestMessage()
        {
        }
        public PartyFollowThisMemberRequestMessage(int playerId, bool enabled) : base(playerId)
        {
            this.enabled = enabled;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(enabled);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            enabled = reader.ReadBoolean();
		}
	}
}
