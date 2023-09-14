using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCount;
    public Text playerCount;


    void Awake()
    {
        playerCount.text = "0";
        stageCount.text = "/ " + totalItemCount.ToString();
    }
    public void GetItem(int count)
    {
        playerCount.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(stage);
    }

}
