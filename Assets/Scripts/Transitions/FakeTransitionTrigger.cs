using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FakeTransitionTrigger : MonoBehaviour
{
    #region Messages

    private void Start()
    {
        _hasTriggered = false;
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() != null)
        {
            if (!_hasTriggered)
            {
                gameObject.SendMessage("OnTransition", -1);
                _hasTriggered = true;
            }
        }
    }

    #endregion

    #region Fields

    private bool _hasTriggered = false;

    #endregion
}
