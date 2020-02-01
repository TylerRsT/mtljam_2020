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

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    protected internal override void Update()
    {
        base.Update();

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
            if (raycastHit.collider != null && raycastHit.collider.gameObject != character.gameObject)
            {
                character.SetState(CharacterState.Idle);
                character.audioLandingEvent.Post(character.gameObject);
                return true;
            }
        }

        return false;
    }

    #endregion
}
