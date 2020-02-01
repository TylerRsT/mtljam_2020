using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Character))]
public class CharacterInput : MonoBehaviour
{
    #region Const

    private const string HorizontalMoveInputName = "Horizontal";
    private const string JumpInputName = "Jump";

    #endregion

    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _character = GetComponent<Character>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        _character.Move(Input.GetAxis(HorizontalMoveInputName));

        if(Input.GetButtonDown(JumpInputName))
        {
            _character.Jump();
        }
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    private Character _character;

    #endregion
}
