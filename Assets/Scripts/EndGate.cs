using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.CompareTag("Cat"))
        {
            
            SceneManager.LoadScene("SampleScene");
        }
    }
}
