using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
	{
        public int memberId;
        public override uint Id
        {
        	get { return 5589; }
        }
        public CompassUpdatePartyMemberMessage()
        {
        }
        public CompassUpdatePartyMemberMessage(sbyte type, short worldX, short worldY, int memberId) : base(type, worldX, worldY)
        {
            this.memberId = memberId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(memberId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            memberId = reader.ReadInt();
            if (memberId < 0)
                throw new Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0");
		}
	}
}
