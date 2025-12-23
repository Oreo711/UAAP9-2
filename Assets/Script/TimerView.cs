using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class TimerView : MonoBehaviour
{
	[SerializeField] private TimerRunner _timer;
	[SerializeField] private Slider _slider;
	[SerializeField] private Button _pauseButton;
	[SerializeField] private Button _resumeButton;
	[SerializeField] private List<Image> _hearts;

	private void Start ()
	{
		_timer.Paused += HandlePaused;
		_timer.Resumed += HandleResumed;
		_timer.SecondPassed += HandleSecondPassed;
	}

	private void Update ()
	{
		_slider.value = _timer.GetExactTime();
	}

	private void HandlePaused ()
	{
		_pauseButton.gameObject.SetActive(false);
		_resumeButton.gameObject.SetActive(true);
	}

	private void HandleResumed ()
	{
		_pauseButton.gameObject.SetActive(true);
		_resumeButton.gameObject.SetActive(false);
	}

	private void HandleSecondPassed ()
	{
		Image heartForDestroy = _hearts.Last();
		heartForDestroy.gameObject.SetActive(false);
		_hearts.Remove(heartForDestroy);
	}

	private void OnDestroy ()
	{
		_timer.Paused -= HandlePaused;
		_timer.Resumed -= HandleResumed;
		_timer.SecondPassed -= HandleSecondPassed;
	}
}
