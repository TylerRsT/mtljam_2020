using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionLightScale : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        _started = true;
        var light = _character.GetComponentInChildren<SpriteRenderer>();
        if (light == null)
        {
            _started = false;
            return;
        }

        var origin = light.transform.localScale.x;
        _step = origin * _duration / _scaleTo;
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed >= _duration)
        {
            SetScale(_scaleTo);
            _started = false;
            return;
        }

        var light = _character.GetComponentInChildren<SpriteRenderer>();
        if(light != null)
        {
            SetScale(light.transform.localScale.x + _step);
        }
    }

    private void SetScale(float scale)
    {
        var light = _character.GetComponentInChildren<SpriteRenderer>();
        if (light != null)
        {
            light.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    #endregion

    [SerializeField]
    private float _scaleTo = 1.0f;

    [SerializeField]
    private float _duration = 3.0f;

    [SerializeField]
    private Character _character = default;

    private float _elapsed = 0.0f;

    private bool _started = false;

    private float _step = 0.0f;
}
