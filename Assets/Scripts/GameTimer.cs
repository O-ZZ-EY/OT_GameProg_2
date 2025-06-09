using UnityEngine;
using TMPro;


public class GameTimer : MonoBehaviour
{
    public TMP_Text Timer_Text;
    public float CurrentTimer;
    public float TimerInterval;

    private void Start()
    {
        CurrentTimer = TimerInterval;
    }

    private void Update()
    {
        CurrentTimer -= Time.deltaTime;  
        Timer_Text.text = "Timer: " + CurrentTimer.ToString(); 

        if (CurrentTimer <= 0f)
        {

            CurrentTimer = 0f;

        }

    }
}
