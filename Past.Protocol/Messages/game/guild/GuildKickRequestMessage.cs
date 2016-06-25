using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildKickRequestMessage : NetworkMessage
	{
        public int kickedId;
        public override uint Id
        {
        	get { return 5887; }
        }
        public GuildKickRequestMessage()
        {
        }
        public GuildKickRequestMessage(int kickedId)
        {
            this.kickedId = kickedId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(kickedId);
        }
        public override void Deserialize(IDataReader reader)
        {
            kickedId = reader.ReadInt();
            if (kickedId < 0)
                throw new Exception("Forbidden value on kickedId = " + kickedId + ", it doesn't respect the following condition : kickedId < 0");
		}
	}
}
