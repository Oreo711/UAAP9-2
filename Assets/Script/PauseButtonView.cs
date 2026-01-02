using System;
using UnityEngine;
using UnityEngine.UI;


public class PauseButtonView : MonoBehaviour
{
	[SerializeField] private Timer  _timer;
	[SerializeField] private Button _pauseButton;
	[SerializeField] private Button _resumeButton;

	private void Start ()
	{
		_timer.Paused  += HandlePaused;
		_timer.Resumed += HandleResumed;
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

	private void OnDestroy ()
	{
		_timer.Paused  -= HandlePaused;
		_timer.Resumed -= HandleResumed;
	}
}
