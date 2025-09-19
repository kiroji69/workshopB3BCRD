using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : Interactible
{
    [SerializeField]Sprite m_sprite;

    float m_sleepTimer = 3.5f;

    bool m_sleepingTime= false;

    private void Update()
    {
        if (m_sleepingTime == true)
        {
            m_sleepTimer -= Time.deltaTime;
        }
        if (m_sleepTimer < 0.5f)
        {
            Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            Cat.Get().m_rb.AddForce(new Vector2(-5, 0));
        }
        if (m_sleepTimer < 0.0f)
        {
            Cat.Get().m_rb.Sleep();
            Cat.Get().m_rb.WakeUp();
            m_sleepingTime = false;
            m_sleepTimer = 3.5f;
        }

    }

    protected override void Interact(Collider2D collision)
    {
        Cat.Get().m_rb.transform.position = this.transform.position;
        Cat.Get().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        print("dodo miaou"); // animation ici

        m_sleepingTime = true;


    }

    protected override void Change(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().sprite = m_sprite;
        this.GetComponent<Collider2D>().enabled = false;
    }

}
