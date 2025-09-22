using UnityEngine;

public class flashLightScript : MonoBehaviour
{
    [SerializeField] GameObject flashlight;

    [SerializeField] AudioSource flashlightOn;

    bool on;
    bool off;

    public bool canUseFlashLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       off = true;
       flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canUseFlashLight && off && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(true);
            flashlightOn.Play();
            off = false;
            on = true;
        }
        else if (canUseFlashLight && on && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(false);
            flashlightOn.Play();
            off = true;
            on = false;
        }
    }
}
