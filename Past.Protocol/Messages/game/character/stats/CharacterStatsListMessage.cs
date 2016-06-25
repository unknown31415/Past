using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterStatsListMessage : NetworkMessage
	{
        public CharacterCharacteristicsInformations stats;
        public override uint Id
        {
        	get { return 500; }
        }
        public CharacterStatsListMessage()
        {
        }
        public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            this.stats = stats;
        }
        public override void Serialize(IDataWriter writer)
        {
            stats.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            stats = new CharacterCharacteristicsInformations();
            stats.Deserialize(reader);
		}
	}
}
