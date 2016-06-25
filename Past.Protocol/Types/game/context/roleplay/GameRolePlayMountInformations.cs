using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public string ownerName;
        public byte level;
        public new const short Id = 180;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameRolePlayMountInformations()
        {
        }
        public GameRolePlayMountInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, string ownerName, byte level) : base(contextualId, look, disposition, name)
        {
            this.ownerName = ownerName;
            this.level = level;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ownerName);
            writer.WriteByte(level);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ownerName = reader.ReadUTF();
            level = reader.ReadByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
    }
}

