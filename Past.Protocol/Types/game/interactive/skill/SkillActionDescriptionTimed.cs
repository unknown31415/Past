using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public byte time;
        public new const short Id = 103;
        public override short TypeId
        {
            get { return Id; }
        }
        public SkillActionDescriptionTimed()
        {
        }
        public SkillActionDescriptionTimed(short skillId, byte time) : base(skillId)
        {
            this.time = time;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(time);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            time = reader.ReadByte();
            if (time < 0 || time > 255)
                throw new Exception("Forbidden value on time = " + time + ", it doesn't respect the following condition : time < 0 || time > 255");
        }
    }
}