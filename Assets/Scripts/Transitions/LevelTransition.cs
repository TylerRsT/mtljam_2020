using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransition : MonoBehaviour
{
    #region Const

    private const string OnTransitionMethodName = "OnTransition";

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    public void TriggerTransition()
    {
        gameObject.SendMessage(OnTransitionMethodName, _levelID);
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int levelID => _levelID;

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int _levelID = 0;

    #endregion
}
