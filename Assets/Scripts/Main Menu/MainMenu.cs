using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame()
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 2) == 0)
        {
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
    public void MainScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
