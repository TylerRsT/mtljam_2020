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

        if (character != null && collision.contacts.First().normal == Vector2.down)
        {
            OnCharacterEnter(character);
        }
    }

    #endregion

    #region Abstract

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected abstract void OnCharacterEnter(Character character);

    #endregion
}
