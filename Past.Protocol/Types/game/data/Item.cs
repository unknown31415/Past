using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class Item
    {
        public const short Id = 7;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public Item()
        {
        }
        public virtual void Serialize(IDataWriter writer)
        {
        }
        public virtual void Deserialize(IDataReader reader)
        {
        }
    }
}
			
