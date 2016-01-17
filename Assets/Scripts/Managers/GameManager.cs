using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float pipeSpawnRate;
	public float cloudSpawnRate;
	public float hillSpawnRate;
	public PoolManager pipePool;
	public PoolManager cloudPool;
	public PoolManager hillPool;
	public float panelFadeInRate;
	public Text scoreText;
	public Text highScoreText;
	public Text messageText;
	public Text subMessageText;
	public Text titleText;
	public Text subtitleText;
	public Image screenFill;
	public float restartDelay;
	public float firstRunPipeDelay = 3f;
	public float titleFadeDelay = 2f;
	public float titleFadeRate = 1f;
	public bool reset;
	
	private bool firstRun = true;
	private string highScoreKey = "HighScore";
	private string playCountKey = "PlayCount";
	private int playCount;
	private int currentScore;
	private int highScore;
	private bool birdAlive;
	private float canRestartTime;


	void Start () {

		if (reset)
		{
			PlayerPrefs.DeleteKey (playCountKey);
			PlayerPrefs.DeleteKey (highScoreKey);
		}

		float pipeSpawnDelay = 0f;

		if (!PlayerPrefs.HasKey(playCountKey) || PlayerPrefs.GetInt(playCountKey) == 0)
		{
			titleText.color = new Color (1f, 1f, 1f, 1f);
			subtitleText.color = new Color (1f, 1f, 1f, 1f);

			pipeSpawnDelay = firstRunPipeDelay;

			PlayerPrefs.SetInt(playCountKey, 0);
		}

		InvokeRepeating ("SpawnPipeFromPool", pipeSpawnDelay, pipeSpawnRate);
		InvokeRepeating ("SpawnCloudFromPool", cloudSpawnRate/2, cloudSpawnRate);
		InvokeRepeating ("SpawnHillFromPool", hillSpawnRate/2, hillSpawnRate);
		
		currentScore = 0;
		highScore = PlayerPrefs.GetInt(highScoreKey, 0);

		playCount = PlayerPrefs.GetInt(playCountKey);

		birdAlive = true;
	}

	void Update () {
		if (firstRun && Time.timeSinceLevelLoad > titleFadeDelay && titleText.color.a > 0f)
		{
			Color newColor = titleText.color;
			newColor.a -= titleFadeRate * Time.deltaTime;
			titleText.color = newColor;
			subtitleText.color = newColor;
		}

		if (!birdAlive)
		{
			if (screenFill.color.a < 0.5f)
			{
				Color newColor = screenFill.color;
				newColor.a += panelFadeInRate * Time.deltaTime;
				screenFill.color = newColor;
			}

			if (Input.anyKeyDown && Time.time > canRestartTime)
			{
				SceneManager.LoadScene (0);
			}
		}
	}

	void SpawnPipeFromPool () {
		
		GameObject obj = pipePool.GetPooledObject ();

		if (obj != null)
		{
			obj.SetActive (true);
		}
	}

	void SpawnCloudFromPool () {

		GameObject obj = cloudPool.GetPooledObject ();

		if (obj != null)
		{
			obj.SetActive (true);
		}
	}

	void SpawnHillFromPool () {
		GameObject obj = hillPool.GetPooledObject ();

		if (obj != null)
		{
			obj.SetActive (true);
		}
	}

	public void IncreaseScore () {
		currentScore += 1;
		scoreText.text = currentScore.ToString ();
	}

	public void StopSpawning() {
//		CancelInvoke ("SpawnPipeFromPool");
//		CancelInvoke ("SpawnCloudFromPool");
//		CancelInvoke ("SpawnHillFromPool");

		playCount++;
		PlayerPrefs.SetInt(playCountKey, playCount);

		birdAlive = false;

		messageText.enabled = true;
		subMessageText.enabled = true;

		titleText.enabled = false;
		subtitleText.enabled = false;

		scoreText.fontSize = 50;
		scoreText.text = "Final Score: " + currentScore.ToString ();

		CheckHighScore ();

		canRestartTime = Time.time + restartDelay;
	}

	public void CheckHighScore() {
		if (currentScore > highScore)
		{
			highScore = currentScore;

			PlayerPrefs.SetInt (highScoreKey, highScore);
			PlayerPrefs.Save ();

			highScoreText.color = new Color (0.027f, 0.647f, 0.208f);
			highScoreText.text = "New High Score: " + highScore.ToString ();
		} 
		else
		{
			highScoreText.color = new Color (0.8f, 0.8f, 0.8f);
			highScoreText.text = "High Score: " + highScore.ToString ();
		}
	}
}
