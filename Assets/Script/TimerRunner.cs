using System;
using UnityEngine;

public class TimerRunner : MonoBehaviour
{
    public event Action Paused;
    public event Action Resumed;
    public event Action SecondPassed;

    private Timer _timer    = new Timer();
    private bool  _isPaused = true;
    private int   _nextFullSecond = 1;

    private void Update ()
    {
        if (_isPaused == false)
        {
            if (_timer.Time >= 10)
            {
                Pause();
            }

            _timer.Tick(Time.deltaTime);

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

    public float GetExactTime () => _timer.Time;

    public void LogExactTime ()
    {
        Debug.Log(GetExactTime());
    }
}
