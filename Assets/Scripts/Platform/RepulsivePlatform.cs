using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class RepulsivePlatform : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if (character != null)
        {
            OnCharacterEnter(character, collision);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    /// <param name="collision"></param>
    private void OnCharacterEnter(Character character, Collision2D collision)
    {
        if (character.GetComponent<CharacterInputLock>() == null)
        {
            character.gameObject.AddComponent<CharacterInputLock>().duration = _duration;
        }

        var impulseForce = _impulseForce;

        if (!_forceDirection)
        {
            var xMultiplier = character.horizontalFacingDirection == CharacterHorizontalFacingDirection.FacingLeft ?
                1.0f : -1.0f;
            impulseForce.x *= xMultiplier;
        }

        character.rigidBody.AddForce(impulseForce);
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Vector2 _impulseForce = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _duration = 2.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool _forceDirection = false;

    #endregion
}
