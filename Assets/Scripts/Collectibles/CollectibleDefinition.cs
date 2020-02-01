using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "NewCollectibleDefinition", menuName = "Jam2020/Collectible Definition")]
public class CollectibleDefinition : ScriptableObject
{
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public float speedBoost => _speedBoost;

    /// <summary>
    /// 
    /// </summary>
    public float speedBoostDuration => _speedBoostDuration;

    /// <summary>
    /// 
    /// </summary>
    public float jumpForceBoost => _jumpForceBoost;

    /// <summary>
    /// 
    /// </summary>
    public float jumpForceBoostDuration => _jumpForceBoostDuration;

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _speedBoost = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _speedBoostDuration = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _jumpForceBoost = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _jumpForceBoostDuration = 0.0f;

    #endregion
}
