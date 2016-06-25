using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
	{
        public override uint Id
        {
        	get { return 5885; }
        }
        public HouseLockFromInsideRequestMessage()
        {
        }
        public HouseLockFromInsideRequestMessage(string code) : base(code)
        {
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
		}
	}
}
