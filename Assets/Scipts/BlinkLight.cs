using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light targetLight; // 点滅させるライト
    public float blinkInterval = 0.5f; // 点滅の間隔（秒）

    private bool isBlinking = false;

    void Start()
    {
        if (targetLight != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleLight", 0, blinkInterval);
        }
    }

    void ToggleLight()
    {
        if (targetLight != null && isBlinking)
        {
            targetLight.enabled = !targetLight.enabled;
        }
    }

    void OnDisable()
    {
        isBlinking = false;
    }
}
