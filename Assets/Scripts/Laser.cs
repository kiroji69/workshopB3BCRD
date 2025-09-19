using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Rigidbody2D m_rb;
    SpriteRenderer m_spriteRenderer;

    [SerializeField]public float m_battery = 4;

    bool m_usable = true;
    
    

    public bool m_enabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //m_rb = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
       
            
        if (Input.GetButton("Fire1"))
        {

            m_battery -= Time.deltaTime;

            if (m_battery > 0 && m_usable == true)
            {
                //m_rb.WakeUp();
                //this.GetComponent<Collider2D>().enabled = true;
                //show dot
                m_spriteRenderer.enabled = true;
                m_enabled = true;

                //move dot
                Vector3 pos = Input.mousePosition;
                pos.z = 0;
                Vector3 v = Camera.main.ScreenToWorldPoint(pos);
                v.z = 0;
                transform.position = v;
            }
            else
            {
                Cat.Get().m_jumpCheck = true;
                //hide dot
                m_spriteRenderer.enabled = false;
                //m_rb.Sleep();
                //this.GetComponent<Collider2D>().enabled = false;
                m_enabled = false;
                m_usable = false;
                

            }
            
        }
        else 
        {

            if (m_battery < 4)
            {
                m_battery += Time.deltaTime;
            }
            else
            {
                m_usable = true;
            }

            Cat.Get().m_jumpCheck = true;
            //hide dot
            m_spriteRenderer.enabled = false;
            //m_rb.Sleep();
            //this.GetComponent<Collider2D>().enabled = false;
            m_enabled = false;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            print("cloock up");
        }

    }

    public static Laser Get()
    {

        return FindAnyObjectByType<Laser>();

    }
}
