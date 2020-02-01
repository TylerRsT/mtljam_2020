using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CollectibleBoost : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if(!activated)
        {
            return;
        }

        elapsed += Time.deltaTime;
        if (elapsed >= duration)
        {
            DestroyImmediate(this);
            return;
        }
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public float speedBoost
    {
        get
        {
            return activated && elapsed < _definition.speedBoostDuration ? _definition.speedBoost : 1.0f;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float jumpForceBoost
    {
        get
        {
            return activated && elapsed < _definition.jumpForceBoostDuration ? _definition.jumpForceBoost : 1.0f;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public CollectibleDefinition definition
    {
        get { return _definition; }
        set
        {
            Debug.Assert(_definition == null, "Cannot change collectible boost definition after first set.");
            _definition = value;

            activated = true;
            duration = Mathf.Max(_definition.speedBoostDuration, _definition.jumpForceBoostDuration);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool activated { get; private set; } = false;

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    private CollectibleDefinition _definition;

    /// <summary>
    /// 
    /// </summary>
    private float elapsed = 0.0f;

    private float duration = 0.0f;

    #endregion
}
