using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "NewCharacterDefinition", menuName = "Jam2020/Character Definition")]
public class CharacterDefinition : ScriptableObject
{
    #region Properties

    public float speed => _speed;

    public float jumpForce => _jumpForce;

    public float minVerticalVelocity => _minVerticalVelocity;

    public float maxVerticalVelocity => _maxVerticalVelocity;

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _speed = 10f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _jumpForce = 300f;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _minVerticalVelocity = -25f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _maxVerticalVelocity = 25f;

    #endregion
}
