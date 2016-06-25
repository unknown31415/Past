using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AccountLoggingKickedMessage : NetworkMessage
	{
        public int days;
        public int hours;
        public int minutes;
        public override uint Id
        {
        	get { return 6029; }
        }
        public AccountLoggingKickedMessage()
        {
        }
        public AccountLoggingKickedMessage(int days, int hours, int minutes)
        {
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(days);
            writer.WriteInt(hours);
            writer.WriteInt(minutes);
        }
        public override void Deserialize(IDataReader reader)
        {
            days = reader.ReadInt();
            if (days < 0)
                throw new Exception("Forbidden value on days = " + days + ", it doesn't respect the following condition : days < 0");
            hours = reader.ReadInt();
            if (hours < 0)
                throw new Exception("Forbidden value on hours = " + hours + ", it doesn't respect the following condition : hours < 0");
            minutes = reader.ReadInt();
            if (minutes < 0)
                throw new Exception("Forbidden value on minutes = " + minutes + ", it doesn't respect the following condition : minutes < 0");
		}
	}
}
