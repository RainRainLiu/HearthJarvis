using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthJarvis.Objects
{
    public class Card
    {
        public readonly string cardId;
        public Card(dynamic cardObj)
        {
            cardId = cardObj["m_entity"]["m_cardId"];   //
        }
        public string GetCardID()
        {
            return cardId;
        }
    }
}
