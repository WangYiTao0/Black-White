using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlackAndWhite
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMeshPro _numberText;

        [FormerlySerializedAs("CanbeSelectted")] public bool Selectable = true;
        
        public int Number;
        public Action<Card> OnCardSelect;
        private PlayerType _playerType = PlayerType.Human;
        
        public Vector3 CurrentCardPosition;
        
        public void InitCard(int num)
        {
            Number = num;
            _numberText.SetText(num.ToString());
            if (num % 2 == 0)
            {
                _spriteRenderer.color = Color.white;
                _numberText.color = Color.black;
            }
            else if (num % 2 == 1)
            {
                _spriteRenderer.color = Color.black;
                _numberText.color = Color.white;
            }
        }
        
        public void SetupCardPosition()
        {
            CurrentCardPosition = transform.position;
        }

        public void SetupPlayerType(PlayerType playerType)
        {
            _playerType = playerType;
            if (playerType == PlayerType.CPU)
            {
                _spriteRenderer.sortingOrder += 2;
            }
        }

        private void OnMouseEnter()
        {
            if (_playerType == PlayerType.CPU)
                return; ;    
            transform.localScale = Vector3.one * 1.2f;
        }

        private void OnMouseDown()
        {
            if (_playerType == PlayerType.CPU)
                return;
            if (!Selectable)
                return;    
            OnCardSelect?.Invoke(this);
        }

        private void OnMouseExit()
        {
            if (_playerType == PlayerType.CPU)
                return;
            transform.localScale = Vector3.one;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = transform.Find("CardImage").GetComponent<SpriteRenderer>();
            }

            if (_numberText == null)
            {
                _numberText = transform.Find("NumberText").GetComponent<TextMeshPro>();
            }
        }
#endif
    }

    public enum PlayerType
    {
        Human,
        CPU,
    }
}
