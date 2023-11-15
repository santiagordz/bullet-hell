using UnityEngine;

public class SlowModeManager : MonoBehaviour
{
    public float slowDownFactor = 0.1f; // Factor to slow down the game
    public bool isSlowModeActive = false;
    // public SlowModeVisuals slowModeVisuals;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSlowMode();
        }
    }

    void ToggleSlowMode()
    {
        isSlowModeActive = !isSlowModeActive;

        // Apply slow mode
        Time.timeScale = isSlowModeActive ? slowDownFactor : 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
