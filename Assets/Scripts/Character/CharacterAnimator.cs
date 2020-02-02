using Elendow.SpritedowAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(SpriteAnimator))]
public class CharacterAnimator : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public SpriteAnimation idleAnimation = default;

    [SerializeField]
    public SpriteAnimation movingAnimation = default;

    [SerializeField]
    public SpriteAnimation jumpStartAnimation = default;

    [SerializeField]
    public SpriteAnimation jumpLoopAnimation = default;

    [SerializeField]
    public SpriteAnimation fallLoopAnimation = default;

    [SerializeField]
    public SpriteAnimation landAnimation = default;

    #endregion
}
