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
        Debug.Log("Kiedy� dodam Settings");
    }
    public void Credits()
    {
        Debug.Log("Kiedy� dodam Credits");
    }
}
