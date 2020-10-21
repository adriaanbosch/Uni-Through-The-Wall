using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
	public class PlayerCollisionScriptToTest : MonoBehaviour
	{
		void Start()
		{

		}
		void Update()
		{
			IsDead();
		}
		void IsDead()
		{
			if (this.transform.position.y < -6f)
			{
                Destroy(this.gameObject);

				//back to main menu
				SceneManager.LoadScene(0);
				Time.timeScale = 1;
			}
		}
	}
}
