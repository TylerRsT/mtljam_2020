using System.Collections;
using System.Collections.Generic;
using CreativeSpore.SuperTilemapEditor;
using UnityEngine;

public class BreakablePlatform : PlatformBase
{
    protected override void OnCharacterEnter(Character character)
    {
        Debug.Log("Breakableplatform");

        Sprite sprite = gameObject.GetComponent<Sprite>();

        var rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.simulated = false;

        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
    }
}
