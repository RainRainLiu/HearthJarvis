using System;
using System.Collections.Generic;
using System.Linq;
using HearthJarvis.Objects;
using Jarvis;
using System.Collections;
namespace HearthJarvis
{
	public class Reflection
	{
		private static readonly Lazy<Mirror> LazyMirror = new Lazy<Mirror>(() => new Mirror {ImageName = "Hearthstone"});
		private static Mirror Mirror => LazyMirror.Value;

		private static T TryGetInternal<T>(Func<T> action, bool clearCache = true)
		{
			try
			{
				if(clearCache)
					Mirror.View?.ClearCache();
				return action.Invoke();
			}
			catch
			{
				Mirror.Clean();
				try
				{
					return action.Invoke();
				}
				catch
				{
					return default(T);
				}
			}
		}

        //��ȡ�Լ�������
        //���� ���б�
        public static List<Card> GetFriendHandCards() =>  GetHandCardsInternal(Player.Side.FRIENDLY, "ZoneHand");

        private static List<Card> GetHandCardsInternal(Player.Side side, string zoneName)
        {
            List<Card> cards = new List<Card>();
            var m_zones = Mirror.Root["ZoneMgr"]["s_instance"]["m_zones"]; //��ȡzone�б�
            var zones = m_zones["_items"];
            int size = m_zones["_size"]; 

            for (var i = 3; i < size; i ++)
            {
                if ((Player.Side)zones[i]["m_Side"] == side)
                {
                    if (zones[i]?.Class.Name != zoneName)
                    {
                        continue;
                    }
                    //cards = (List<Card>)zones[i]["m_cards"];
                    var m_cards = zones[i]["m_cards"];
                    var _cards = m_cards["_items"];
                    int _size = m_cards["_size"];
                    for (var j = 0; j < _size; j++)
                    {
                        //Card c = (Card)_cards[j];
                        string id =  _cards[j]["m_entity"]["m_entityDef"]["m_cardId"];
                        Card c = new Card(id);
                        cards.Add(c);
                    }
                    return cards;
                }
            }
            return null;
        }
        //��ȡ�����б�
        public static List<Deck> GetDecks() => TryGetInternal(() => InternalGetDecks().ToList());

        private static IEnumerable<Deck> InternalGetDecks()
        {
            var values = Mirror.Root["CollectionManager"]["s_instance"]?["m_decks"]?["valueSlots"];
            if (values == null)
                yield break;
            foreach (var val in values)
            {
                if (val == null || val.Class.Name != "CollectionDeck")
                    continue;
                var deck = GetDeck(val);
                if (deck != null)
                    yield return deck;
            }
        }
        private static Deck GetDeck(dynamic deckObj)
        {
            if (deckObj == null)
                return null;
            var deck = new Deck
            {
                Id = deckObj["ID"],
                Name = deckObj["m_name"],
                Hero = deckObj["HeroCardID"],
                IsWild = deckObj["m_isWild"],
                //Type = deckObj["Type"],
                //SeasonId = deckObj["SeasonId"],
                //CardBackId = deckObj["CardBackID"],
                //HeroPremium = deckObj["HeroPremium"],
            };
            var cardList = deckObj["m_slots"];
            var cards = cardList["_items"];
            int size = cardList["_size"];
            for (var i = 0; i < size; i++)
            {
                var card = cards[i];
                string cardId = card["m_cardId"];
                int count = card["m_count"];
                for (int j = 0; j < count; j++)
                {
                    deck.Card_ID.Add(cardId);
                }
            }
            return deck;
        }

        //��ȡѡ�ƣ����ǿ���ʱ��ѡ������
        public static List<Card> GetMulliganCards()
        {
            List<Card> c = new List<Card>();

            var cardList =  Mirror.Root["MulliganManager"]?["s_instance"]?["m_startingCards"];

            var cards = cardList["_items"];
            int size = cardList["_size"];
            for (var i = 0; i < size; i++)
            {
                var card = cards[i];
                string cardId = card["m_entity"]["m_entityDef"]["m_cardId"];
                //int count = card["m_count"];
                //for (int j = 0; j < count; j++)
                {
                    Card cc = new Card(card);
                    c.Add(cc);
                }
            }
            return c;
        }


        public static int GetHistory()
        {
            var TileEntry = Mirror.Root["HistoryManager"]["s_instance"]?["m_historyTiles"];

            var his = TileEntry["_items"];

            int size = TileEntry["_size"];
            return size;
        }
        

        static int GetTagValue(Hashtable ht, GAME_TAG tag)
        {
            if (ht.Contains(tag))
            {
                return (int)ht[tag];
            }
            return -1;
        }
        public static Card GetCard(dynamic entityObj)
        {
            Card card = new Card();
            Hashtable m_tags = new Hashtable();

            card.CardId = entityObj["m_cardId"];
            card.RealTimeCost = entityObj["m_realTimeCost"];
            card.RealTimeAttack = entityObj["m_realTimeAttack"];
            card.RealTimeHealth = entityObj["m_realTimeHealth"];
            card.RealTimeDamage = entityObj["m_realTimeDamage"];
            card.RealTimeArmor = entityObj["m_realTimeArmor"];
            card.RemainingHP = card.RealTimeHealth + card.RealTimeArmor - card.RealTimeDamage;

            var tagIds = entityObj["m_tags"]["m_values"]["keySlots"];
            var tag = entityObj["m_tags"]["m_values"]["valueSlots"];
            for (int i = 0; i < tagIds.Length; i++)
            {
                if (tagIds[i] != 0)
                {
                    m_tags.Add(tagIds[i], (int)tag[i]);
                }
            }

            card.Armor = GetTagValue(m_tags, GAME_TAG.ARMOR);
            card.ATK = GetTagValue(m_tags, GAME_TAG.ATK);
            card.Cost = GetTagValue(m_tags, GAME_TAG.COST);
            card.Health = GetTagValue(m_tags, GAME_TAG.HEALTH);




            m_realTimeDivineShield = entityObj["m_realTimeDivineShield"];
            m_cardAssetLoadCount = entityObj["m_cardAssetLoadCount"];
            m_useBattlecryPower = entityObj["m_useBattlecryPower"];
            m_duplicateForHistory = entityObj["m_duplicateForHistory"];

            m_realTimePoweredUp = entityObj["m_realTimePoweredUp"];

            return card;
        }

        //public static int GetNavigationHistorySize() => TryGetInternal(() => Mirror.Root["Navigation"]?["history"]?["_size"]) ?? 0;

    }
}