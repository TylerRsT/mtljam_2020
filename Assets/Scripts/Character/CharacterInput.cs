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
    private const string RightMoveInputName = "Right";
    private const string LeftMoveInputName = "Left";
    private const string JumpInputName = "Jump";
    private const string ExitGameInputName = "ExitGame";

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
#if !UNITY_EDITOR
        if(Input.GetButtonDown(ExitGameInputName))
        {
            Application.Quit();
        }
#endif // UNITY_EDITOR

        if (Input.GetButton(RightMoveInputName))
        {
            _character.Move(1.0f);
        }
        else if (Input.GetButton(LeftMoveInputName))
        {
            _character.Move(-1.0f);
        }
        else
        {
            _character.Move(Input.GetAxis(HorizontalMoveInputName));
        }

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
