using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyInvitationMessage : NetworkMessage
	{
        public int fromId;
        public string fromName;
        public int toId;
        public string toName;
        public override uint Id
        {
        	get { return 5586; }
        }
        public PartyInvitationMessage()
        {
        }
        public PartyInvitationMessage(int fromId, string fromName, int toId, string toName)
        {
            this.fromId = fromId;
            this.fromName = fromName;
            this.toId = toId;
            this.toName = toName;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fromId);
            writer.WriteUTF(fromName);
            writer.WriteInt(toId);
            writer.WriteUTF(toName);
        }
        public override void Deserialize(IDataReader reader)
        {
            fromId = reader.ReadInt();
            if (fromId < 0)
                throw new Exception("Forbidden value on fromId = " + fromId + ", it doesn't respect the following condition : fromId < 0");
            fromName = reader.ReadUTF();
            toId = reader.ReadInt();
            if (toId < 0)
                throw new Exception("Forbidden value on toId = " + toId + ", it doesn't respect the following condition : toId < 0");
            toName = reader.ReadUTF();
		}
	}
}
