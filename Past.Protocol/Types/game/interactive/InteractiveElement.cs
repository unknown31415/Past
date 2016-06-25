using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class InteractiveElement
    {
        public int elementId;
        public short[] enabledSkillIds;
        public short[] disabledSkillIds;
        public const short Id = 80;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public InteractiveElement()
        {
        }
        public InteractiveElement(int elementId, short[] enabledSkillIds, short[] disabledSkillIds)
        {
            this.elementId = elementId;
            this.enabledSkillIds = enabledSkillIds;
            this.disabledSkillIds = disabledSkillIds;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteUShort((ushort)enabledSkillIds.Length);
            foreach (var entry in enabledSkillIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)disabledSkillIds.Length);
            foreach (var entry in disabledSkillIds)
            {
                writer.WriteShort(entry);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            var limit = reader.ReadUShort();
            enabledSkillIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                enabledSkillIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            disabledSkillIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                disabledSkillIds[i] = reader.ReadShort();
            }
        }
    }
}
