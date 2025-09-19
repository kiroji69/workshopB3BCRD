using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vase : Interactible
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] float m_fallSpeed;

    bool m_stopTime = false;

    float m_stopTimer = 2.0f;

    private void Update()
    {
        if (m_stopTime==true)
        {
            m_stopTimer -= Time.deltaTime;
        }

        if (m_stopTimer <= 1.0f)
        {
            m_rb.AddForce(new Vector2(0, -m_fallSpeed));
        }

        if (m_stopTimer <= 0.0f)
        {
            Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            Destroy(this.gameObject);
        }
    }


    protected override void Interact(Collider2D collision)
    {
        //Cat.Get().m_animator.
        m_stopTime = true;
        Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
       
           

        

        
    }


    protected override void Change(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        
    }

}
