using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void Start()
    {
        audioManager.PlayMusic(audioManager.menuMusic);
    }
        // Start is called before the first frame update
        public void PlayGame()
    {
        System.Random rnd = new System.Random();

        int mapChoice = rnd.Next(3);

        Time.timeScale = 1f;

        if (mapChoice == 0)
        {
            SceneManager.LoadSceneAsync(1);
            audioManager.PlayMusic(audioManager.background);

        }
        else if(mapChoice == 1)
        {
            SceneManager.LoadSceneAsync(3);
            audioManager.PlayMusic(audioManager.background);

        }
        else
        {
            SceneManager.LoadSceneAsync(4);
            audioManager.PlayMusic(audioManager.background);
        }
    }
    public void MainScreen()
    {
        SceneManager.LoadSceneAsync(0);
        
    }
}
