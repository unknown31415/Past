using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterSelectionWithRecolorMessage : CharacterSelectionMessage
	{
        public int[] indexedColor;
        public override uint Id
        {
        	get { return 6075; }
        }
        public CharacterSelectionWithRecolorMessage()
        {
        }
        public CharacterSelectionWithRecolorMessage(int id, int[] indexedColor) : base(id)
        {
            this.indexedColor = indexedColor;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)indexedColor.Length);
            foreach (var entry in indexedColor)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            indexedColor = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 indexedColor[i] = reader.ReadInt();
            }
		}
	}
}
