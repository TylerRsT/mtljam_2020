using System.Collections;
using System.Collections.Generic;
using CreativeSpore.SuperTilemapEditor;
using UnityEngine;

public class BreakablePlatform : PlatformBase
{
    [SerializeField]
    private float DisappearSpeed = 0.10f;

    [SerializeField]
    private float DelayBeforeBreak = 0.8f;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator delayedEvent()
    {
        yield return new WaitForSeconds(DelayBeforeBreak);

        var spriteRenderer = GetComponent<SpriteRenderer>();
        float elapsedTime = 0.0f;
        float startingA = spriteRenderer.color.a;
        while (elapsedTime <= DisappearSpeed)
        {
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(startingA, 0.0f, elapsedTime / DisappearSpeed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1.0f / 60.0f);
        }
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        var rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.simulated = false;

        yield break;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    protected override void OnCharacterEnter(Character character)
    {
        StartCoroutine(delayedEvent());
    }
}
