using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInvitationStateRecrutedMessage : NetworkMessage
	{
        public sbyte invitationState;
        public override uint Id
        {
        	get { return 5548; }
        }
        public GuildInvitationStateRecrutedMessage()
        {
        }
        public GuildInvitationStateRecrutedMessage(sbyte invitationState)
        {
            this.invitationState = invitationState;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(invitationState);
        }
        public override void Deserialize(IDataReader reader)
        {
            invitationState = reader.ReadSByte();
            if (invitationState < 0)
                throw new Exception("Forbidden value on invitationState = " + invitationState + ", it doesn't respect the following condition : invitationState < 0");
		}
	}
}
