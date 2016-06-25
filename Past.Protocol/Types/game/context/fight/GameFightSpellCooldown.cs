using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameFightSpellCooldown
    {
        public int spellId;
        public sbyte cooldown;
        public const short Id = 205;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public GameFightSpellCooldown()
        {
        }
        public GameFightSpellCooldown(int spellId, sbyte cooldown)
        {
            this.spellId = spellId;
            this.cooldown = cooldown;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteSByte(cooldown);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadInt();
            cooldown = reader.ReadSByte();
            if (cooldown < 0)
                throw new Exception("Forbidden value on cooldown = " + cooldown + ", it doesn't respect the following condition : cooldown < 0");
        }
    }
}

