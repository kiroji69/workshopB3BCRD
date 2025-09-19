using UnityEngine;

public class Vase : Interactible
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] float m_fallSpeed;

    bool m_stopTime = false;
    public AudioSource m_audioSource;
    public AudioClip breakingVase;
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
            m_stopTime=false;
            Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Cat.Get().m_isDestroyingLeft = false;
            Cat.Get().m_isDestroyingRight = false;
            Destroy(this.gameObject);
            m_audioSource.PlayOneShot(breakingVase, 1);
        }
    }


    protected override void Interact(Collider2D collision)
    {
        //Cat.Get().m_animator.
        m_stopTime = true;
        Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        

        float side =Cat.Get().transform.position.x - this.gameObject.transform.position.x;

        if (Mathf.Sign(side) < 0)
        {
            Cat.Get().m_isDestroyingLeft = true;
        }
        else
        {
            Cat.Get().m_isDestroyingRight = true;
        }

        print(Mathf.Sign(side));



    }


    protected override void Change(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        
    }

}
