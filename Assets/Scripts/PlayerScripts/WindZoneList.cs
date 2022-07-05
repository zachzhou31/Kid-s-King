using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneList : MonoBehaviour
{
    // Start is called before the first frame update

    // Singleton µ¥Àý
    public static WindZoneList Instance;
    
    public List<WindZone> WindZoneLists = new List<WindZone>();

    Rigidbody m_Rigidbody;
    [SerializeField] Vector3 m_WindForce;

    private void Awake()
    {
        if (!Instance) Instance = this;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_WindForce = Vector3.zero;

        //Vector3 _extraSpeed = Vector3.zero;
        /*
        foreach (WindZone windzone in WindZoneLists)
            _extraSpeed = new Vector3(_extraSpeed.x + windzone.WindSpeed.x, _extraSpeed.y + windzone.WindSpeed.y, _extraSpeed.z + windzone.WindSpeed.z);
        PlayerController.Instance.WindSpeed = _extraSpeed;
        */

        foreach (var windZone in WindZoneLists)
        {
            m_WindForce += windZone.Velocity;
        }
    }

    private void FixedUpdate()
    {
        if (WindZoneLists.Count > 0)
        {
            m_Rigidbody.AddForce(m_WindForce);
        }
    }
}
