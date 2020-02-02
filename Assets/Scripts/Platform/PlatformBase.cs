using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if (character != null && AcceptsCollision(collision))
        {
            OnCharacterEnter(character, collision);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    protected virtual bool AcceptsCollision(Collision2D collision)
    {
        return collision.contacts.First().normal == Vector2.down;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected abstract void OnCharacterEnter(Character character, Collision2D collision);

    #endregion
}
