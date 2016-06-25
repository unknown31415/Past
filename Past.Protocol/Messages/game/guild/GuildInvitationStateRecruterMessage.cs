using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInvitationStateRecruterMessage : NetworkMessage
	{
        public string recrutedName;
        public sbyte invitationState;
        public override uint Id
        {
        	get { return 5563; }
        }
        public GuildInvitationStateRecruterMessage()
        {
        }
        public GuildInvitationStateRecruterMessage(string recrutedName, sbyte invitationState)
        {
            this.recrutedName = recrutedName;
            this.invitationState = invitationState;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(recrutedName);
            writer.WriteSByte(invitationState);
        }
        public override void Deserialize(IDataReader reader)
        {
            recrutedName = reader.ReadUTF();
            invitationState = reader.ReadSByte();
            if (invitationState < 0)
                throw new Exception("Forbidden value on invitationState = " + invitationState + ", it doesn't respect the following condition : invitationState < 0");
		}
	}
}
