using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace BlackAndWhite
{
    public class SelectCardPosition : MonoBehaviour
    {
        private Card _selectCard;


        public void SetCard(Card card)
        {
            if (_selectCard != null)
            {
                _selectCard.transform.DOKill();
                _selectCard.transform.DOMove(_selectCard.CurrentCardPosition, 1f);
                _selectCard.transform.DOScale(Vector3.one, 0.5f);
            }

            _selectCard = card;
            card.transform.SetParent(transform);
            card.transform.DOLocalMove(Vector3.zero, 1f);
            card.transform.DOScale(Vector3.one * 1.5f, 1f);
        }
    }
}
