using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharactersListWithModificationsMessage : CharactersListMessage
	{
        public CharacterToRecolorInformation[] charactersToRecolor;
        public int[] charactersToRename;
        public override uint Id
        {
        	get { return 6120; }
        }
        public CharactersListWithModificationsMessage()
        {
        }
        public CharactersListWithModificationsMessage(bool hasStartupActions, bool tutorielAvailable, CharacterBaseInformations[] characters, CharacterToRecolorInformation[] charactersToRecolor, int[] charactersToRename) : base(hasStartupActions, tutorielAvailable, characters)
        {
            this.charactersToRecolor = charactersToRecolor;
            this.charactersToRename = charactersToRename;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)charactersToRecolor.Length);
            foreach (var entry in charactersToRecolor)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)charactersToRename.Length);
            foreach (var entry in charactersToRename)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            charactersToRecolor = new CharacterToRecolorInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                 charactersToRecolor[i] = (CharacterToRecolorInformation)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 charactersToRecolor[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            charactersToRename = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 charactersToRename[i] = reader.ReadInt();
            }
		}
	}
}
