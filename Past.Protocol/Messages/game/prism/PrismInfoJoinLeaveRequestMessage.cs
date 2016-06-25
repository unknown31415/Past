using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismInfoJoinLeaveRequestMessage : NetworkMessage
	{
        public bool join;
        public override uint Id
        {
        	get { return 5844; }
        }
        public PrismInfoJoinLeaveRequestMessage()
        {
        }
        public PrismInfoJoinLeaveRequestMessage(bool join)
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
