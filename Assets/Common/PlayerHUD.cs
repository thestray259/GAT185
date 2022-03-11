using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text levelUI;
    [SerializeField] TMP_Text cheeseAmountUI;
    [SerializeField] TMP_Text timeUI;
    [SerializeField] Slider healthUI;
	[SerializeField] GameData gameData;

	public int score { set { if (scoreUI == null) return; scoreUI.text = value.ToString("D6"); } }
	public int lives { set { if (livesUI == null) return; livesUI.text = value.ToString(); } }
	public int level { set { if (levelUI == null) return; levelUI.text = value.ToString(); } }
	public int cheeseAmount { set { if (cheeseAmountUI == null) return; cheeseAmountUI.text = value.ToString(); } }
	public float time { set { if (timeUI == null) return; timeUI.text = "<mspace=mspace=36>" + value.ToString("0.0") + "</mspace>"; } }
	public float health { set { if (healthUI == null) return; healthUI.value = value; } }

	private void Update()
	{
		float healthValue = 0;
		gameData.Load("Health", ref healthValue);
		health = healthValue;

		int scoreValue = 0;
		gameData.Load("Score", ref scoreValue);
		score = scoreValue;

		int livesValue = 0;
		gameData.Load("Lives", ref livesValue);
		lives = livesValue;

		int levelValue = 0;
		gameData.Load("Level", ref levelValue);
		level = levelValue;

		int cheeseValue = 0;
		gameData.Load("CheeseLeft", ref cheeseValue);
		cheeseAmount = cheeseValue;
	}
}
