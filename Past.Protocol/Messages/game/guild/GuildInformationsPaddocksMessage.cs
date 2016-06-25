using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildInformationsPaddocksMessage : NetworkMessage
	{
        public sbyte nbPaddockMax;
        public PaddockContentInformations[] paddocksInformations;
        public override uint Id
        {
        	get { return 5959; }
        }
        public GuildInformationsPaddocksMessage()
        {
        }
        public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, PaddockContentInformations[] paddocksInformations)
        {
            this.nbPaddockMax = nbPaddockMax;
            this.paddocksInformations = paddocksInformations;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(nbPaddockMax);
            writer.WriteUShort((ushort)paddocksInformations.Length);
            foreach (var entry in paddocksInformations)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            nbPaddockMax = reader.ReadSByte();
            if (nbPaddockMax < 0)
                throw new Exception("Forbidden value on nbPaddockMax = " + nbPaddockMax + ", it doesn't respect the following condition : nbPaddockMax < 0");
            var limit = reader.ReadUShort();
            paddocksInformations = new PaddockContentInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddocksInformations[i] = new PaddockContentInformations();
                 paddocksInformations[i].Deserialize(reader);
            }
		}
	}
}
