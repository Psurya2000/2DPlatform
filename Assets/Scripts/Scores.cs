using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public float score;
    public Text scorenum;
    // public GameObject coin;

    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            score = score + 1;
            Destroy(other.gameObject);
        }
           
        
    }

    public void Update()
    {
        scorenum.text = "Score : " + score.ToString();
      

    }
}