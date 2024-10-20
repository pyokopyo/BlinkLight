using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightIntensityBloomChanger : MonoBehaviour
{
    public Light pointLight; // 変更するポイントライト
    public PostProcessVolume postProcessVolume; // ポストプロセスボリューム
    public float duration = 2.0f; // 変化にかかる時間（秒）
    public float minIntensity = 0.0f; // 最小強度
    public float maxIntensity = 1.0f; // 最大強度

    private float timer = 0.0f;
    private bool increasing = true;
    private Bloom bloom;

    void Start()
    {
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGetSettings(out bloom);
        }
    }

    void Update()
    {
        if (pointLight != null && bloom != null)
        {
            timer += Time.deltaTime;
            if (increasing)
            {
                float intensity = Mathf.Lerp(minIntensity, maxIntensity, timer / duration);
                pointLight.intensity = intensity;
                bloom.intensity.value = intensity;
                if (timer >= duration)
                {
                    timer = 0.0f;
                    increasing = false;
                }
            }
            else
            {
                float intensity = Mathf.Lerp(maxIntensity, minIntensity, timer / duration);
                pointLight.intensity = intensity;
                bloom.intensity.value = intensity;
                if (timer >= duration)
                {
                    timer = 0.0f;
                    increasing = true;
                }
            }
        }
    }
}
