using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRangerLib;
using System.Collections;

namespace HearthJarvis.Objects
{
    class J_Entity : Entity
    {
        private int m_realTimeCost = -1;

        private int m_realTimeHealth;

        private int m_realTimeDamage;

        private int m_realTimeArmor;

        private bool m_realTimePoweredUp;

        private bool m_realTimeDivineShield;

        private int m_cardAssetLoadCount;

        private bool m_useBattlecryPower;

        private bool m_duplicateForHistory;

        Hashtable m_tags = new Hashtable();

        public int GetTagValue(GAME_TAG tag)
        {
            if (m_tags.Contains(tag))
            {
                return (int)m_tags[tag];
            }
            return -1;
        }

        public J_Entity(dynamic entityObj)
        {
            base.CardId = entityObj["m_cardId"];
            base.RealtimeCost = entityObj["m_realTimeCost"];
            base.RealtimeATK = entityObj["m_realTimeAttack"];
            m_realTimeHealth = entityObj["m_realTimeHealth"];
            m_realTimeDamage = entityObj["m_realTimeDamage"];
            m_realTimeArmor = entityObj["m_realTimeArmor"];
            base.RealTimeRemainingHP = this.m_realTimeHealth + this.m_realTimeArmor - this.m_realTimeDamage;

            var tagIds = entityObj["m_tags"]["m_values"]["keySlots"];
            var tag = entityObj["m_tags"]["m_values"]["valueSlots"];
            for (int i = 0; i < tagIds.Length; i++)
            {
                if (tagIds[i] != 0)
                {
                    m_tags.Add(tagIds[i], (int)tag[i]);
                    base.AllTags.Add(new EntityTag(tagIds[i], (int)tag[i]));
                }
            }

            base.Armor = GetTagValue(GAME_TAG.ARMOR);
            base.ATK = GetTagValue(GAME_TAG.ATK);
            





            m_realTimeDivineShield = entityObj["m_realTimeDivineShield"];
            m_cardAssetLoadCount = entityObj["m_cardAssetLoadCount"];
            m_useBattlecryPower = entityObj["m_useBattlecryPower"];
            m_duplicateForHistory = entityObj["m_duplicateForHistory"];

            m_realTimePoweredUp = entityObj["m_realTimePoweredUp"];
        }



    }
}
