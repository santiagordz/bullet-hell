using TMPro;
using UnityEngine;

public class SlowModeDisplay : MonoBehaviour
{
    public TextMeshProUGUI slowTextMesh;
    private SlowModeManager slowModeManager;

    void Start()
    {
        slowModeManager = FindObjectOfType<SlowModeManager>();
    }

    void Update()
    {
        if (slowTextMesh != null)
        {
            try
            {
                slowTextMesh.text = "Slow Mode: \n" + (slowModeManager.isSlowModeActive ? "ON" : "OFF");
            }
            catch
            {
                slowTextMesh.text = "Slow Mode: NOT AVAILABLE";
            }
        }
    }
}