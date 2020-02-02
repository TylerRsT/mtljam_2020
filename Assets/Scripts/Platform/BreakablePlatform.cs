using System.Collections;
using System.Collections.Generic;
using CreativeSpore.SuperTilemapEditor;
using Elendow.SpritedowAnimator;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BreakablePlatform : PlatformBase
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected override void OnCharacterEnter(Character character, Collision2D collision)
    {
        if (!_coroutineTriggered)
        {
            _enterSound?.Post(gameObject);
            var spriteAnimator = GetComponent<SpriteAnimator>();
            spriteAnimator.Play();
            StartCoroutine(DelaySelfDestruction());
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelaySelfDestruction()
    {
        _coroutineTriggered = true;
        _startBreakingSound?.Post(gameObject);
        yield return new WaitForSeconds(_delayBeforeBreak);

        var spriteAnimator = GetComponent<SpriteAnimator>();
        spriteAnimator.Play(spriteAnimator.animations[1], true, false);

        float elapsedTime = 0.0f;
        float startingA = _spriteRenderer.color.a;
        _breakSound?.Post(gameObject);
        _rigidBody.simulated = false;

        while (elapsedTime <= _disappearSpeed)
        {
            _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(startingA, 0.0f, elapsedTime / _disappearSpeed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1.0f / 60.0f);
        }
        _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        yield return new WaitForSeconds(_delayBeforeReappear);

        _reappearSound?.Post(gameObject);
        elapsedTime = 0.0f;
        while (elapsedTime <= _reappearSpeed)
        {
            _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, _reappearSpeed, elapsedTime / _reappearSpeed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1.0f / 60.0f);
        }
        _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, startingA);
        _rigidBody.simulated = true;

        spriteAnimator.Play(spriteAnimator.animations[1], true, true);

        _coroutineTriggered = false;
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
    [SerializeField]
    private AK.Wwise.Event _enterSound = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AK.Wwise.Event _startBreakingSound = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AK.Wwise.Event _breakSound = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AK.Wwise.Event _reappearSound = default;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D _rigidBody;

    /// <summary>
    /// 
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// 
    /// </summary>
    private bool _coroutineTriggered = false;

    #endregion
}
