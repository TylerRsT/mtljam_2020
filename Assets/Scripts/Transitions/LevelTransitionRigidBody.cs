using CreativeSpore.SuperTilemapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelTransitionRigidBody : MonoBehaviour
{
    #region Nested

    /// <summary>
    /// 
    /// </summary>
    private enum LevelTransitionRigidBodyState
    {
        Waiting,

        Executing,

        Done,
    }

    #endregion

    #region Messages

    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelID"></param>
    private void OnTransition(int levelID)
    {
        Debug.Assert(_rigidBody != null, "Rigid body not set.");
        Debug.Assert(_character != null, "Character not set.");

        _character.AddForce(new Vector2(0.0f, _impulseForce));
        _state = LevelTransitionRigidBodyState.Executing;
    }

    private void Update()
    {
        if(_state != LevelTransitionRigidBodyState.Executing)
        {
            return;
        }

        if(_character.transform.position.y > _rigidBody.transform.position.y + (_rigidBody.GetComponent<BoxCollider2D>().size.y / 2.0f))
        {
            _state = LevelTransitionRigidBodyState.Done;
            _rigidBody.simulated = true;

            var renderer = _rigidBody.GetComponent<SpriteRenderer>();
            if(renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }

    #endregion

    #region Methods

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
    private Rigidbody2D _character = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _impulseForce = 40.0f;

    private LevelTransitionRigidBodyState _state = LevelTransitionRigidBodyState.Waiting;

    #endregion
}
