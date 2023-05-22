using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public static bool isGameOver = false;

    [SerializeField] GameObject GameOverText;
    [SerializeField] Text buttonText; 
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(isGameOver);
        if (isGameOver) buttonText.text = "Recomeçar";
    }

    public void GoToSceneGame()
    {
        SceneManager.LoadScene("sceGame");
    }
}
