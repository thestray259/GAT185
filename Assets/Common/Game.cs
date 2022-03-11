using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class Game : Singleton<Game>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER,
		GAME_WIN
	}

	[SerializeField] ScreenFade screenFade;
	[SerializeField] SceneLoader sceneLoader;
	[SerializeField] GameObject gameOverScreen;

	public GameData gameData;

	float stateTimer = 3; 

	State state = State.TITLE;
	int highScore;

	private void Start()
	{
		highScore = PlayerPrefs.GetInt("highscore", 0);
		highScore++;
		PlayerPrefs.SetInt("highscore", highScore);

		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.DeleteKey("highscore");

		gameData.intData["CheeseLeft"] = 3; 
		gameData.intData["Level"] = 1; 
		gameData.intData["Lives"] = 1; 

		InitScene();
		SceneManager.activeSceneChanged += OnSceneWasLoaded; 
	}

	void InitScene()
    {
		SceneDescriptor sceneDescriptor = FindObjectOfType<SceneDescriptor>();
		if (sceneDescriptor != null)
        {
			Instantiate(sceneDescriptor.player, sceneDescriptor.playerSpawn.position, sceneDescriptor.playerSpawn.rotation);
        }
	}

	private void Update()
	{
		stateTimer -= Time.deltaTime;

		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				break;
			case State.GAME:
				break;
			case State.PLAYER_DEAD:
				break;
			case State.GAME_OVER:
				break;
			case State.GAME_WIN:
/*				if (stateTimer <= 0)
                {
					OnLoadScene("MainMenu");
				}*/
				break;
			default:
				break;
		}
	}

	public void OnLoadScene(string sceneName)
    {
		gameOverScreen.SetActive(false);
		sceneLoader.Load(sceneName); 
	}

	public void OnPlayerDead()
    {
		gameData.intData["Lives"]--; 

		if (gameData.intData["Lives"] == 0)
        {
			OnLoadScene("MainMenu"); 
        }
		else
        {
			OnLoadScene(SceneManager.GetActiveScene().name);
        }
    }

	public void OnCheeseFound()
	{
		gameData.intData["CheeseLeft"]--;

		if (gameData.intData["CheeseLeft"] == 0)
		{
			gameOverScreen.SetActive(true);
			stateTimer -= Time.deltaTime; 
			if (stateTimer >= 0)
            {
				OnLoadScene("MainMenu");
			}
		}
	}

	void OnSceneWasLoaded(Scene current, Scene next)
    {
		InitScene(); 
    }
}
