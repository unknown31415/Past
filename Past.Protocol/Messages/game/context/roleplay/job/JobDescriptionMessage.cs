using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobDescriptionMessage : NetworkMessage
	{
        public JobDescription[] jobsDescription;
        public override uint Id
        {
        	get { return 5655; }
        }
        public JobDescriptionMessage()
        {
        }
        public JobDescriptionMessage(JobDescription[] jobsDescription)
        {
            this.jobsDescription = jobsDescription;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)jobsDescription.Length);
            foreach (var entry in jobsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            jobsDescription = new JobDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobsDescription[i] = new JobDescription();
                 jobsDescription[i].Deserialize(reader);
            }
		}
	}
}
