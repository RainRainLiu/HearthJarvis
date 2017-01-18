using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        

        public J_Entity(dynamic entityObj)
        {
            
        }



    }
}
