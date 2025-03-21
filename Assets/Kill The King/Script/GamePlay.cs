using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] Image slider;
    [SerializeField] float totalTimeToKill;

    private float currenttime = 0;
    private bool istryToKill;

    private void Start()
    {
         ResetKillProgress();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            istryToKill = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (istryToKill)
            {
                UpdateKillProgress();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetKillProgress();
        }
    }

    private void UpdateKillProgress()
    {
        if (currenttime < totalTimeToKill) 
        {
            float currentAmount = currenttime / totalTimeToKill;
            slider.fillAmount = currentAmount;
            currenttime += Time.deltaTime;
        }

        
    }

    private void ResetKillProgress()
    {
        istryToKill=false;
        currenttime = 0;
        slider.fillAmount = 0;

    }
}
