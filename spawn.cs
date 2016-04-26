using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn : MonoBehaviour {

    float speedWaterUp = 12.0f;
    float speedWaterDown = 20.0f;
    int waterLevel = 0,minSize=2;
    public List<GameObject> waters;
    bool gap;
    float startTimer = 0;
    float waterYBoattom=0;
	// Use this for initialization
	void Start () {
        waters.Add(Instantiate(GameObject.Find("water"), new Vector3(-0.04f, 0, 0), Quaternion.identity) as GameObject);
        waters[0].GetComponent<SpriteRenderer>().sprite = Resources.Load("waterJet", typeof(Sprite)) as Sprite;
        waters[0].GetComponent<BoxCollider2D>().size = new Vector2(2.12f,1.2f);
        waters[0].GetComponent<BoxCollider2D>().isTrigger = false;
        config.head = waters[0];    
    }
	
	// Update is called once per frame
	void Update () {
        checkInput();
        if (!config.finish) updateScore();
        UpdateDownSpeed();
	}

    void checkInput()
    {
        if ((Input.GetMouseButton(0) || Input.touchCount>0) && WaterReserve.waterReserve>0)
        {
            
            if(gap)
            {
                waters.Add(Instantiate(GameObject.Find("water"), new Vector3(0, waterYBoattom - config.heightOfWater, 0), Quaternion.identity) as GameObject);
                gap = false;
            }
            for (int i = 0; i < waters.Count; i++)
            {
                if (i == 0)
                    waters[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedWaterUp);
                else
                    waters[i].GetComponent<Rigidbody2D>().transform.position =new Vector3(0, waters[i - 1].GetComponent<Rigidbody2D>().transform.position.y - config.heightOfWater,0);// new Vector3(0, speedWaterUp * Time.deltaTime, 0);
               // waters[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speedWaterUp));
               // waters[i].GetComponent<Rigidbody2D>().transform.position += new Vector3(0, speedWaterUp * Time.deltaTime, 0);
                //waters[i].transform.position += new Vector3(0, speedWaterUp * Time.deltaTime, 0);
                if(i==waters.Count-1)
                {
                    checkGap(waters[i]);
                }
            }
        }
          else
          {
              
              if(waters.Count>minSize)
              {
                  for (int i = 0; i < waters.Count; i++)
                  {

                      if (waters[i] != null)
                      {
                          if (i == 0)
                          {
                              if (waters[i].GetComponent<Rigidbody2D>().velocity.y > 0)
                                  waters[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                          }
                          else {
                              waters[i].GetComponent<Rigidbody2D>().transform.position = new Vector3(0, waters[i - 1].GetComponent<Rigidbody2D>().transform.position.y - config.heightOfWater, 0);
                          }
                          float py = waters[i].GetComponent<Rigidbody2D>().transform.position.y;
                        //  waters[i].GetComponent<Rigidbody2D>().transform.position = new Vector3(0, py - speedWaterDown * Time.deltaTime, 0);
                          if(checkDestroy(waters[i]))
                          {
                              waters.RemoveAt(i);
                          }
                      }

                  }
              }
            
          }

    }

    void checkGap(GameObject obj)
    {
        if (obj.transform.position.y >= 0)
        {
            waterYBoattom = obj.transform.position.y;
            gap = true;
        }
    }

    bool checkDestroy(GameObject obj)
    {

        if (obj.transform.position.y < 0)
        {
            Destroy(obj);
            return true;
        }
        return false;
    }
    
    void updateScore()
    {
        config.score = waters.Count;
    }
    void UpdateDownSpeed()
    {
        speedWaterDown += config.acceleration;
    }
}
