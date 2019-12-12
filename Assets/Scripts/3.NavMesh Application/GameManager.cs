﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour {
    public GameObject[] spawningPoints;
    public GameObject alien;
    public GameObject player;

    // Use this for initialization
    IEnumerator Start () {
		while (true)
        {
            // To do : Select one of the spawning points(spawningPoints) randomly
            // and then instantiate an alien object
            // Don't forget to set the alien's target to player
            int spawn = Random.Range(0, spawningPoints.Length);

            GameObject.Instantiate(alien, spawningPoints[spawn].transform.position, Quaternion.identity);
           
            if (player != null)
            {
                alien.GetComponent<Alien>().target = player;
            }

            yield return new WaitForSeconds(5f);
        }
	}
}
