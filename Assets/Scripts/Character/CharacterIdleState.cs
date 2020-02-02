using Elendow.SpritedowAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterStateInstance
{
    #region Override

    protected internal override void Enter(object arg = null)
    {
        base.Enter(arg);

        var spriteAnimator = character.GetComponent<SpriteAnimator>();
        var characterAnimator = character.GetComponent<CharacterAnimator>();
        spriteAnimator.Play(characterAnimator.idleAnimation);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="direction"></param>
    protected internal override void Move(float direction)
    {
        if (direction != 0.0f)
        {
            character.SetState(CharacterState.Moving);
        }
        base.Move(direction);
    }

    #endregion
}
