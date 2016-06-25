using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightResultAdditionalData
	{ 
		public const short Id = 191;
		public virtual short TypeId
		{
			get { return Id; }
		}
		public FightResultAdditionalData()
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