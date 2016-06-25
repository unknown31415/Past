using Past.Protocol.Types;
using System;

namespace Past.Protocol
{
    public class ProtocolTypeManager
    {
        public static object GetInstance(uint typeId)
        {
            object obj = null;
            switch (typeId)
            {
                case 11:
                    obj = new Types.Version();
                    break;
                case 25:
                    obj = new GameServerInformations();
                    break;
                case 55:
                    obj = new EntityLook();
                    break;
                case 54:
                    obj = new SubEntity();
                    break;
                case 110:
                    obj = new CharacterMinimalInformations();
                    break;
                case 163:
                    obj = new CharacterMinimalPlusLookInformations();
                    break;
                case 193:
                    obj = new CharacterMinimalPlusLookAndGradeInformations();
                    break;
                case 45:
                    obj = new CharacterBaseInformations();
                    break;
                case 212:
                    obj = new CharacterToRecolorInformation();
                    break;
                case 86:
                    obj = new CharacterHardcoreInformations();
                    break;
                case 63:
                    obj = new EntityMovementInformations();
                    break;
                case 60:
                    obj = new EntityDispositionInformations();
                    break;
                case 107:
                    obj = new IdentifiedEntityDispositionInformations();
                    break;
                case 217:
                    obj = new FightEntityDispositionInformations();
                    break;
                case 127:
                    obj = new GuildInformations();
                    break;
                case 204:
                    obj = new ActorRestrictionsInformations();
                    break;
                case 201:
                    obj = new ActorAlignmentInformations();
                    break;
                case 183:
                    obj = new PaddockContentInformations();
                    break;
                case 184:
                    obj = new MountInformationsForPaddock();
                    break;
                case 202:
                    obj = new ActorExtendedAlignmentInformations();
                    break;
                case 135:
                    obj = new AlignmentBonusInformations();
                    break;
                case 142:
                    obj = new PrismSubAreaInformation();
                    break;
                case 152:
                    obj = new PrismConquestInformation();
                    break;
                case 187:
                    obj = new TaxCollectorName();
                    break;
                case 96:
                    obj = new TaxCollectorBasicInformations();
                    break;
                case 4:
                    obj = new CharacterBaseCharacteristic();
                    break;
                case 215:
                    obj = new CharacterSpellModification();
                    break;
                case 8:
                    obj = new CharacterCharacteristicsInformations();
                    break;
                case 117:
                    obj = new FightExternalInformations();
                    break;
                case 43:
                    obj = new FightCommonInformations();
                    break;
                case 44:
                    obj = new FightTeamMemberInformations();
                    break;
                case 13:
                    obj = new FightTeamMemberCharacterInformations();
                    break;
                case 6:
                    obj = new FightTeamMemberMonsterInformations();
                    break;
                case 177:
                    obj = new FightTeamMemberTaxCollectorInformations();
                    break;
                case 20:
                    obj = new FightOptionsInformations();
                    break;
                case 116:
                    obj = new AbstractFightTeamInformations();
                    break;
                case 33:
                    obj = new FightTeamInformations();
                    break;
                case 115:
                    obj = new FightTeamLightInformations();
                    break;
                case 31:
                    obj = new GameFightMinimalStats();
                    break;
                case 41:
                    obj = new FightLoot();
                    break;
                case 16:
                    obj = new FightResultListEntry();
                    break;
                case 189:
                    obj = new FightResultFighterListEntry();
                    break;
                case 191:
                    obj = new FightResultAdditionalData();
                    break;
                case 192:
                    obj = new FightResultExperienceData();
                    break;
                case 190:
                    obj = new FightResultPvpData();
                    break;
                case 24:
                    obj = new FightResultPlayerListEntry();
                    break;
                case 216:
                    obj = new FightResultMutantListEntry();
                    break;
                case 84:
                    obj = new FightResultTaxCollectorListEntry();
                    break;
                case 206:
                    obj = new AbstractFightDispellableEffect();
                    break;
                case 208:
                    obj = new FightDispellableEffectExtendedInformations();
                    break;
                case 209:
                    obj = new FightTemporaryBoostEffect();
                    break;
                case 210:
                    obj = new FightTriggeredEffect();
                    break;
                case 207:
                    obj = new FightTemporarySpellBoostEffect();
                    break;
                case 211:
                    obj = new FightTemporaryBoostWeaponDamagesEffect();
                    break;
                case 214:
                    obj = new FightTemporaryBoostStateEffect();
                    break;
                case 205:
                    obj = new GameFightSpellCooldown();
                    break;
                case 7:
                    obj = new Item();
                    break;
                case 49:
                    obj = new SpellItem();
                    break;
                case 76:
                    obj = new ObjectEffect();
                    break;
                case 74:
                    obj = new ObjectEffectString();
                    break;
                case 70:
                    obj = new ObjectEffectInteger();
                    break;
                case 82:
                    obj = new ObjectEffectMinMax();
                    break;
                case 73:
                    obj = new ObjectEffectDice();
                    break;
                case 72:
                    obj = new ObjectEffectDate();
                    break;
                case 75:
                    obj = new ObjectEffectDuration();
                    break;
                case 71:
                    obj = new ObjectEffectCreature();
                    break;
                case 81:
                    obj = new ObjectEffectLadder();
                    break;
                case 179:
                    obj = new ObjectEffectMount();
                    break;
                case 178:
                    obj = new MountClientData();
                    break;
                case 168:
                    obj = new ItemDurability();
                    break;
                case 85:
                    obj = new GameActionMarkedCell();
                    break;
                case 123:
                    obj = new GoldItem();
                    break;
                case 124:
                    obj = new ObjectItemMinimalInformation();
                    break;
                case 119:
                    obj = new ObjectItemQuantity();
                    break;
                case 134:
                    obj = new ObjectItemNotInContainer();
                    break;
                case 37:
                    obj = new ObjectItem();
                    break;
                case 120:
                    obj = new ObjectItemToSell();
                    break;
                case 164:
                    obj = new ObjectItemToSellInBid();
                    break;
                case 198:
                    obj = new ObjectItemInRolePlay();
                    break;
                case 197:
                    obj = new ObjectItemWithLookInRolePlay();
                    break;
                case 199:
                    obj = new OrientedObjectItemWithLookInRolePlay();
                    break;
                case 185:
                    obj = new PaddockItem();
                    break;
                case 121:
                    obj = new SellerBuyerDescriptor();
                    break;
                case 122:
                    obj = new BidExchangerObjectInfo();
                    break;
                case 52:
                    obj = new StartupActionAddObject();
                    break;
                case 106:
                    obj = new IgnoredInformations();
                    break;
                case 105:
                    obj = new IgnoredOnlineInformations();
                    break;
                case 78:
                    obj = new FriendInformations();
                    break;
                case 92:
                    obj = new FriendOnlineInformations();
                    break;
                case 77:
                    obj = new FriendSpouseInformations();
                    break;
                case 93:
                    obj = new FriendSpouseOnlineInformations();
                    break;
                case 88:
                    obj = new GuildMember();
                    break;
                case 87:
                    obj = new GuildEmblem();
                    break;
                case 80:
                    obj = new InteractiveElement();
                    break;
                case 108:
                    obj = new StatedElement();
                    break;
                case 200:
                    obj = new MapObstacle();
                    break;
                case 213:
                    obj = new PartyUpdateCommonsInformations();
                    break;
                case 90:
                    obj = new PartyMemberInformations();
                    break;
                case 97:
                    obj = new JobCrafterDirectorySettings();
                    break;
                case 194:
                    obj = new JobCrafterDirectoryEntryPlayerInfo();
                    break;
                case 195:
                    obj = new JobCrafterDirectoryEntryJobInfo();
                    break;
                case 196:
                    obj = new JobCrafterDirectoryListEntry();
                    break;
                case 101:
                    obj = new JobDescription();
                    break;
                case 102:
                    obj = new SkillActionDescription();
                    break;
                case 103:
                    obj = new SkillActionDescriptionTimed();
                    break;
                case 99:
                    obj = new SkillActionDescriptionCollect();
                    break;
                case 100:
                    obj = new SkillActionDescriptionCraft();
                    break;
                case 104:
                    obj = new SkillActionDescriptionCraftExtended();
                    break;
                case 98:
                    obj = new JobExperience();
                    break;
                case 111:
                    obj = new HouseInformations();
                    break;
                case 112:
                    obj = new HouseInformationsExtended();
                    break;
                case 170:
                    obj = new HouseInformationsForGuild();
                    break;
                case 132:
                    obj = new PaddockInformations();
                    break;
                case 130:
                    obj = new PaddockBuyableInformations();
                    break;
                case 133:
                    obj = new PaddockAbandonnedInformations();
                    break;
                case 131:
                    obj = new PaddockPrivateInformations();
                    break;
                case 150:
                    obj = new GameContextActorInformations();
                    break;
                case 141:
                    obj = new GameRolePlayActorInformations();
                    break;
                case 157:
                    obj = new HumanInformations();
                    break;
                case 153:
                    obj = new HumanWithGuildInformations();
                    break;
                case 154:
                    obj = new GameRolePlayNamedActorInformations();
                    break;
                case 159:
                    obj = new GameRolePlayHumanoidInformations();
                    break;
                case 36:
                    obj = new GameRolePlayCharacterInformations();
                    break;
                case 3:
                    obj = new GameRolePlayMutantInformations();
                    break;
                case 129:
                    obj = new GameRolePlayMerchantInformations();
                    break;
                case 146:
                    obj = new GameRolePlayMerchantWithGuildInformations();
                    break;
                case 180:
                    obj = new GameRolePlayMountInformations();
                    break;
                case 147:
                    obj = new TaxCollectorStaticInformations();
                    break;
                case 148:
                    obj = new GameRolePlayTaxCollectorInformations();
                    break;
                case 167:
                    obj = new TaxCollectorInformations();
                    break;
                case 166:
                    obj = new TaxCollectorInformationsInWaitForHelpState();
                    break;
                case 186:
                    obj = new ProtectedEntityWaitingForHelpInfo();
                    break;
                case 169:
                    obj = new TaxCollectorFightersInformation();
                    break;
                case 165:
                    obj = new AdditionalTaxCollectorInformations();
                    break;
                case 144:
                    obj = new MonsterInGroupInformations();
                    break;
                case 140:
                    obj = new GroupMonsterStaticInformations();
                    break;
                case 160:
                    obj = new GameRolePlayGroupMonsterInformations();
                    break;
                case 155:
                    obj = new NpcStaticInformations();
                    break;
                case 156:
                    obj = new GameRolePlayNpcInformations();
                    break;
                case 161:
                    obj = new GameRolePlayPrismInformations();
                    break;
                case 143:
                    obj = new GameFightFighterInformations();
                    break;
                case 158:
                    obj = new GameFightFighterNamedInformations();
                    break;
                case 46:
                    obj = new GameFightCharacterInformations();
                    break;
                case 50:
                    obj = new GameFightMutantInformations();
                    break;
                case 151:
                    obj = new GameFightAIInformations();
                    break;
                case 29:
                    obj = new GameFightMonsterInformations();
                    break;
                case 203:
                    obj = new GameFightMonsterWithAlignmentInformations();
                    break;
                case 48:
                    obj = new GameFightTaxCollectorInformations();
                    break;
                case 174:
                    obj = new MapCoordinates();
                    break;
                case 176:
                    obj = new MapCoordinatesExtended();
                    break;
                case 175:
                    obj = new AtlasPointsInformations();
                    break;
                default:
                    throw new Exception("Type with id " + typeId + " is unknown.");
            }
            return obj;
        }
    }
}
