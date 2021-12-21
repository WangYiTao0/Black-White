using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField]  private TextMeshPro _numberText;

    [SerializeField]
    private MMFeedbacks _mmFeedback;

    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
        _mmFeedback.PlayFeedbacks();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseExit()
    {
        
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
