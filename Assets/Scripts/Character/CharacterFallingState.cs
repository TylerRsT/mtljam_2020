using CreativeSpore.SuperTilemapEditor;
using Elendow.SpritedowAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CharacterFallingState : CharacterStateInstance
{
    #region Const

    private const float RaycastDistance = 0.2f;
    private const float SoundMinInterval = 0.15f;

    #endregion

    #region Override

    protected internal override void Enter(object arg = null)
    {
        base.Enter(arg);

        var spriteAnimator = character.GetComponent<SpriteAnimator>();
        var characterAnimator = character.GetComponent<CharacterAnimator>();
        var spriteRenderer = character.GetComponent<SpriteRenderer>();
        spriteAnimator.Stop();
        spriteRenderer.sprite = characterAnimator.fallLoopAnimation.GetFrame(0);
        
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal override void Update()
    {
        base.Update();

        if(_soundPostDelay > 0.0f)
        {
            _soundPostDelay = Mathf.Max(_soundPostDelay - Time.deltaTime, 0.0f);
        }

        var offset = character.GetComponent<BoxCollider2D>().size.x / 2.0f;

        if (DownRaycast(character.transform.position)) return;
        if (DownRaycast(new Vector3(character.transform.position.x - offset, character.transform.position.y))) return;
        if (DownRaycast(new Vector3(character.transform.position.x + offset, character.transform.position.y))) return;
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal override bool canJump => false;

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private bool DownRaycast(Vector3 position)
    {
        var raycastHits = Physics2D.RaycastAll(position, Vector2.down, RaycastDistance);
        foreach (var raycastHit in raycastHits)
        {
            if (raycastHit.collider != null && raycastHit.collider.gameObject != character.gameObject
                && raycastHit.collider.GetComponent<RepulsivePlatform>() == null)
            {
                var chunk = raycastHit.collider.GetComponent<TilemapChunk>();
                if(chunk != null)
                {
                    if(chunk.ParentTilemap.GetComponent<SplinePlatform>())
                    {
                        continue;
                    }
                }

                foreach(var characterInputLock in character.GetComponents<CharacterInputLock>())
                {
                    GameObject.Destroy(characterInputLock);
                }
                character.SetState(CharacterState.Idle);
                if (_soundPostDelay == 0.0f)
                {
                    character.audioLandingEvent.Post(character.gameObject);
                    _soundPostDelay = SoundMinInterval;
                }
                return true;
            }
        }

        return false;
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    private float _soundPostDelay = 0.0f;

    #endregion 
}
