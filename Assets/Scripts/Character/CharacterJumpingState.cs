using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterJumpingState : CharacterStateInstance
{
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

        // note that the argument would override the jumb boosters (for trampoline tiles)
        if (arg != null & arg is float)
        {
            multiplier = (float)arg;
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

        var raycastHits = Physics2D.RaycastAll(character.transform.position, Vector2.down, 0.2f);
        foreach (var raycastHit in raycastHits)
        {
            if (raycastHit.collider != null && raycastHit.collider.gameObject != character.gameObject)
            {
                character.SetState(CharacterState.Idle);
                return;
            }
        }
    }

    #endregion
}
