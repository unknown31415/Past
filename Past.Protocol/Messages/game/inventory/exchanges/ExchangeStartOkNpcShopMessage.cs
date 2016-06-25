using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeStartOkNpcShopMessage : NetworkMessage
	{
        public int npcSellerId;
        public ObjectItemMinimalInformation[] objectsInfos;
        public override uint Id
        {
        	get { return 5761; }
        }
        public ExchangeStartOkNpcShopMessage()
        {
        }
        public ExchangeStartOkNpcShopMessage(int npcSellerId, ObjectItemMinimalInformation[] objectsInfos)
        {
            this.npcSellerId = npcSellerId;
            this.objectsInfos = objectsInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(npcSellerId);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            npcSellerId = reader.ReadInt();
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItemMinimalInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new ObjectItemMinimalInformation();
                 objectsInfos[i].Deserialize(reader);
            }
		}
	}
}
