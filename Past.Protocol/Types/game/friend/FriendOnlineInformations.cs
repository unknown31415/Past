using System;
using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FriendOnlineInformations : FriendInformations
    {
        public string playerName;
        public short level;
        public sbyte alignmentSide;
        public sbyte breed;
        public bool sex;
        public string guildName;
        public new const short Id = 92;
        public override short TypeId
        {
            get { return Id; }
        }
        public FriendOnlineInformations()
        {
        }
        public FriendOnlineInformations(string name, sbyte playerState, int lastConnection, string playerName, short level, sbyte alignmentSide, sbyte breed, bool sex, string guildName) : base(name, playerState, lastConnection)
        {
            this.playerName = playerName;
            this.level = level;
            this.alignmentSide = alignmentSide;
            this.breed = breed;
            this.sex = sex;
            this.guildName = guildName;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(playerName);
            writer.WriteShort(level);
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteUTF(guildName);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerName = reader.ReadUTF();
            level = reader.ReadShort();
            if (level < 0 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 200");
            alignmentSide = reader.ReadSByte();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Pandawa)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Pandawa");
            sex = reader.ReadBoolean();
            guildName = reader.ReadUTF();
        }
    }
}

