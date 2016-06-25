using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightResumeMessage : GameFightSpectateMessage
	{
        public GameFightSpellCooldown[] spellCooldowns;
        public sbyte summonCount;
        public override uint Id
        {
        	get { return 6067; }
        }
        public GameFightResumeMessage()
        {
        }
        public GameFightResumeMessage(FightDispellableEffectExtendedInformations[] effects, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount) : base(effects)
        {
            this.spellCooldowns = spellCooldowns;
            this.summonCount = summonCount;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)spellCooldowns.Length);
            foreach (var entry in spellCooldowns)
            {
                 entry.Serialize(writer);
            }
            writer.WriteSByte(summonCount);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            spellCooldowns = new GameFightSpellCooldown[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellCooldowns[i] = new GameFightSpellCooldown();
                 spellCooldowns[i].Deserialize(reader);
            }
            summonCount = reader.ReadSByte();
            if (summonCount < 0)
                throw new Exception("Forbidden value on summonCount = " + summonCount + ", it doesn't respect the following condition : summonCount < 0");
		}
	}
}
