using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class pickUpFlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashLight;
    [SerializeField] GameObject campFire;
    [SerializeField] GameObject phone;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] TextMeshProUGUI warningTextMeshPro;
    [SerializeField] flashLightScript playerScript;
    [SerializeField] gameManagerScript gameManagerScript;
    [SerializeField] fireScript fireScript;
    [SerializeField] GameObject callingUI;
    [SerializeField] TextMeshProUGUI callingTextUI;
    [SerializeField] AudioSource callingAudioSource;

    [SerializeField] MonsterScript monsterScript;

    bool canUsePhone = false;
    bool used = false;
    private void Start()
    {
        fireScript = GameObject.Find("Fire").GetComponent<fireScript>();
    }
    void Update()
    {
        if (monsterScript.currentState == MonsterScript.State.Chase)
        {
            canUsePhone = true;
        }
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
                        fireScript.timeBeforeDisappearing += 20;
                    }
                }
                else if (hit.collider.gameObject == phone)
                {
                    if (canUsePhone && !used)
                    {
                        StartCoroutine(ICalling());
                        used = true;
                    }
                    else
                    {
                        StartCoroutine(IAlreadyCalled());
                    }
                }
            }
        }
    }
    IEnumerator ICalling()
    {
        callingUI.SetActive(true);
        callingTextUI.text = "Calling For Help....";
        callingAudioSource.Play();
        yield return new WaitForSeconds(callingAudioSource.clip.length);
        callingUI.SetActive(false);
    }
    IEnumerator IAlreadyCalled()
    {
        callingUI.SetActive(true);
        callingTextUI.text = "Theres Nothing wrong...";
        yield return new WaitForSeconds(2);
        callingUI.SetActive(false);
    }
}
