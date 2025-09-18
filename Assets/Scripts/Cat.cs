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
    [SerializeField] float m_speed;
    [SerializeField] GameObject m_target;

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
            print(action);
            m_actiontimer = 0;
        }
        
    }


    void DoSomething(int action)
    {

        if (action == 0)
        {

        }

    }

    private int GetRnd()
    {
        int rnd = Random.Range(1, 10);

        return rnd;
    }




















}
