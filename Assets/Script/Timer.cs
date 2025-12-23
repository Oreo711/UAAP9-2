using System.Collections;
using UnityEngine;


public class Timer
{
	public float Time {get; private set;}

	public void Tick (float deltaTime)
	{
		Time += deltaTime;
	}
}
