using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endingbuttons : MonoBehaviour
{
    public Button retry;
    public Button exit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        retry.onClick.AddListener(Retry);
        exit.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Retry()
    {
       SceneManager.LoadScene("Cave");
    }

    void Exit()
    {
        Application.Quit();
    }
}
