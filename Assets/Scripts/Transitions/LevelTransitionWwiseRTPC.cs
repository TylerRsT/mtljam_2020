using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionWwiseRTPC : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(_rtpcKey), "RTPC Key not set.");
        AkSoundEngine.SetRTPCValue(_rtpcKey, _rtpcValue);
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private string _rtpcKey = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _rtpcValue = 0.0f;

    #endregion
}
