using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowModeVisuals : MonoBehaviour
{
    public PostProcessProfile profile;
    private ColorGrading colorGrading;
    private Grain grain;
    private MotionBlur motionBlur;

    void Start()
    {
        profile.TryGetSettings(out colorGrading);
        profile.TryGetSettings(out grain);
        profile.TryGetSettings(out motionBlur);

        colorGrading.enabled.value = false;
        grain.enabled.value = false;
        motionBlur.enabled.value = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Example: Toggle on V key press
        {
            colorGrading.enabled.value = !colorGrading.enabled.value;
            grain.enabled.value = !grain.enabled.value;
            motionBlur.enabled.value = !motionBlur.enabled.value;
        }
    }
}
