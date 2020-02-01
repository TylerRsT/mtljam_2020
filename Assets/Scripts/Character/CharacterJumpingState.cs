﻿using System.Collections;
using System.Collections.Generic;
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
        character.rigidBody.AddForce(new Vector2(0.0f, character.characterDefinition.jumpForce));
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
