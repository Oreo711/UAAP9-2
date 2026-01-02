using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class HeartBar : MonoBehaviour
{
    [SerializeField] private Timer       _timer;
    [SerializeField] private List<Image> _hearts;

    private void Start ()
    {
        _timer.SecondPassed += HandleSecondPassed;
    }

    private void HandleSecondPassed ()
    {
        Image heartForDestroy = _hearts.Last();
        heartForDestroy.gameObject.SetActive(false);
        _hearts.Remove(heartForDestroy);
    }

    private void OnDestroy ()
    {
        _timer.SecondPassed -= HandleSecondPassed;
    }
}
