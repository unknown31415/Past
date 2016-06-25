using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class SkillActionDescription
    {
        public short skillId;
        public const short Id = 102;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public SkillActionDescription()
        {
        }
        public SkillActionDescription(short skillId)
        {
            this.skillId = skillId;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(skillId);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
        }
    }
}