using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardcount;
	public float startwait;
	public float spawnwait;
	private int wavewait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	void Start(){

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update (){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
		IEnumerator SpawnWaves(){
		int wavewait = 3;
		while (true) {
			yield return new WaitForSeconds (startwait);
			for (int i = 0; i < hazardcount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnwait);

			}
			yield return new WaitForSeconds (wavewait);

			if (gameOver){
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	public void Addscore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		gameOverText.text = "Git Gud";
		gameOver = true;

	}
}