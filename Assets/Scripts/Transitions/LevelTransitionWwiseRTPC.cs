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
        /*Debug.Assert(!string.IsNullOrWhiteSpace(_rtpcKey), "RTPC Key not set.");
        if(_duration == 0.0f)
        {
            AkSoundEngine.SetRTPCValue(_rtpcKey, _rtpcValue);
            return;
        }
        _transitionStarted = true;

        int rtpcQueryValue = (int)AkQueryRTPCValue.RTPCValue_Global;
        AkSoundEngine.GetRTPCValue(_rtpcKey, null, 0, out _currentValue, ref rtpcQueryValue);

        float diff = _rtpcValue - _currentValue;
        //Debug.Assert(diff == 0.0f, "Difference can not be 0.0f.");

        _step = diff * Time.fixedDeltaTime / _duration;*/
    }

    /// <summary>
    /// 
    /// </summary>
    private void FixedUpdate()
    {
        /*if(!_transitionStarted)
        {
            return;
        }

        _elapsed += Time.fixedDeltaTime;

        if(_elapsed >= _duration)
        {
            AkSoundEngine.SetRTPCValue(_rtpcKey, _rtpcValue);
            _transitionStarted = false;
            return;
        }

        _currentValue += _step;
        Debug.Log(_currentValue);
        AkSoundEngine.SetRTPCValue(_rtpcKey, _currentValue);*/
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

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _duration = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    private float _elapsed = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    private bool _transitionStarted = false;

    /// <summary>
    /// 
    /// </summary>
    private float _currentValue = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    private float _step = 0.0f;

    #endregion
}
