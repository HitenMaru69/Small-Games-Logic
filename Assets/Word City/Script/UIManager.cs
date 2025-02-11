using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public TextMeshProUGUI wordText;

    public string word = "RAW";


    public event EventHandler GameOverEvent;


    [SerializeField] Canvas gameOverCanvas;

    private void Awake()
    {
        Instance  = this;
    }

    private void Start()
    {
        wordText.text = "";
        gameOverCanvas.enabled = false;

        GameOverEvent += OnGameOver;
    }

    private void OnDisable()
    {
        GameOverEvent -= OnGameOver;
    }

    public void RetsartBu()
    {
        SceneManager.LoadScene(0);
    }


    public void GameOverEventInvoke()
    {
        GameOverEvent?.Invoke(this, EventArgs.Empty);
    }



    private void OnGameOver(object sender, EventArgs e)
    {
        gameOverCanvas.enabled = true;
    }
}
