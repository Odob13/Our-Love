using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class OnTrigger : MonoBehaviour
{

    [Serializable]
    public class TriggerEvent : UnityEvent {}
    private Collider player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<SphereCollider>();
    }

    // Event delegates triggered on click.
    [FormerlySerializedAs("onTriggerEnter")]
    [SerializeField]
    private TriggerEvent m_OnTriggerEnter= new TriggerEvent();

    [FormerlySerializedAs("onTriggerExit")]
    [SerializeField]
    private TriggerEvent m_OnTriggerExit= new TriggerEvent();
    // Start is called before the first frame update

    public TriggerEvent onTriggerEnter
    {
        get { return m_OnTriggerEnter; }
        set { m_OnTriggerEnter = value; }
    }

    public TriggerEvent onTriggerExit
    {
        get { return m_OnTriggerExit; }
        set { m_OnTriggerExit = value; }
    }


    private void OnTriggerEnter(Collider player)
    {
        m_OnTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider player)
    {
        m_OnTriggerExit.Invoke();
    }

}
