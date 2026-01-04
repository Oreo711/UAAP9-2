using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class HeartBar : MonoBehaviour
{
    [SerializeField] private Timer       _timer;
    [SerializeField] private List<Image> _hearts;

    private int _nextFullSecond = 1;

    private void Update ()
    {
        if (_timer.CurrentTime.Value >= _nextFullSecond)
        {
            _nextFullSecond++;
            DecreaseBar();
        }
    }

    private void DecreaseBar ()
    {
        Image heartForDestroy = _hearts.Last();
        heartForDestroy.gameObject.SetActive(false);
        _hearts.Remove(heartForDestroy);
    }
}
