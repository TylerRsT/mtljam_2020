using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if (character != null)
        {
            OnCharacterEnter(character);
        }
    }
    protected abstract void OnCharacterEnter(Character character);
}
