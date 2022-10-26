using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morteParticulas : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Destroy (gameObject, 2); //destruindo a particula pra nao fica acumulando
		
	}

}
