using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthJarvis.Objects
{
    public class Card
    {
        public J_Entity entity;
        public Card(dynamic cardObj)
        {
            entity = new J_Entity(cardObj["m_entity"]);
        }
        public string GetCardID()
        {
            return entity.CardId;
        }
    }
}
