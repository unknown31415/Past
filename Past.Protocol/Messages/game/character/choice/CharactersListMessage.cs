using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharactersListMessage : NetworkMessage
	{
        public bool hasStartupActions;
        public bool tutorielAvailable;
        public CharacterBaseInformations[] characters;
        public override uint Id
        {
        	get { return 151; }
        }
        public CharactersListMessage()
        {
        }
        public CharactersListMessage(bool hasStartupActions, bool tutorielAvailable, CharacterBaseInformations[] characters)
        {
            this.hasStartupActions = hasStartupActions;
            this.tutorielAvailable = tutorielAvailable;
            this.characters = characters;
        }
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, hasStartupActions);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, tutorielAvailable);
            writer.WriteUShort((ushort)characters.Length);
            foreach (var entry in characters)
            {
                 writer.WriteByte(flag1);
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            hasStartupActions = BooleanByteWrapper.GetFlag(flag1, 0);
            tutorielAvailable = BooleanByteWrapper.GetFlag(flag1, 1);
            var limit = reader.ReadUShort();
            characters = new CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 characters[i] = (CharacterBaseInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 characters[i].Deserialize(reader);
            }
		}
	}
}
