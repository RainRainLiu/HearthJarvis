using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
    public class Card
    {
        public enum CardType
        {
            None = 0,
            Hero = 3,       //英雄
            Minion = 4,     //随从
            Spell = 5,      //法术
            Weapon = 7,     //武器
            HeroPower = 10, //英雄技能
        }

        CardType type = CardType.None;       //卡类型
        public string CardId = "";

        public int RealTimeAttack = 0;  //实时的攻击力
        public int RealTimeCost = 0;    //费用
        public int RealTimeHealth = 0;  //HP
        public int RealTimeDamage = 0;  //损伤
        public int RemainingHP = 0;     //剩余的HP
        public int RealTimeArmor = 0;   //实时的护甲
        public bool RealTimeDivineShield = false;   //圣盾
        public int Durability = 0;//耐久，武器的

        public int Armor = 0;//护甲
        public int ATK = 0; //攻击力
        public int Cost = 0; //费用
        public int Damage = 0;//损伤
        public int Fatigue = 0;//疲劳
        public int Health = 0;//生命
        public int NumAttacksThisTurn = 0; //本回合可以攻击的次数
        public int SpellPower = 0; //法术能量

        public bool CanAttack = false;      //可以攻击
        public bool CanBeAttacked = false;  //可以被攻击
        public bool CanBeTargetedByBattlecries = false; //可以为多个目标
        public bool CanBeTargetedByHeroPowers = false;  //可以是英雄技能的目标
        public bool CanBeTargetedByOpponents = false;   //可以是敌人的目标
        public bool CanBeTargetedBySpells = false;      //可是是法术的目标
        public bool CannotAttackHeroes = false;         //不可以攻击英雄
        
        public bool HasAura = false; //有光环
        public bool HasBattlecry = false; //有战吼
        public bool HasCharge = false; //过载
        public bool HasDeathrattle = false; //亡语
        public bool HasDivineShield = false; //有圣盾
        public bool IsAsleep = false;//休眠
        public bool IsAttached = false;//攻击过了
        public bool IsEnraged = false; //愤怒
        public bool IsFreeze = false; //是冻结的
        public bool IsFrozen = false; //冰冻效果
    }
}
