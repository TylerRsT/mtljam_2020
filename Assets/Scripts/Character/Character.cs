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

        foreach(var stateInstance in _stateInstances.Values)
        {
            stateInstance?.Initialize(this);
        }
        stateInstance?.Enter();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if (rigidBody.velocity.y < 0.0f)
        {
            SetState(CharacterState.Falling);
        }
        stateInstance?.Update();
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newState"></param>
    /// <param name="arg"></param>
    public void SetState(CharacterState newState, object arg = null)
    {
        if(newState == _state)
        {
            return;
        }

        stateInstance?.Exit();
        _state = newState;
        stateInstance?.Enter(arg);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="direction"></param>
    public void Move(float direction)
    {
        stateInstance?.Move(direction);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Jump()
    {
        if(stateInstance.canJump)
        {
            SetState(CharacterState.Jumping);
        }
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

    /// <summary>
    /// 
    /// </summary>
    public CharacterState state => _state;

    /// <summary>
    /// 
    /// </summary>
    public CharacterStateInstance stateInstance
    {
        get { return _stateInstances[_state]; }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rigidbody2D rigidBody => _rigidBody;

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
    [SerializeField]
    private CharacterState _state = default;

    private Dictionary<CharacterState, CharacterStateInstance> _stateInstances = new Dictionary<CharacterState, CharacterStateInstance>
    {
        {CharacterState.Idle, new CharacterIdleState() },
        {CharacterState.Moving, new CharacterMovingState() },
        {CharacterState.Jumping, new CharacterJumpingState() },
        {CharacterState.Falling, new CharacterFallingState() },
    };

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
