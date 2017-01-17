using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRangerLib;
using System.Collections;
using System.Collections.Generic;

namespace HearthJarvis.Objects
{
    class J_Entity : Entity
    {
        private string m_cardId;

        private int m_realTimeCost = -1;

        private int m_realTimeAttack;

        private int m_realTimeHealth;

        private int m_realTimeDamage;

        private int m_realTimeArmor;

        private bool m_realTimePoweredUp;

        private bool m_realTimeDivineShield;

        private int m_cardAssetLoadCount;

        private bool m_useBattlecryPower;

        private bool m_duplicateForHistory;

        Hashtable m_tags = new Hashtable();

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
                m_tags.Add(tagIds[i], tag[i]);
            }
            base.Armor = (int)m_tags[GAME_TAG.ATK];





            m_realTimeDivineShield = entityObj["m_realTimeDivineShield"];
            m_cardAssetLoadCount = entityObj["m_cardAssetLoadCount"];
            m_useBattlecryPower = entityObj["m_useBattlecryPower"];
            m_duplicateForHistory = entityObj["m_duplicateForHistory"];

            m_realTimePoweredUp = entityObj["m_realTimePoweredUp"];
        }
        /// <summary>
        /// 获取剩余的血量
        /// </summary>
        /// <returns></returns>hp
        public int GetRealTimeRemainingHP()
        {
            return this.m_realTimeHealth + this.m_realTimeArmor - this.m_realTimeDamage;
        }
        /// <summary>
        /// 实时的攻击力
        /// </summary>
        /// <returns></returns>
        public int GetRealTimeAttack()
        {
            return this.m_realTimeAttack;
        }
        /// <summary>
        /// 获取费用
        /// </summary>
        /// <returns></returns>
        public int GetRealTimeCost()
        {
            if (this.m_realTimeCost == -1)
            {
                return (int)GAME_TAG.COST;
            }
            return this.m_realTimeCost;
        }
        /// <summary>
        /// 启动？
        /// </summary>
        /// <returns></returns>
        public bool GetRealTimePoweredUp()
        {
            return this.m_realTimePoweredUp;
        }
        /// <summary>
        /// 圣盾
        /// </summary>
        /// <returns></returns>
        public bool GetRealTimeDivineShield()
        {
            return this.m_realTimeDivineShield;
        }



    }
}
