using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public enum CharacterHorizontalFacingDirection
{
    FacingRight,

    FacingLeft,
}

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="direction"></param>
    public void Move(float direction)
    {
        Debug.Assert(_characterDefinition != null, "Character Definition not set for character.");

        if (direction < 0.0f)
        {
            horizontalFacingDirection = CharacterHorizontalFacingDirection.FacingLeft;
        }
        else if (direction > 0.0f)
        {
            horizontalFacingDirection = CharacterHorizontalFacingDirection.FacingRight;
        }

        _rigidBody.velocity = new Vector2(direction * _characterDefinition.speed,
            Mathf.Clamp(_rigidBody.velocity.y, _characterDefinition.minVerticalVelocity, _characterDefinition.maxVerticalVelocity));
    }

    /// <summary>
    /// 
    /// </summary>
    public void Jump()
    {
        _rigidBody.AddForce(new Vector2(0.0f, _characterDefinition.jumpForce));
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnCharacterDefinitionChanged()
    { }

    /// <summary>
    /// 
    /// </summary>
    private void OnHorizontalFacingDirectionChanged()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = _horizontalFacingDirection == CharacterHorizontalFacingDirection.FacingLeft;
        }
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public CharacterDefinition characterDefinition
    {
        get { return _characterDefinition; }
        set
        {
            _characterDefinition = value;
            OnCharacterDefinitionChanged();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public CharacterHorizontalFacingDirection horizontalFacingDirection
    {
        get { return _horizontalFacingDirection; }
        set
        {
            _horizontalFacingDirection = value;
            OnHorizontalFacingDirectionChanged();
        }
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private CharacterDefinition _characterDefinition = default;

    /// <summary>
    /// 
    /// </summary>
    private CharacterHorizontalFacingDirection _horizontalFacingDirection = default;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D _rigidBody = default;

    #endregion
}
