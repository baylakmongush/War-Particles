using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Contol move, direction and count class
/// </summary>
public class ParticleController : MonoBehaviour
{
	float						speed;
	Vector3						mousePosition;
	Text						score;
	static public int			count;
	public GameObject			DestructionEffect;
	void Start()
	{
		speed = 0.08f;
		score = GameObject.FindWithTag("Score").GetComponent<Text>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Rectangle"))
		{
			count += 1;
			score.text = "Score: " + count;																// output score count
			GameObject destroyEffect = Instantiate(DestructionEffect, transform.position, Quaternion.identity); // create destroy effect
			GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>().Play();
			Destroy(destroyEffect, 1);
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		mousePosition = MousePosition();		// mouse position coords
		MovingSpeed();						// find speed and move to cursor
	}

	/// <summary>
	/// find mouse position
	/// </summary>
	/// <returns></returns>
	private Vector2 MousePosition()
	{
		float distance;
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		distance = Vector3.Distance(mousePosition, transform.position);
		if (distance < 10.001)              // distance between cursor and particle
		{
			GameObject music = GameObject.FindGameObjectWithTag("Music").gameObject;
			if (music)
				Destroy(music);
			SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
		}
		return (mousePosition);
	}

	/// <summary>
	/// move to cursor: change coords method
	/// </summary>
	private void MovingSpeed()
	{
		transform.position = Vector3.MoveTowards(transform.position, mousePosition, (speed * Time.deltaTime) / transform.localScale.x);
	}
}
