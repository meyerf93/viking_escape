using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {

	[SerializeField]
	private int minLowPass = 1000;
	[SerializeField]
	private int maxLowPass = 22000;

	AudioLowPassFilter lowPassFilter;

	void Start() {
		lowPassFilter = GetComponent<AudioLowPassFilter>();
	}

	public void ActivateLowPassFilter(bool shouldActivate) {
		lowPassFilter.cutoffFrequency = shouldActivate ? minLowPass : maxLowPass;
	}
}
