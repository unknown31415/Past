using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobExperienceMultiUpdateMessage : NetworkMessage
	{
        public JobExperience[] experiencesUpdate;
        public override uint Id
        {
        	get { return 5809; }
        }
        public JobExperienceMultiUpdateMessage()
        {
        }
        public JobExperienceMultiUpdateMessage(JobExperience[] experiencesUpdate)
        {
            this.experiencesUpdate = experiencesUpdate;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)experiencesUpdate.Length);
            foreach (var entry in experiencesUpdate)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            experiencesUpdate = new JobExperience[limit];
            for (int i = 0; i < limit; i++)
            {
                 experiencesUpdate[i] = new JobExperience();
                 experiencesUpdate[i].Deserialize(reader);
            }
		}
	}
}
