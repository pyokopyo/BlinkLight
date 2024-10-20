using UnityEngine;

public class LightIntensityChanger : MonoBehaviour
{
    public Light pointLight; // 変更するポイントライト
    public Renderer targetRenderer; // 変更するマテリアルを持つレンダラー
    public float duration = 2.0f; // 変化にかかる時間（秒）
    public float minIntensity = 0.0f; // 最小強度
    public float maxIntensity = 1.0f; // 最大強度

    private float timer = 0.0f;
    private bool increasing = true;
    private Material targetMaterial;

    void Start()
    {
        if (targetRenderer != null)
        {
            targetMaterial = targetRenderer.material;
        }
    }

    void Update()
    {
        if (pointLight != null && targetMaterial != null)
        {
            timer += Time.deltaTime;
            float intensity = increasing ? Mathf.Lerp(minIntensity, maxIntensity, timer / duration) : Mathf.Lerp(maxIntensity, minIntensity, timer / duration);

            // ライトのintensityを変更
            pointLight.intensity = intensity;

            // マテリアルの透明度を変更
            Color color = targetMaterial.color;
            color.a = intensity; // アルファ値をintensityに設定
            targetMaterial.color = color;

            if (timer >= duration)
            {
                timer = 0.0f;
                increasing = !increasing;
            }
        }
    }
}
