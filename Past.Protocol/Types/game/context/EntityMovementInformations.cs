using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class EntityMovementInformations
    {
        public int id;
        public sbyte[] steps;
        public const short Id = 63;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public EntityMovementInformations()
        {
        }
        public EntityMovementInformations(int id, sbyte[] steps)
        {
            this.id = id;
            this.steps = steps;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteUShort((ushort)steps.Length);
            foreach (var entry in steps)
            {
                writer.WriteSByte(entry);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            var limit = reader.ReadUShort();
            steps = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                steps[i] = reader.ReadSByte();
            }
        }
    }
}
