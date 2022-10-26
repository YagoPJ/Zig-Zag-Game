using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausegame : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	public void Pausa()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pausePanel.SetActive (true);
		}
		else
		{
			pausePanel.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
