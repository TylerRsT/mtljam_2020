using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Collectible : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        Debug.Assert(_definition != null, "Collectible Definition not set.");

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 0.05f, 0.5f));
        sequence.Append(transform.DOMoveY(transform.position.y, 0.5f));
        sequence.SetLoops(-1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if(character != null)
        {
            var boost = character.gameObject.AddComponent<CollectibleBoost>();
            boost.definition = _definition;

            _collectedEvent?.Post(gameObject);

            Destroy(gameObject);
        }
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private CollectibleDefinition _definition = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AK.Wwise.Event _collectedEvent = default;

    #endregion
}
