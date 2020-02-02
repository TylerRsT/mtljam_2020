using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Character))]
public class CharacterInputLock : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _character = GetComponent<Character>();
        var spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = spriteRenderer.color;
        var noAlpha = spriteRenderer.color;
        noAlpha.a = 0.0f;

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Append(spriteRenderer.DOColor(noAlpha, 0.1f));
        _tweenSequence.Append(spriteRenderer.DOColor(_originalColor, 0.1f));
        _tweenSequence.SetLoops(10);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        _elapsed += Time.deltaTime;
        
        if(_elapsed >= duration)
        {
            Destroy(this);
        }
        else
        {
            _character.canInput = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        _character.canInput = true;

        if(_tweenSequence.IsPlaying())
        {
            _tweenSequence.Kill();
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = _originalColor;
        }
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public float duration { get; set; } = 0.0f;

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    private float _elapsed = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    private Character _character;

    /// <summary>
    /// 
    /// </summary>
    private Sequence _tweenSequence;

    /// <summary>
    /// 
    /// </summary>
    private Color _originalColor;

    #endregion
}
