using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BrandSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSplashScene());
    }

   
    IEnumerator LoadSplashScene()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("SplashScene"); 
    }
}
