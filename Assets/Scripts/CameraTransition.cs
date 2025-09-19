using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] float m_snapX;
    [SerializeField] float m_snapY;
    [SerializeField] float m_gap;
    [SerializeField] float m_smoothFactor;

    float valueSnap(float value, float step = 0.5f)
    {
        return Mathf.Floor(value / step)* step;
    }

    private void Update()
    {
        Vector3 pos = Cat.Get().transform.position;

        pos.x = Mathf.Clamp(valueSnap(pos.x, m_snapX),0 , m_snapX);

        pos.y = Mathf.Clamp(valueSnap(pos.y,m_snapY), 0 , m_snapY);

        



        Vector3 smoothie = new Vector3(pos.x + (m_snapX/2) +(m_gap * (pos.x/m_snapX)),
            pos.y + (m_snapY/2) + (m_gap * (pos.y / m_snapY)), -10);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, smoothie, m_smoothFactor*Time.deltaTime);

    }


}
