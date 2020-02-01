using CreativeSpore.SuperTilemapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionRigidBody : MonoBehaviour
{
    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        Debug.Assert(_rigidBody != null, "Rigid body not set.");
        StartCoroutine(ApplyRigidBodyChanges());
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ApplyRigidBodyChanges()
    {
        yield return new WaitForSeconds(0.2f);

        _rigidBody.simulated = true;

        var tilemapGroup = _rigidBody.GetComponent<TilemapGroup>();
        if (tilemapGroup != null)
        {
            tilemapGroup.enabled = true;
        }
    }

    #endregion

    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Rigidbody2D _rigidBody = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _colorAlpha = 1.0f;

    #endregion
}
