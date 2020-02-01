using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public enum CharacterState
{
    Idle,

    Moving,

    Jumping,
}

/// <summary>
/// 
/// </summary>
public abstract class CharacterStateInstance
{
    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected internal virtual void Initialize(Character character)
    {
        this.character = character;
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void Enter(object arg = null)
    { }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void Update()
    { }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void Exit()
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="direction"></param>
    protected internal virtual void Move(float direction)
    {
        Debug.Assert(character.characterDefinition != null, "Character Definition not set for character.");

        if (direction < 0.0f)
        {
            character.horizontalFacingDirection = CharacterHorizontalFacingDirection.FacingLeft;
        }
        else if (direction > 0.0f)
        {
            character.horizontalFacingDirection = CharacterHorizontalFacingDirection.FacingRight;
        }

        character.rigidBody.velocity = new Vector2(direction * character.characterDefinition.speed,
            Mathf.Clamp(character.rigidBody.velocity.y,
                character.characterDefinition.minVerticalVelocity,
                character.characterDefinition.maxVerticalVelocity)
            );
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void Jump()
    {
        character.SetState(CharacterState.Jumping);
    }

    #endregion

    #region Properties

    protected Character character { get; private set; }

    #endregion
}
