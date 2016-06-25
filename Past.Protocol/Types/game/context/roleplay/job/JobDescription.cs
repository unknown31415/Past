using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class JobDescription
    {
        public sbyte jobId;
        public SkillActionDescription[] skills;
        public const short Id = 101;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public JobDescription()
        {
        }
        public JobDescription(sbyte jobId, SkillActionDescription[] skills)
        {
            this.jobId = jobId;
            this.skills = skills;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteUShort((ushort)skills.Length);
            foreach (var entry in skills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            var limit = reader.ReadUShort();
            skills = new Types.SkillActionDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                skills[i] = (SkillActionDescription)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                skills[i].Deserialize(reader);
            }
        }
    }
}
