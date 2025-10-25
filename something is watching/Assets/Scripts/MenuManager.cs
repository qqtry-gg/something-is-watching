using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
    public void Credits()
    {
        Debug.Log("Kiedyœ dodam Credits");
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
