using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCat : MonoBehaviour
{
    [SerializeField]float m_treshold;
    [SerializeField]Collider2D m_collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        m_collider.enabled = Cat.Get().transform.position.y - m_collider.transform.position.y >= m_treshold;
        

        
    }
}
