using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterReportMessage : NetworkMessage
	{
        public uint reportedId;
        public sbyte reason;
        public override uint Id
        {
        	get { return 6079; }
        }
        public CharacterReportMessage()
        {
        }
        public CharacterReportMessage(uint reportedId, sbyte reason)
        {
            this.reportedId = reportedId;
            this.reason = reason;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUInt(reportedId);
            writer.WriteSByte(reason);
        }
        public override void Deserialize(IDataReader reader)
        {
            reportedId = reader.ReadUInt();
            if (reportedId < 0 || reportedId > 4294967295)
                throw new Exception("Forbidden value on reportedId = " + reportedId + ", it doesn't respect the following condition : reportedId < 0 || reportedId > 4294967295");
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
		}
	}
}
