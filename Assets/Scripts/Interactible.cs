using UnityEngine;

public class Interactible : MonoBehaviour
{

    
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {

            Interact(collision);
            
        }

        if (collision.CompareTag("Interactible"))
        {

            //collision.gameObject.SetActive(false);
            //this.enabled = false;
            Change(collision);
        }
    }



    protected virtual void Interact(Collider2D collision)
    {

    }

    protected virtual void Change(Collider2D collision)
    {

    }

}
