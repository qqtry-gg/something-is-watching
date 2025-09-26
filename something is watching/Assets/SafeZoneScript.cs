using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<MonsterScript>().SetSafeZone(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<MonsterScript>().SetSafeZone(false);
        }
    }
    private void OnDestroy()
    {
        FindFirstObjectByType<MonsterScript>().SetSafeZone(false);
    }
}
