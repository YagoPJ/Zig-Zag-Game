using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mover : MonoBehaviour {

	[SerializeField]
	private float vel = 0.2f, limiteVel = 2.1f;
	[SerializeField]
	private Rigidbody rb;
	public static bool gameOver = false;
	[SerializeField]
	private int moedasScore = 0;
	[SerializeField]
	private int moedasMax = 0;
	[SerializeField]
	private float velAdd = 0.05f;
	[SerializeField]
	private Text txtMoedas;
	[SerializeField]
	private GameObject particulas;
	public GameObject gameOverPanel;
	public int moedasRank = 0;

	private pausegame pauseGame;

	void Start () {

		gameOverPanel.SetActive (false);

		txtMoedas.text = moedasScore.ToString ();

		moedasRank = PlayerPrefs.GetInt ("MoedasRank", moedasRank);

		rb = GetComponent<Rigidbody> ();

		rb.velocity = new Vector3 (vel, 0, 0);

		StartCoroutine (AjustaVel ());

		pauseGame = FindObjectOfType<pausegame> ();

		
	}

	void Update () {

	if(Input.GetKeyDown(KeyCode.Escape))
		{				
			pauseGame.Pausa();
		}

		if(Input.GetKeyDown(KeyCode.Space) && !gameOver)
		{
			MovimentoBola();
		}

		if (!Physics.Raycast (transform.position, Vector3.down, 1))
		{
			gameOver = true;
			rb.useGravity = true;
			gameOverPanel.SetActive (true);
		}

		if (gameOver)
		{
			if (moedasScore > moedasRank)
			{
				moedasRank = moedasScore;
				PlayerPrefs.SetInt ("MoedasRank", moedasRank);
			}
		}

			
				
				

	}

	void Awake()
	{
		SceneManager.sceneLoaded += Carrega;
	}

	void Carrega(Scene cena, LoadSceneMode modo)
	{
		gameOver = false;
	}


	void AdicionandoRank()
	{
		
	}

	void RankMoeda()
	{
		moedasRank = moedasMax;
	}

 	void MovimentoBola()
	{
		if (rb.velocity.x > 0) 
		{
			rb.velocity = new Vector3 (0, 0, vel);
		} 
		else if (rb.velocity.z > 0) 	
		{
			rb.velocity = new Vector3 (vel,0,0);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("moeda"))
		{
			Destroy (col.gameObject);
			moedasScore++;
			txtMoedas.text = moedasScore.ToString ();
			Instantiate (particulas,transform.position,Quaternion.identity);
		}
	}

	IEnumerator AjustaVel()
	{
		while (!gameOver)
		{
			yield return new WaitForSeconds (2);
			if (vel <= limiteVel)
			{
				vel += velAdd;
			}
		}
	}

	public void Novamente()
	{
		SceneManager.LoadScene (1);
	}


}
