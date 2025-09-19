using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] public Rigidbody2D m_rb;
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] internal Animator m_animator;
    [SerializeField] LayerMask m_walkableMask;
    [SerializeField] LayerMask m_interactible;
    [SerializeField] LayerMask m_jumpLayers;
    [SerializeField] float m_speed;
    [SerializeField] float m_bodyOffset;
    [SerializeField] Transform m_groundRef;

    float m_actiontimer = 4;

    [SerializeField] float m_yDetectionTreshold;
    [SerializeField] float m_xDetectionTreshold;

    public AudioSource audiosource;
    public AudioClip start_Jump;
    public AudioClip end_jump;

    bool m_shouldDoSmth = true;
    [SerializeField] int m_minDoSmth = 1;
    [SerializeField] int m_maxDoSmth = 5;
    [SerializeField] int m_attentionRange;
    [SerializeField] public bool m_jumpCheck = true;

    [HideInInspector] public bool m_isJumping;
    [HideInInspector] public bool m_isSleeping;
    [HideInInspector] public bool m_isDestroyingLeft;
    [HideInInspector] public bool m_isDestroyingRight;


    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

        m_animator.SetBool("isJumping", m_isJumping);
        m_animator.SetBool("isSleeping", m_isSleeping);
        m_animator.SetBool("isDestroyingLeft", m_isDestroyingLeft);
        m_animator.SetBool("isDestroyingRight", m_isDestroyingRight);

        if (m_shouldDoSmth == true)
        {
            m_actiontimer -= Time.deltaTime;
        }
        

        if (m_actiontimer <= 0)
        {

            m_actiontimer = Random.Range(m_minDoSmth, m_maxDoSmth);

            
            int action = Random.Range(0, 2);
            //DoSomething(action);

        }


        Collider2D collider = Physics2D.OverlapCircle(m_groundRef.position , .2f, m_walkableMask);
        Collider2D trampoline = Physics2D.OverlapCircle(m_groundRef.position , .2f, m_jumpLayers);

        if(collider != null)
        {

            m_isJumping = false;
        }

        Vector2 target = Laser.Get().transform.position-m_rb.transform.position;
        
        if (Laser.Get().m_enabled == true && target.magnitude <= m_attentionRange)
        {

            if  (collider != null && target.y < m_yDetectionTreshold && target.y > -m_yDetectionTreshold)
            {
                m_rb.AddForce(new Vector2(Mathf.Sign(target.x) * m_speed, 0));
            }
            else if(trampoline != null && trampoline.gameObject.GetComponent<JumpPad>())
            {
                JumpPad jp = trampoline.gameObject.GetComponent<JumpPad>();

                foreach(JumpPoint jumpPoint in jp.jumpPoints)
                {
                    Vector2 vForce = jumpPoint.endPoint.position - (Vector3)m_rb.position;
                    //print(" dot: " + Vector2.Dot(vForce.normalized, target.normalized));
                    if(Vector2.Dot(vForce.normalized, target.normalized) > 0.9f &&  m_jumpCheck == true)
                    {
                        audiosource.PlayOneShot(start_Jump,1);
                        m_isJumping = true;
                        m_jumpCheck = false;
                        m_rb.AddForce(jumpPoint.force);
                        break;
                    }

                }



            }

            //else if (Laser.Get().m_enabled == true && target.y < 3 && target.y > -3)
            //{
            //    m_rb.AddForce(new Vector2(target.x, 0));
            //}


        }

        //if (collider != null)
        //{
        //    var r = m_rb.position;
        //    r.x = Mathf.Clamp(r.x, collider.bounds.min.x, collider.bounds.max.x);

        //    m_rb.position = r;

        //}


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

 

    //private void OnTriggerStay2D(Collision2D collision)
    //{

    //}


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Target"))
    //    {
    //        print(m_jumpCheck);
    //        m_shouldDoSmth = true;
    //        m_jumpCheck = true;
    //        print("et maintenant ?? " + m_jumpCheck);
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Target"))
    //    {
    //        if(collision.attachedRigidbody.position.x > m_rb.position.x && collision.attachedRigidbody.position.y <= m_rb.position.y)
    //        {
    //            m_shouldDoSmth = false;
    //            m_rb.AddForce(new Vector2(20, 0));
                
    //        }
    //        else if(collision.attachedRigidbody.position.x < m_rb.position.x && collision.attachedRigidbody.position.y <= m_rb.position.y)
    //        {
    //            m_shouldDoSmth = false;
    //            m_rb.AddForce(new Vector2(-20, 0));
    //        }
            


    //        if (collision.attachedRigidbody.position.y > m_rb.position.y && collision.attachedRigidbody.position.y - m_rb.position.y >=2.0f)
    //        {
    //            //print("en haut miaou");
    //            Collider2D groundCheck = Physics2D.OverlapCircle(m_groundRef.position, .2f, m_jumpLayers);
    //            if (groundCheck != null && m_jumpCheck == true)
    //            {
    //                float puissanceX = groundCheck.GetComponent<JumpPad>().m_puissanceX;
    //                float puissanceY = groundCheck.GetComponent<JumpPad>().m_puissanceY;

    //                Transform destination = groundCheck.GetComponent<JumpPad>().m_destination;

    //               Vector2 cible = new Vector2((destination.position.x - m_rb.position.x)* puissanceX, (destination.position.y - m_rb.position.y)*puissanceY);


    //                m_shouldDoSmth = false;
    //                m_rb.AddForce(cible);
    //                m_jumpCheck = false;

    //            }
                

    //        }
    //    }
    //}


    public static Cat Get()
    {

        return FindAnyObjectByType<Cat>();

    }

















}
