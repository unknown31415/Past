using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
	{
        public int[] objectIdList;
        public override uint Id
        {
        	get { return 6037; }
        }
        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }
        public ExchangeShopStockMultiMovementRemovedMessage(int[] objectIdList)
        {
            this.objectIdList = objectIdList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)objectIdList.Length);
            foreach (var entry in objectIdList)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            objectIdList = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectIdList[i] = reader.ReadInt();
            }
		}
	}
}
