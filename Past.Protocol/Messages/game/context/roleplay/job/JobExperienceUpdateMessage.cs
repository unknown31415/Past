using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobExperienceUpdateMessage : NetworkMessage
	{
        public JobExperience experiencesUpdate;
        public override uint Id
        {
        	get { return 0x1616; }
        }
        public JobExperienceUpdateMessage()
        {
        }
        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            this.experiencesUpdate = experiencesUpdate;
        }
        public override void Serialize(IDataWriter writer)
        {
            experiencesUpdate.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            experiencesUpdate = new JobExperience();
            experiencesUpdate.Deserialize(reader);
		}
	}
}
