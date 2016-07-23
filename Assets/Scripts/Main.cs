using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    public Vehicle vehicle = null;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //spawn vehicle
            if(vehicle == null)
            {
                vehicle = (Vehicle)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Vehicle.prefab", typeof(Vehicle)));
            }

            //place vehicle and reset velocity/position
            var cam = GameObject.Find("Main Camera");
            var pos = cam.transform.position + (cam.transform.forward * 15);
            vehicle.transform.position = pos;
            vehicle.transform.rotation = new Quaternion();
            vehicle.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            vehicle.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            
        }
	}
}
