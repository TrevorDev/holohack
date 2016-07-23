using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

    // Use this for initialization
    public void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		var hardControls = true;
		if (hardControls) {
			//spin propeller based on left stick
			this.GetComponent<Rigidbody> ().velocity += this.transform.up * (Input.GetAxis ("LeftVertical") * 0.5f);

			//rotate vehicle based on right stick
			this.transform.Rotate (new Vector3 (Input.GetAxis ("RightVertical") * 5f, 0, 0));
			this.transform.Rotate (new Vector3 (0, 1, 0), Input.GetAxis ("RightHorizontal") * 5f, Space.World);
		} else {
			this.GetComponent<Rigidbody> ().useGravity = false;

			this.GetComponent<Rigidbody>().position += this.transform.up * (Input.GetAxis("RightVertical") * 0.05f);
			this.GetComponent<Rigidbody>().position += this.transform.forward * (Input.GetAxis("LeftVertical") * 0.2f);
			this.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("RightHorizontal") * 5f, Space.World);
		}

		if (Input.GetButtonDown ("Fire2")) {
			var ball = (BouncyBall)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BouncyBall.prefab", typeof(BouncyBall)));
			ball.transform.position = this.GetComponent<Rigidbody> ().position + (this.transform.forward * 3);
			ball.GetComponent<Rigidbody> ().velocity = this.transform.forward * 20;
		}

        //Previus attempt at rotation (These controls are too hard)
        //this.GetComponent<Rigidbody>().angularVelocity += new Vector3(0, Input.GetAxis("RightHorizontal")*0.2f, 0);
        //this.GetComponent<Rigidbody>().angularVelocity += new Vector3(Input.GetAxis("RightVertical") * 0.2f, 0, 0);
    }

    public void TakeHit()
    {
        //this.transform.Translate(0, 0, 10f);
    }
}
