using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelTransitionOpacity : MonoBehaviour
{
    private void OnTransition(int levelID)
    {
        Debug.Assert(_targetSprite != null);

        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(_delay);

        _targetSprite.DOFade(1.0f, _duration);
    }

    [SerializeField]
    private SpriteRenderer _targetSprite;

    [SerializeField]
    private float _delay = 3.0f;

    [SerializeField]
    private float _duration = 3.0f; 
}
