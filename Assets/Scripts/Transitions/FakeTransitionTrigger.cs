using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FakeTransitionTrigger : MonoBehaviour
{
    #region Messages

    private void Start()
    {
        _hasTriggered = false;
        GetComponent<Collider2D>().isTrigger = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasTriggered)
        {
            gameObject.SendMessage("OnTransition", -1);
            _hasTriggered = true;
        }
    }

    #endregion

    #region Fields

    private bool _hasTriggered = false;

    #endregion
}
