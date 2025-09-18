using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{

    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] float m_fallSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            m_rb.AddForce(new Vector2(0, - m_fallSpeed));

        }

        if (collision.CompareTag("Interactible"))
        {

            collision.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
