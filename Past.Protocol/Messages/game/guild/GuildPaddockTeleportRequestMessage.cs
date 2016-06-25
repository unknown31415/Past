using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildPaddockTeleportRequestMessage : NetworkMessage
	{
        public int paddockId;
        public override uint Id
        {
        	get { return 5957; }
        }
        public GuildPaddockTeleportRequestMessage()
        {
        }
        public GuildPaddockTeleportRequestMessage(int paddockId)
        {
            this.paddockId = paddockId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(paddockId);
        }
        public override void Deserialize(IDataReader reader)
        {
            paddockId = reader.ReadInt();
            if (paddockId < 0)
                throw new Exception("Forbidden value on paddockId = " + paddockId + ", it doesn't respect the following condition : paddockId < 0");
		}
	}
}
