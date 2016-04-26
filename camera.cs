using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject target;
    public Vector3 delta ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = target.transform.position + new Vector3(0, 0, -10);
        //Vector3 a=;
      transform.position = Vector3.Lerp(transform.position,target.transform.position+delta,1.0f)+new Vector3(0,0,-10);
	}
}
