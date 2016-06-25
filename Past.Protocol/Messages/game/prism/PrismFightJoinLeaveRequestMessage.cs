using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismFightJoinLeaveRequestMessage : NetworkMessage
	{
        public bool join;
        public override uint Id
        {
        	get { return 5843; }
        }
        public PrismFightJoinLeaveRequestMessage()
        {
        }
        public PrismFightJoinLeaveRequestMessage(bool join)
        {
            this.join = join;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(join);
        }
        public override void Deserialize(IDataReader reader)
        {
            join = reader.ReadBoolean();
		}
	}
}
