using UnityEngine;
using System.Collections;

public class win : MonoBehaviour {

    bool wina = false;
    float counter = 0;

	void OnTriggerEnter2D(Collider2D ot)
    {
        /*
        print("55555555555" + ot.gameObject.name);
        
        if("earth_top".Equals(ot.gameObject.name))
        {
            print("aaaaaaa" + ot.gameObject.name);
            config.finish = true;
            config.head.GetComponent<BoxCollider2D>().isTrigger = true;
        }*/

        if ("earth top".Equals(ot.gameObject.name))
        {

            config.finish = true;
            config.head.GetComponent<BoxCollider2D>().isTrigger = true;

            wina = true;
        }
    }

    void Update()
    {
        if (wina)
        {
            counter += Time.deltaTime;
        }

        if (counter > 5)
        {
            Application.LoadLevel("scene2");
        }
    }
}
