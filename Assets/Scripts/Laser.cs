using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{

    Rigidbody2D m_rb;
    SpriteRenderer m_spriteRenderer;

    [SerializeField]public int m_batteryMax = 4;
    [SerializeField]Image m_image;

    int m_battery;
    float m_charge = 2.0f;
    float m_timerBattery;
    float m_timerRecharge = 1.0f;
    bool m_usable = true;
    
    

    public bool m_enabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //m_rb = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_timerBattery = (float)m_batteryMax/m_charge;
        m_battery = m_batteryMax;
        
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        m_image.fillAmount = m_battery/(float)m_batteryMax;



        if(m_enabled == true)
        {


            //move dot
            m_spriteRenderer.enabled = true;
            Vector3 pos = Input.mousePosition;
            pos.z = 0;
            Vector3 v = Camera.main.ScreenToWorldPoint(pos);
            v.z = 0;
            transform.position = v;
            m_timerBattery -= Time.deltaTime;
            
        }
        else
        {
            Cat.Get().m_jumpCheck = true;
            m_spriteRenderer.enabled = false;
            m_timerRecharge -= Time.deltaTime;
            if (m_battery >=2)
            {
                m_usable = true;
            }
        }

        if(m_timerBattery <=0)
        {
            m_enabled = false;
            m_timerBattery = (float)m_batteryMax / m_charge;
        }
        if (m_timerRecharge <= 0) 
        {
            m_timerRecharge = 1.0f;
            if(m_battery < 4)
            {
                m_battery++;
            }
        }
        

       
            
        if (Input.GetButtonDown("Fire1"))
        {

            if (m_battery >= 2 && m_usable == true)
            {
                m_battery -= 2;
                m_enabled = true;
                m_usable = false;
               
               
            }
            
            
        }
       

        if (Input.GetButtonUp("Fire1"))
        {
            
        }

    }

    public static Laser Get()
    {

        return FindAnyObjectByType<Laser>();

    }
}
