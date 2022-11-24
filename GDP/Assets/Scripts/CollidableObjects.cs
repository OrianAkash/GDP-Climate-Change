using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObjects : MonoBehaviour
{
    private Collider2D m_coll;
    [SerializeField]
    private ContactFilter2D m_filter;
    private List<Collider2D> m_collObjects = new List<Collider2D>(1);

    protected virtual void Start()
    {
        m_coll = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        m_coll.OverlapCollider(m_filter, m_collObjects);
        foreach(var i in m_collObjects)
        {
            OnCollided(i.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided with " + collidedObject.name);
    }
}
