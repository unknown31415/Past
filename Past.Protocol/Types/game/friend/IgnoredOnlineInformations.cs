using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public string playerName;
        public sbyte breed;
        public bool sex;
        public new const short Id = 105;
        public override short TypeId
        {
            get { return Id; }
        }
        public IgnoredOnlineInformations()
        {
        }
        public IgnoredOnlineInformations(string name, string playerName, sbyte breed, bool sex) : base(name)
        {
            this.playerName = playerName;
            this.breed = breed;
            this.sex = sex;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(playerName);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerName = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Pandawa)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Pandawa");
            sex = reader.ReadBoolean();
        }
    }
}
