using System;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryBoard : MonoBehaviour
{
    public GameObject StoryboardU1;

    public void Start()
    {
       StoryboardU1.SetActive(true);       
    }
    
}
