using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    RenderTexture _renderTexture = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    Shader _shader = default;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float _mapOpacity = 0.1f;

    private Material _material;
    
    private void Start()
    {
        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        _material.SetTexture("_LightsTex", _renderTexture);
        _material.SetFloat("_MapOpacity", _mapOpacity);
        Graphics.Blit(src, dst, _material);   
    }
}
