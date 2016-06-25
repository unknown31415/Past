using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
	{
        public int[] typeDescription;
        public override uint Id
        {
        	get { return 5765; }
        }
        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }
        public ExchangeTypesExchangerDescriptionForUserMessage(int[] typeDescription)
        {
            this.typeDescription = typeDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)typeDescription.Length);
            foreach (var entry in typeDescription)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            typeDescription = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 typeDescription[i] = reader.ReadInt();
            }
		}
	}
}
