using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("je sens qqch");

        if (collision.CompareTag("Cat"))
        {
            print("c'est moi");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
