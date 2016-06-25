using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextRefreshEntityLookMessage : NetworkMessage
	{
        public int id;
        public EntityLook look;
        public override uint Id
        {
        	get { return 5637; }
        }
        public GameContextRefreshEntityLookMessage()
        {
        }
        public GameContextRefreshEntityLookMessage(int id, EntityLook look)
        {
            this.id = id;
            this.look = look;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            look.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            look = new EntityLook();
            look.Deserialize(reader);
		}
	}
}
