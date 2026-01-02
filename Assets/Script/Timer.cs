using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action Paused;
    public event Action Resumed;
    public event Action SecondPassed;

    private bool  _isPaused       = true;
    private int   _nextFullSecond = 1;
    private  float CurrentTime {get; set;}

    private void Update ()
    {
        if (_isPaused == false)
        {
            if (CurrentTime >= 10)
            {
                Pause();
            }

            Tick(Time.deltaTime);

            if (GetExactTime() >= _nextFullSecond)
            {
                _nextFullSecond++;
                SecondPassed?.Invoke();
            }
        }
    }

    public void Pause ()
    {
        _isPaused = true;
        Paused?.Invoke();
    }

    public void Resume ()
    {
        _isPaused = false;
        Resumed?.Invoke();
    }

    public float GetExactTime () => CurrentTime;

    private void Tick (float deltaTime)
    {
        CurrentTime += deltaTime;
    }

    public void LogExactTime ()
    {
        Debug.Log(GetExactTime());
    }
}
