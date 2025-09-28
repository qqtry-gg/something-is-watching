using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] Image loseUi;
    [SerializeField] GameObject loseTitle;
    [SerializeField] GameObject loseButton;
    [SerializeField] float fadeDuration = 2f;
    [SerializeField] GameObject GameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeIn()
    {
        StartCoroutine(Fade(1));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void FadeOut()
    {
        StartCoroutine(Fade(0));
    }
    IEnumerator Fade(float TargetAlpha)
    {
        float startAlpha = loseUi.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, TargetAlpha, time / fadeDuration);
            loseUi.color = new Color(0,0,0, alpha);
            yield return null;
        }
        loseTitle.SetActive(true);
        loseButton.SetActive(true);
        GameUI.SetActive(false);
    }
}
