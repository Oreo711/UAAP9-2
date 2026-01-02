using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class TimerView : MonoBehaviour
{
	[SerializeField] private Timer _timer;
	[SerializeField] private Slider _slider;

	private void Update ()
	{
		_slider.value = _timer.GetExactTime();
	}
}
