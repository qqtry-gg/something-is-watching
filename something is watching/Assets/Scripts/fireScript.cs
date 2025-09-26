using TMPro;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    public float timeBeforeDisappearing;
    [SerializeField] TextMeshProUGUI warningTextMeshPro;
    [SerializeField] GameObject safeZoneToDestroy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDisappearing -= Time.deltaTime;
        if (timeBeforeDisappearing <= 20 && timeBeforeDisappearing > 0)
        {
            warningTextMeshPro.text = "campfire is running low on fuel!";
        }
        else if (timeBeforeDisappearing > 20)
        {
            warningTextMeshPro.text = "";
        }



        if (timeBeforeDisappearing <= 0)
        {
            warningTextMeshPro.text = "";
            Destroy(safeZoneToDestroy);
            Destroy(gameObject);
        }
        
    }
}
