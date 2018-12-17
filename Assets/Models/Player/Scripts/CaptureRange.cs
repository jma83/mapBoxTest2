﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureRange : MonoBehaviour {
    private bool dir = true;
    private const float factor = 0.004f;
    private float range=0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float aux = 0;

        if (GameManager.Instance.CurrentPlayer.CaptureRange != range)
            range = GameManager.Instance.CurrentPlayer.CaptureRange;


        if (dir)
            aux = transform.localScale.x - factor;
        else
            aux = transform.localScale.x + factor;

        if (transform.localScale.x <= -0.5)
            dir = false;
        if (transform.localScale.x >= 0.5)
            dir = true;

        transform.localScale = new Vector3(aux, transform.localScale.y, aux);
        //Wait();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    //collision manager
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "droid")
        {
            print("droiddeeee");
            foreach (GameObject gm_obj in GameManager.Instance.CurrentPlayer.NearEntities)
            {
                if (gm_obj!= col.gameObject)
                {

                }
            }
        }
        else
        {

        }
    }
}
