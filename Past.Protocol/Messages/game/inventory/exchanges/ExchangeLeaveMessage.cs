using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeLeaveMessage : LeaveDialogMessage
	{
        public bool success;
        public override uint Id
        {
        	get { return 5628; }
        }
        public ExchangeLeaveMessage()
        {
        }
        public ExchangeLeaveMessage(bool success)
        {
            this.success = success;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(success);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            success = reader.ReadBoolean();
		}
	}
}
