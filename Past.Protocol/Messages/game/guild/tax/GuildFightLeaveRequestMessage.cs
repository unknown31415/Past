using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildFightLeaveRequestMessage : NetworkMessage
	{
        public int taxCollectorId;
        public int characterId;
        public override uint Id
        {
        	get { return 5715; }
        }
        public GuildFightLeaveRequestMessage()
        {
        }
        public GuildFightLeaveRequestMessage(int taxCollectorId, int characterId)
        {
            this.taxCollectorId = taxCollectorId;
            this.characterId = characterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(taxCollectorId);
            writer.WriteInt(characterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            taxCollectorId = reader.ReadInt();
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
		}
	}
}
