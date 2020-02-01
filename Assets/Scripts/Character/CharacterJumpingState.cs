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
        if (arg != null && arg is float)
        {
            multiplier = (float)arg;
        }

        character.rigidBody.AddForce(new Vector2(0.0f, character.characterDefinition.jumpForce * multiplier));
        character.audioJumpingEvent.Post(character.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal override bool canJump => false;

    #endregion
}
