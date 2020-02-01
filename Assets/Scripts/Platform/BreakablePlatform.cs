﻿using System.Collections;
using System.Collections.Generic;
using CreativeSpore.SuperTilemapEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BreakablePlatform : PlatformBase
{
    #region Override

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected override void OnCharacterEnter(Character character)
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(DelaySelfDestruction());
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelaySelfDestruction()
    {
        yield return new WaitForSeconds(_delayBeforeBreak);

        float elapsedTime = 0.0f;
        float startingA = _spriteRenderer.color.a;
        while (elapsedTime <= _disappearSpeed)
        {
            _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(startingA, 0.0f, elapsedTime / _disappearSpeed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1.0f / 60.0f);
        }
        _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _rigidBody.simulated = false;

        yield return new WaitForSeconds(_delayBeforeReappear);

        elapsedTime = 0.0f;
        while (elapsedTime <= _reappearSpeed)
        {
            _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, _reappearSpeed, elapsedTime / _reappearSpeed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1.0f / 60.0f);
        }
        _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, startingA);
        _rigidBody.simulated = true;

        yield break;
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _delayBeforeBreak = 0.8f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _delayBeforeReappear = 3.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _disappearSpeed = 0.1f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _reappearSpeed = 0.1f;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D _rigidBody;

    /// <summary>
    /// 
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    #endregion
}
