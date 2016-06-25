using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterSelectionWithRenameMessage : CharacterSelectionMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 6121; }
        }
        public CharacterSelectionWithRenameMessage()
        {
        }
        public CharacterSelectionWithRenameMessage(int id, string name) : base(id)
        {
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
		}
	}
}
