using System.Collections;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] Canvas loadingCanvas;
    [SerializeField] GameObject[] resetObject;
 
    private void Start()
    {
        loadingCanvas.enabled = false;

        EventManager.Instance.PlayerTimeUpAsKingEvent += ShowLoadingCanvas;
    }

    private void OnDisable()
    {
        EventManager.Instance.PlayerTimeUpAsKingEvent -= ShowLoadingCanvas;
    }

    IEnumerator RestartAllGame()
    {
        yield return new WaitForSeconds(0.5f);
        loadingCanvas.enabled = true;
        yield return new WaitForSeconds(2f);
        foreach (GameObject obj in resetObject) 
        {
            obj.SetActive(true);
        }
        loadingCanvas.enabled = false;
    }

    private void ShowLoadingCanvas(object sender, System.EventArgs e)
    {
        StartCoroutine(RestartAllGame());
    }



}
