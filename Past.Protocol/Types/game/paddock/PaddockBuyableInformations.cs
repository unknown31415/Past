using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class PaddockBuyableInformations : PaddockInformations
    {
        public int price;
        public new const short Id = 130;
        public override short TypeId
        {
            get { return Id; }
        }
        public PaddockBuyableInformations()
        {
        }
        public PaddockBuyableInformations(short maxOutdoorMount, short maxItems, int price) : base(maxOutdoorMount, maxItems)
        {
            this.price = price;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(price);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
        }
    }
}