using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilhoCod : MonoBehaviour {

	[SerializeField]
	private Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerExit(Collider col)
	{

		if (col.gameObject.CompareTag ("bolinha"))
		{
			rb.useGravity = true;
			Destroy (gameObject, 0.35f);
			criaplataforma.chaoNumCena--;
		}
	}
}
