using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeObjectTransfertListToInvMessage : NetworkMessage
	{
        public int[] ids;
        public override uint Id
        {
        	get { return 6039; }
        }
        public ExchangeObjectTransfertListToInvMessage()
        {
        }
        public ExchangeObjectTransfertListToInvMessage(int[] ids)
        {
            this.ids = ids;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)ids.Length);
            foreach (var entry in ids)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            ids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids[i] = reader.ReadInt();
            }
		}
	}
}
