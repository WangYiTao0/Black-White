using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Title : MonoBehaviour
{
    private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

    private void Start()
    {
        _tween = transform.DOScale(Vector3.one * 1.2f, 2f).SetLoops(-1,LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}
