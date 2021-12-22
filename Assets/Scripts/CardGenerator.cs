using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackAndWhite
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private Card _pfCard;

        public static CardGenerator Instance = null;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public Card SpawnCard()
        {
            return Instantiate(_pfCard).GetComponent<Card>();
        }
    }
}