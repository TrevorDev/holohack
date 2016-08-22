using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;

public class Main : MonoBehaviour
{
    public GameObject helicopterObject;
    public GameObject bouncyBallObject;
    public GameObject buildingBlockObject;
    public Material alt;

    GestureRecognizer gesture;

    bool tapped = false;

    Helicopter helicopter = null;

    int pos = 0;
    ArrayList blocks = new ArrayList(5);
    
    //BouncyBall ball = null;
    // Use this for initialization
    void Start()
    {
        gesture = new GestureRecognizer();
        gesture.StartCapturingGestures();
        gesture.TappedEvent += (a, b, c) =>
        {
            tapped = true;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            if (helicopter == null)
            {
                helicopter = Instantiate(helicopterObject).GetComponent<Helicopter>();
                //helicopter = (Helicopter)Resources.Load("Assets/Prefabs/Helicopter.prefab");
                //helicopter = (Helicopter)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Helicopter.prefab", typeof(Helicopter)));
            }

            //place vehicle and reset velocity/position
            var cam = GameObject.Find("Main Camera");
            var pos = cam.transform.position + (cam.transform.forward * 2);
            helicopter.transform.position = pos;
            helicopter.transform.rotation = new Quaternion();
            helicopter.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            helicopter.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        // Shoot balls
        if (Input.GetKeyDown("m"))
        {
            BouncyBall ball = Instantiate(bouncyBallObject).GetComponent<BouncyBall>();


            var cam = GameObject.Find("Main Camera");
            var pos = cam.transform.position + (cam.transform.forward * 1);
            ball.transform.position = pos;
            ball.transform.rotation = new Quaternion();
            ball.GetComponent<Rigidbody>().velocity = (cam.transform.forward * 6f);
            ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);


            // Destroy ball after a period of time

            Destroy(ball, 1);
        }

        if (Input.GetKeyDown("x"))
        {
            var obj = GameObject.Find("spacialmesh");
            var r = obj.GetComponent<SpatialMappingRenderer>();
            var temp = r.OcclusionMaterial;
            r.OcclusionMaterial = alt;
            alt = temp;
        }

            // shoot balls from helicopter
            if (Input.GetKeyDown("v"))
        {
            if (helicopter != null)
            {
                BouncyBall ball = Instantiate(bouncyBallObject).GetComponent<BouncyBall>();


                var pos = helicopter.transform.position + (helicopter.transform.forward * 0.5f);
                ball.transform.position = pos;
                ball.transform.rotation = new Quaternion();
                ball.GetComponent<Rigidbody>().velocity = helicopter.transform.forward * 6f;
                ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);


                // Destroy ball after a period of time

                Destroy(ball, 1);

            }
        }


        // Place Blocks
        if (tapped || Input.GetKeyDown("b"))
        {
            BuildingBlock block = null;
            if (blocks.Count < 5) { 
                block = Instantiate(buildingBlockObject).GetComponent<BuildingBlock>();
                blocks.Add(block);
            }else
            {
                block = (BuildingBlock)blocks[this.pos];
                block.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                block.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                this.pos++;
                this.pos = this.pos % 5;
            }

            var cam = GameObject.Find("Main Camera");
            var pos = cam.transform.position + (cam.transform.forward * 2);
            block.transform.position = pos;
            block.transform.rotation = new Quaternion();
            block.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            block.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            tapped = false;
        }

        tapped = false;
    }
}


//using UnityEngine;
//using System.Collections;
//using UnityEngine.VR.WSA.Input;

//public class Main : MonoBehaviour
//{
//    public GameObject helicopterObject;
//    GestureRecognizer gesture;
//    bool tapped = false;

//    Helicopter helicopter = null;
//    // Use this for initialization
//    void Start()
//    {
//        gesture = new GestureRecognizer();
//        gesture.StartCapturingGestures();
//        gesture.TappedEvent += (a, b, c) =>
//        {
//            tapped = true;
//        };
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (tapped || Input.GetButtonDown("Fire1"))
//        {
//            if (helicopter == null)
//            {
//                helicopter = Instantiate(helicopterObject).GetComponent<Helicopter>();
//                //helicopter = (Helicopter)Resources.Load("Assets/Prefabs/Helicopter.prefab");
//                //helicopter = (Helicopter)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Helicopter.prefab", typeof(Helicopter)));
//            }

//            //place vehicle and reset velocity/position
//            var cam = GameObject.Find("Main Camera");
//            var pos = cam.transform.position + (cam.transform.forward * 2);
//            helicopter.transform.position = pos;
//            helicopter.transform.rotation = new Quaternion();
//            helicopter.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
//            helicopter.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
//        }

//        tapped = false;
//    }
//}
