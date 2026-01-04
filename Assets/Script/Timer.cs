using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action Paused;
    public event Action Resumed;

    private bool _isPaused = true;
    public ReactiveVariable<float> CurrentTime {get; private set;} = new ReactiveVariable<float>(0);

    private void Update ()
    {
        if (_isPaused == false)
        {
            if (CurrentTime.Value >= 10)
            {
                Pause();
            }

            Tick(Time.deltaTime);
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

    private void Tick (float deltaTime)
    {
        CurrentTime.Value += deltaTime;
    }

    public void LogExactTime ()
    {
        Debug.Log(CurrentTime.Value);
    }
}
