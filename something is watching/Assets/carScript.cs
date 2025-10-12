using UnityEngine;

public class carScript : MonoBehaviour
{
    FadeScript GuiScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GuiScript = GameObject.Find("GameManager").GetComponent<FadeScript>();
            GuiScript.FadeIn();
            GuiScript.losetext.text = "You Managed to escape from the monster!";
        }
    }
}
