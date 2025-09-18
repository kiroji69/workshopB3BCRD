using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] Animator m_animator;
    [SerializeField] LayerMask m_walkableMask;
    [SerializeField] LayerMask m_interactible;
    [SerializeField] LayerMask m_jumpLayers;
    [SerializeField] float m_speed;
    [SerializeField] GameObject m_target;
    [SerializeField] Transform m_groundRef;

    float m_actiontimer = 0;


    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        m_actiontimer += Time.deltaTime;

        
        int actionTime = 3;

        if (m_actiontimer > actionTime)
        {
           
            int action = Random.Range(0, 2);
            //DoSomething(0);
            
            m_actiontimer = 0;
        }
        
    }


    void DoSomething(int action)
    {
        int direction = Random.Range(-1, 2);



        if (action == 0)
        {
            
            m_rb.AddForce(new Vector2(direction*400, 0));
        }

        else
        {
           
        }

    }

    private int GetRnd()
    {
        int rnd = Random.Range(1, 10);

        return rnd;
    }

    //private void OnTriggerStay2D(Collision2D collision)
    //{
        
    //}


    private void OnCollisionExit2D(Collision2D collision)
    {
        print("mama");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            if(collision.attachedRigidbody.position.x > m_rb.position.x && collision.attachedRigidbody.position.y <= m_rb.position.y)
            {
                m_rb.AddForce(new Vector2(20, 0));
            }
            else if(collision.attachedRigidbody.position.x < m_rb.position.x && collision.attachedRigidbody.position.y <= m_rb.position.y)
            {
                m_rb.AddForce(new Vector2(-20, 0));
            }
            


            if (collision.attachedRigidbody.position.y > m_rb.position.y && collision.attachedRigidbody.position.y - m_rb.position.y >=2.0f)
            {
                print("en haut miaou");
                bool groundCheck = Physics2D.OverlapCircle(m_groundRef.position, .2f, m_jumpLayers);
                if (groundCheck == true)
                    {

                    print("je saute");
                        
                        
                    }
                

            }
        }
    }




















}
