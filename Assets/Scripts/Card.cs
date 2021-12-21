using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    public TextMeshPro _numberText;


    private void OnMouseEnter()
    {
        
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
