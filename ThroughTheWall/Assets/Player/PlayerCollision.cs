using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
	Animator anim;
	public PlayerMovement movement;
	public AudioSource hitsound;
	public Timer trackTimer;

	void Start()
	{
		anim = GetComponent<Animator>();
		hitsound = GetComponent<AudioSource>();
	}
	void Update()
	{
		IsDead();
	}
	int[] GetCurrentScores()
	{
		int[] currentScores = new int[5];

		for (int i = 0; i < currentScores.Length; i++)
		{
			currentScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
		}

		return currentScores;
	}

	void setCurrentScores(int[] newScores)
	{
		for (int i = 0; i < newScores.Length; i++)
		{
			PlayerPrefs.SetInt("HighScore" + i, newScores[i]);
			Debug.Log("Current Score index: " + i + ", value: " + newScores[i]);
			Debug.Log("Current Score index: " + i + ", value: " + PlayerPrefs.GetInt("HighScore" + i));
		}
	}

	void SortHighScore(int value)
	{
		int newHighScore = value;

		int[] highScoreValues = new int[5];
		highScoreValues = GetCurrentScores();

		// sort scores
		for (int i = 0; i < highScoreValues.Length; i++)
		{
			if (newHighScore > highScoreValues[i])
			{
				for (int j = highScoreValues.Length - 1; j > i; j--)
				{
					highScoreValues[j] = highScoreValues[j - 1];
				}

				highScoreValues[i] = newHighScore;
				newHighScore = -1;
			}
		}

		// save the sorted array
		setCurrentScores(highScoreValues);
	}
	IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			Debug.Log("test");
			anim.SetInteger("condition", 3);
			movement.enabled = false;
			yield return new WaitForSeconds(2);
			movement.enabled = true;
		}
	}
	//back to main menu
	void IsDead()
	{ 
        if (this.transform.position.y < -6)
        {
				string finalScore = trackTimer.scoreText.text;
				Debug.Log("final score as string: " + finalScore);
				finalScore = finalScore.Substring(7);
				Debug.Log("final score as string: " + finalScore);
				int endScore = int.Parse(finalScore);
				Debug.Log("final score as int" + endScore);
				SortHighScore(endScore);
				SceneManager.LoadScene(3);
				Time.timeScale = 1;
		}
	}

	void OnHitSound()
	{
		GameObject[] wallObjects = GameObject.FindGameObjectsWithTag("Wall");
		if (wallObjects.Length != 0)
		{
			foreach (GameObject wallObject in wallObjects)
			{
				Debug.Log("wallObject");
				float dist = Vector3.Distance(wallObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
				if (dist <= 10 && dist >= -10)
				{
					hitsound.Play();
					Debug.Log("wall sound");
				}
			}
		}
	}
}
