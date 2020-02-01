using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterStateInstance
{
    #region Override

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
