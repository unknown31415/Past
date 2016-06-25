using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterCreationRequestMessage : NetworkMessage
	{
        public string name;
        public sbyte breed;
        public bool sex;
        public int[] colors;
        public override uint Id
        {
        	get { return 160; }
        }
        public CharacterCreationRequestMessage()
        {
        }
        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, int[] colors)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            foreach (var entry in colors)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.BreedEnum.Feca || breed > (byte)Enums.BreedEnum.Pandawa)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.BreedEnum.Feca || breed > (byte)Enums.BreedEnum.Pandawa");
            sex = reader.ReadBoolean();
            colors = new int[6];
            for (int i = 0; i < 6; i++)
            {
                 colors[i] = reader.ReadInt();
            }
		}
	}
}
