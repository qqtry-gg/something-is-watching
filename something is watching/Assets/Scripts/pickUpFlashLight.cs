using TMPro;
using UnityEngine;
using UnityEngineInternal;

public class pickUpFlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashLight;
    [SerializeField] GameObject campFire;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] flashLightScript playerScript;
    [SerializeField] gameManagerScript gameManagerScript;
    [SerializeField] fireScript fireScript;
    private void Start()
    {
        fireScript = GameObject.Find("Fire").GetComponent<fireScript>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3f))
            {
                if (hit.collider.gameObject == flashLight)
                {
                    playerScript.canUseFlashLight = true;
                    Destroy(flashLight);
                }
                else if (hit.collider.CompareTag("FireWood"))
                {
                    Debug.Log("Hit: " + hit.collider.gameObject.name);
                    gameManagerScript.sticks += 1;
                    textMeshPro.text = "Sticks: "+gameManagerScript.sticks;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject == campFire)
                {
                    if (gameManagerScript.sticks > 0)
                    {
                        gameManagerScript.sticks -= 1;
                        textMeshPro.text = "Sticks: " + gameManagerScript.sticks;
                        fireScript.timeBeforeDisappearing += 10;
                    }
                }
            }
        }
    }
}
