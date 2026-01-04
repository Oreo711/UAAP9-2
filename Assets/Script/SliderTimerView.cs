using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class TimerView : MonoBehaviour
{
	[SerializeField] private Timer _timer;
	[SerializeField] private Slider _slider;

	private void Start ()
	{
		_timer.CurrentTime.Changed += HandleTimeChanged;
	}

	private void HandleTimeChanged (float previousTime, float newTime)
	{
		_slider.value = newTime;
	}

	private void OnDestroy ()
	{
		_timer.CurrentTime.Changed += HandleTimeChanged;
	}
}
