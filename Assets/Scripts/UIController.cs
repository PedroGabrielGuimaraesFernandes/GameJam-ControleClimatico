using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI healthText;

    public GameObject pauseObj;
    public GameObject gameOverObj;

    public Animator sunnyAnim;
    public Animator rainyAnim;

    public static UIController instance;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;    
    }

    public void WriteLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }
}
