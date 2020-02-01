using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterJumpingState : CharacterStateInstance
{
    #region Const

    private const float RaycastDistance = 0.2f;

    #endregion

    #region Override

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arg"></param>
    protected internal override void Enter(object arg = null)
    {
        base.Enter(arg);

        var multiplier = 1.0f;
        foreach(var boost in character.GetComponents<CollectibleBoost>())
        {
            multiplier += boost.jumpForceBoost;
        }

        character.rigidBody.AddForce(new Vector2(0.0f, character.characterDefinition.jumpForce * multiplier));
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal override void Update()
    {
        base.Update();

        if (character.rigidBody.velocity.y > 0.0f)
        {
            return;
        }

        var offset = character.GetComponent<BoxCollider2D>().size.x / 2.0f;

        if (DownRaycast(character.transform.position)) return;
        if (DownRaycast(new Vector3(character.transform.position.x - offset, character.transform.position.y))) return;
        if (DownRaycast(new Vector3(character.transform.position.x + offset, character.transform.position.y))) return;
    }

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
                return true;
            }
        }

        return false;
    }

    #endregion
}
