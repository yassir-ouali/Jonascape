using UnityEngine;
using System.Collections;

public class WaterReserve : MonoBehaviour {

    /* Variable Configuration
    **************************/
    public float speedDiscountWater = 0.0f; // 0.1f


    /* Variable Works
    **************************/
    public static float waterReserve = 0.0f;
    private float waterReserveDefaultScaleX = 0.0f;

    /* Declare Objects
    **************************/



    /* Start & Update
    **************************/
    void Start()
    {
        // reset Water Reserve value
        waterReserve = 100.0f;

        // get Default value of water Reserve Default Scale X
        waterReserveDefaultScaleX = this.gameObject.transform.localScale.x;
    }

    void Update()
    {

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            
            waterReserve = DiscountWater(waterReserve);

            ChangeIndiceWaterReserve(this.gameObject);
        }

      //  Debug.Log(waterReserve);

    }


    /* Collision detecting
    *************************
    void OnCollisionEnter2D(Collision2D C){

    }

    void OnCollisionExit2D(Collision2D C){

    }

    void OnCollisionStay2D(Collision2D C){

    }*/


    /* Core
    **************************/
    public  float DiscountWater(float CurrentScoreWater)
    {
        if (CurrentScoreWater - speedDiscountWater <0)
        {
            return 0;
        }
        return CurrentScoreWater - speedDiscountWater;
    }

    private void ChangeIndiceWaterReserve(GameObject go)
    {
        float delta = WaterReserveToScaleX(waterReserve);
       // print(delta+"ffff");

        //go.transform.position = new Vector3(delta/2,0,0);
        go.transform.localScale = new Vector2(delta, go.transform.localScale.y);
    }

    private float WaterReserveToScaleX(float xwaterReserve)
    {
        return waterReserve * waterReserveDefaultScaleX / 100;
    }
}
