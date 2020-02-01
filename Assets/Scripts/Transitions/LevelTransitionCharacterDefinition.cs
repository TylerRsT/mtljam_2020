using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionCharacterDefinition : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        Debug.Assert(_targetCharacter != null, "No target character set.");
        Debug.Assert(_newCharacterDefinition != null, "No character definition set.");

        _targetCharacter.characterDefinition = _newCharacterDefinition;
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Character _targetCharacter = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private CharacterDefinition _newCharacterDefinition = default;

    #endregion
}
