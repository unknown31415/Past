using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapRunningFightListMessage : NetworkMessage
	{
        public FightExternalInformations[] fights;
        public override uint Id
        {
        	get { return 5743; }
        }
        public MapRunningFightListMessage()
        {
        }
        public MapRunningFightListMessage(FightExternalInformations[] fights)
        {
            this.fights = fights;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)fights.Length);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            fights = new FightExternalInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights[i] = new FightExternalInformations();
                 fights[i].Deserialize(reader);
            }
		}
	}
}
