using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BlackAndWhite
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SelectCardPosition _selectCardPosition;
        private PlayerHand _playerHand;

        public IntReactiveProperty WinPoint = new IntReactiveProperty(0);
        
        public Card SubmittedCard => _selectedCard;
        //选择的卡牌
        private Card _selectedCard;
        public Action SubmitAction { get;  set; }
        public bool Submitted { get; private set; } = false;

        [SerializeField] private PlayerType _playerType = PlayerType.Human;

        private void Awake()
        {
            _playerHand = GetComponent<PlayerHand>();
        }

        public void Init()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 1; i < 10; i++)
            {
                Card card = CardGenerator.Instance.SpawnCard();
                card.InitCard(i);
                card.SetupPlayerType(_playerType);
                card.OnCardSelect += HandleOnCardSelect;
                cardList.Add(card);
            }

            _playerHand.SetupPlayerHandCards(cardList);
        }

        private void HandleOnCardSelect(Card card)
        {
            SelectCard(card);
        }

        public void SelectCard(Card card)
        {
            if (_selectedCard != null)
            {
                _playerHand.AddCard(_selectedCard);
            }
            _selectedCard = card;
             _selectCardPosition.SetCard(_selectedCard);
            _playerHand.RemoveCard(_selectedCard);
        }

        public void SubmitCard()
        {
            if (_selectedCard != null)
            {
                Submitted = true;
                SubmitAction?.Invoke();

                _playerHand.SortCard();
                _playerHand.DisableCardSelectable();
            }
        }

        public void ShuffleCard()
        {
            _playerHand.ShuffleHandCards();
        }

        public void RandomSelectCard()
        {
            SelectCard(_playerHand.RandomSelectCard());
        }

        public void DestroySubmitCard()
        {
            _playerHand.RemoveCard(_selectedCard);
            Destroy(_selectedCard.gameObject);
            _selectedCard = null;
            Submitted = false;
            _playerHand.EnableCardSelectable();
        }
    }
}