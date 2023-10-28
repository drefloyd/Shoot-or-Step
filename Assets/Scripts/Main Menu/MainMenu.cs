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

        int mapChoice = rnd.Next(3);

        if (mapChoice == 0)
        {
            SceneManager.LoadSceneAsync(1);
        }
        else if(mapChoice == 1)
        {
            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
    public void MainScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
