using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject startButton;
    public GameObject backgroundImage;

    public GameObject canvas;
    public GameObject events;

    public TextMeshProUGUI menuText;
    public TextMeshProUGUI popcornText;

    private int popcornCount = -1;
    private int targetPopcorn = -2;

    // Start is called before the first frame update
    void Start()
    {
        menuText.text = "AstrocorN";
        popcornText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
