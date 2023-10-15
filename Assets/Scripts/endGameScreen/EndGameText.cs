using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndGameText : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    // Start is called before the first frame update
    void Start()
    {
        winnerText.text = Health.winnerString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
