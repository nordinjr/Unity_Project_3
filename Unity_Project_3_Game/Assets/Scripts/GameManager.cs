using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject dialogBox;
    public GameObject dialogText;
    public float typeSpeed = .05f;
    private Coroutine dialogCO;

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

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncPopcornCount()
    {
        popcornCount++;
        popcornText.text = "Popcorn: " + popcornCount + "/" + targetPopcorn;
        if (popcornCount == targetPopcorn) Debug.Log("Yay!");
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        menuText.text = "";
        StartCoroutine(LoadYourAsyncScene("Main_Scene"));
        popcornCount = 0;
        targetPopcorn = 5;
        popcornText.text = "Popcorn: " + popcornCount + "/" + targetPopcorn;

    }

    IEnumerator ColorLerp(Color endvalue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endvalue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endvalue;
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 2));
    }

    public void StartDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogCO = StartCoroutine(TypeText(text));
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCO);
    }

    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
