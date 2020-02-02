using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SplinePlatform : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();
        if(character == null)
        {
            return;
        }

        character.SetState(CharacterState.Falling);
        if (character.GetComponent<CharacterInputLock>() == null)
        {
            character.rigidBody.velocity = new Vector2(character.rigidBody.velocity.x, _impulse);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();
        if (character == null)
        {
            return;
        }

        character.SetState(CharacterState.Falling);
        if (character.GetComponent<CharacterInputLock>() == null)
        {
            character.rigidBody.velocity = new Vector2(character.rigidBody.velocity.x, _exitImpulse);
        }
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _impulse = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _exitImpulse = 5.0f;

    #endregion
}
