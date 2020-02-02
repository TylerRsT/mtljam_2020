using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionLight : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        StartCoroutine(Coroutine());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(_delay);

        var fogOfWar = _mainCamera.GetComponent<FogOfWar>();
        if (fogOfWar != null)
        {
            fogOfWar.enabled = _activeState;
        }

        yield break;
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Camera _mainCamera = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool _activeState = false;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _delay = 2.0f;

    #endregion
}
