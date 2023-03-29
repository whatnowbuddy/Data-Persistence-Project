using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Text bestScoreText;


    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.LoadInfo();

        string bestScoreName = DataManager.instance.bestScoreName == "" ? "Name" : DataManager.instance.bestScoreName;
        bestScoreText.text = "Best Score: " + bestScoreName + ": " + DataManager.instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetPlayerName()
    {
        DataManager.instance.playerName = playerNameInput.text;
    }

    public void StartGame()
    {
        if (playerNameInput.text != "")
        {
            GetPlayerName();
            SceneManager.LoadScene(1);
        }
    }

    public static void ExitGame()
    {

#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
