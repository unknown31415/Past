using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SpellForgottenMessage : NetworkMessage
	{
        public short[] spellsId;
        public short boostPoint;
        public override uint Id
        {
        	get { return 5834; }
        }
        public SpellForgottenMessage()
        {
        }
        public SpellForgottenMessage(short[] spellsId, short boostPoint)
        {
            this.spellsId = spellsId;
            this.boostPoint = boostPoint;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)spellsId.Length);
            foreach (var entry in spellsId)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteShort(boostPoint);
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            spellsId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellsId[i] = reader.ReadShort();
            }
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
		}
	}
}
