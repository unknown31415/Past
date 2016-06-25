using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class BidExchangerObjectInfo
    {
        public int objectUID;
        public ObjectEffect[] effects;
        public int[] prices;
        public const short Id = 122;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public BidExchangerObjectInfo()
        {
        }
        public BidExchangerObjectInfo(int objectUID, ObjectEffect[] effects, int[] prices)
        {
            this.objectUID = objectUID;
            this.effects = effects;
            this.prices = prices;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(objectUID);
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
        public virtual void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
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
  