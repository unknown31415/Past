using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobLevelUpMessage : NetworkMessage
	{
        public sbyte newLevel;
        public JobDescription jobsDescription;
        public override uint Id
        {
        	get { return 5656; }
        }
        public JobLevelUpMessage()
        {
        }
        public JobLevelUpMessage(sbyte newLevel, JobDescription jobsDescription)
        {
            this.newLevel = newLevel;
            this.jobsDescription = jobsDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(newLevel);
            jobsDescription.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            newLevel = reader.ReadSByte();
            if (newLevel < 0)
                throw new Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 0");
            jobsDescription = new JobDescription();
            jobsDescription.Deserialize(reader);
		}
	}
}
