using UnityEngine;

public class fireScript : MonoBehaviour
{
    public float timeBeforeDisappearing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDisappearing -= Time.deltaTime;

        if (timeBeforeDisappearing <= 0)
        {
            Destroy(gameObject);
        }
    }
}
