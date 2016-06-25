using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeBidHouseInListAddedMessage : NetworkMessage
	{
        public int itemUID;
        public int objGenericId;
        public ObjectEffect[] effects;
        public int[] prices;
        public override uint Id
        {
        	get { return 5949; }
        }
        public ExchangeBidHouseInListAddedMessage()
        {
        }
        public ExchangeBidHouseInListAddedMessage(int itemUID, int objGenericId, ObjectEffect[] effects, int[] prices)
        {
            this.itemUID = itemUID;
            this.objGenericId = objGenericId;
            this.effects = effects;
            this.prices = prices;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
            writer.WriteInt(objGenericId);
            writer.WriteUShort((ushort)effects.Length);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)prices.Length);
            foreach (var entry in prices)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
            objGenericId = reader.ReadInt();
            var limit = reader.ReadUShort();
            effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects[i] = (ObjectEffect)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 effects[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            prices = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 prices[i] = reader.ReadInt();
            }
		}
	}
}
