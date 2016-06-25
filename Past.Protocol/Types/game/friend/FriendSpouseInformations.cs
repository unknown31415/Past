using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FriendSpouseInformations
    {
        public int spouseId;
        public string spouseName;
        public byte spouseLevel;
        public sbyte breed;
        public sbyte sex;
        public EntityLook spouseEntityLook;
        public const short Id = 77;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public FriendSpouseInformations()
        {
        }
        public FriendSpouseInformations(int spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook)
        {
            this.spouseId = spouseId;
            this.spouseName = spouseName;
            this.spouseLevel = spouseLevel;
            this.breed = breed;
            this.sex = sex;
            this.spouseEntityLook = spouseEntityLook;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spouseId);
            writer.WriteUTF(spouseName);
            writer.WriteByte(spouseLevel);
            writer.WriteSByte(breed);
            writer.WriteSByte(sex);
            spouseEntityLook.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            spouseId = reader.ReadInt();
            if (spouseId < 0)
                throw new Exception("Forbidden value on spouseId = " + spouseId + ", it doesn't respect the following condition : spouseId < 0");
            spouseName = reader.ReadUTF();
            spouseLevel = reader.ReadByte();
            if (spouseLevel < 1 || spouseLevel > 200)
                throw new Exception("Forbidden value on spouseLevel = " + spouseLevel + ", it doesn't respect the following condition : spouseLevel < 1 || spouseLevel > 200");
            breed = reader.ReadSByte();
            sex = reader.ReadSByte();
            spouseEntityLook = new EntityLook();
            spouseEntityLook.Deserialize(reader);
        }
    }
}