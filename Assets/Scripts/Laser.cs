using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Rigidbody2D m_rb;
    SpriteRenderer m_spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
       
            
        if (Input.GetButton("Fire1"))
        {

            m_rb.WakeUp();
            this.GetComponent<Collider2D>().enabled = true;
            //show dot
            m_spriteRenderer.enabled = true;
            

            //move dot
            Vector3 pos = Input.mousePosition;
            pos.z = 0;
            m_rb.position = Camera.main.ScreenToWorldPoint(pos);
        }
        else 
        {

            
            //hide dot
            m_spriteRenderer.enabled = false;
            m_rb.Sleep();
            this.GetComponent<Collider2D>().enabled = false;

        }


    }
}
