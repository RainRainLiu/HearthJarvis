using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
    public enum ActionType  //行动类型
    {
        endturn = 0,        //结束回合
        playcard,           //出牌
        attackWithHero,     //攻击英雄
        useHeroPower,       //使用英雄技能
        attackWithMinion    //攻击随从
    }
    class Action
    {
        ActionType type;
        Card own;
        Card target;

    }
}
