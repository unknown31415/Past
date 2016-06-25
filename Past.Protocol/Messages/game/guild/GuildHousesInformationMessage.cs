using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildHousesInformationMessage : NetworkMessage
	{
        public HouseInformationsForGuild[] HousesInformations;
        public override uint Id
        {
        	get { return 5919; }
        }
        public GuildHousesInformationMessage()
        {
        }
        public GuildHousesInformationMessage(HouseInformationsForGuild[] HousesInformations)
        {
            this.HousesInformations = HousesInformations;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)HousesInformations.Length);
            foreach (var entry in HousesInformations)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            HousesInformations = new HouseInformationsForGuild[limit];
            for (int i = 0; i < limit; i++)
            {
                 HousesInformations[i] = new HouseInformationsForGuild();
                 HousesInformations[i].Deserialize(reader);
            }
		}
	}
}
