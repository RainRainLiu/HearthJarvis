using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
    /// <summary>
    /// 玩家信息
    /// </summary>
    public class Player
    {
        Card heroCard;//英雄

        List<Card> handCard = new List<Card>(); //手牌

        List<Card> graveyardCard = new List<Card>(); //坟场

        List<Card> deckCard = new List<Card>(); //牌库

        List<Card> fieldMinion = new List<Card>(); //场上的随从
    }
}
