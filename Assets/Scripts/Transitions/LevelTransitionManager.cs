using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionManager : MonoBehaviour
{
    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="oldLevelID"></param>
    /// <param name="newLevelID"></param>
    public void HandleLevelTransition(int newLevelID, int oldLevelID)
    {
        var levelTransitions = GameObject.FindObjectsOfType<LevelTransition>();
        var newLevelTransition = levelTransitions.FirstOrDefault(x => x.levelID == newLevelID);

        newLevelTransition?.TriggerTransition();
    }

    #endregion
}
