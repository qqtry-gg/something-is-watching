using UnityEngine;

public class pickUpFlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashLight;
    [SerializeField] flashLightScript playerScript;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) 
            {
                if (hit.collider.gameObject == flashLight)
                {
                    playerScript.canUseFlashLight = true;
                    Destroy(flashLight);
                }
            }
        }
    }
}
