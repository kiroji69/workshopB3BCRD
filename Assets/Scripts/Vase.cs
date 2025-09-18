using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : Interactible
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] float m_fallSpeed;

    protected override void Interact(Collider2D collision)
    {
        //Cat.Get().m_animator.
        m_rb.AddForce(new Vector2(0,m_fallSpeed));

    }

    protected override void Change(Collider2D collision)
    {
        
        this.enabled = false;
    }

}
