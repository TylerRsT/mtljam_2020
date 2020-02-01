using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BouncePlatform : PlatformBase
{
    #region Override

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected override void OnCharacterEnter(Character character)
    {
        character.SetState(CharacterState.Jumping, _bouncingForce);
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _bouncingForce = 1.0f;

    #endregion
}
