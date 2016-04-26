using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

    float timer = 0;
    bool hit = false;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, config.heightOfWater+5, 0);
        GameObject.Find("earth top").transform.position = new Vector3(0, config.heightOfWater * config.LevelSize/2, 0);
        config.hero = GameObject.Find("hero");
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ("enemie".Equals(other.gameObject.tag))
        {

            //print(other.gameObject.name);
            //Time.timeScale = 0;
            Application.LoadLevel("scene0");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
        }
        
    }

    void changeOpacity()
    {

        /*if()
        {

        }*/
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
