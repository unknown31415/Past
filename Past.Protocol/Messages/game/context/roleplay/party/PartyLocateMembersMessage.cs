using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PartyLocateMembersMessage : NetworkMessage
	{
        public int[] geopositions;
        public override uint Id
        {
        	get { return 5595; }
        }
        public PartyLocateMembersMessage()
        {
        }
        public PartyLocateMembersMessage(int[] geopositions)
        {
            this.geopositions = geopositions;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)geopositions.Length);
            foreach (var entry in geopositions)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            geopositions = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 geopositions[i] = reader.ReadInt();
            }
		}
	}
}
