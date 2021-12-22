using System.Collections.Generic;
using BlackAndWhite.Tool;
using UnityEngine;

namespace BlackAndWhite
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private List<Card> _handCardList = new List<Card>();
        
        /// <summary>
        /// 设置玩家手牌
        /// </summary>
        /// <param name="cardList"></param>
        public void SetupPlayerHandCards(List<Card> cardList)
        {
            _handCardList = cardList;
            SortCard(true);
        }

        public void ShuffleHandCards()
        {
            _handCardList.Shuffle();
            SortCard(false);
        }

        public void AddCard(Card card)
        {
            _handCardList.Add(card);
            //RefreshCardPosition();
        }

        public void RemoveCard(Card card)
        {
            _handCardList.Remove(card);
            //RefreshCardPosition();
        }
        
        /// <summary>
        /// 整理手牌位置
        /// </summary>
        public void SortCard(bool isInOrder = false)
        {
            if (isInOrder)
            {
                _handCardList.Sort((cardA, cardB) => cardA.Number - cardB.Number);
                //整理手牌顺序
            }
        
            for (int i = 0; i < _handCardList.Count; i++)
            {
                //设定父对象
                _handCardList[i].transform.SetParent(this.transform);
                //以父对象中心点开始 排列
                int x = i - _handCardList.Count / 2;
                _handCardList[i].transform.localPosition = new Vector3(x* 0.8f, 0, 0);
                _handCardList[i].SetupCardPosition();
            }
        }


        public Card RandomSelectCard()
        {
            int r = Random.Range(0, _handCardList.Count);
            Card card = _handCardList[r];
            RemoveCard(card);
            return card;
        }

        public void DisableCardSelectable()
        {
            foreach (var card in _handCardList)
            {
                card.Selectable = false;
            }
        }
        public void EnableCardSelectable()
        {
            foreach (var card in _handCardList)
            {
                card.Selectable = true;
            }
        }
    }
}