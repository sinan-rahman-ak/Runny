using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Settings()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void BackHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
