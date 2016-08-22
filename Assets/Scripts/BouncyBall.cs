using UnityEngine;
using System.Collections;

public class BouncyBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.transform.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
