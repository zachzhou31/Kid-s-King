using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float WindForce = 0.1f;
    public float WaitTime;

    float _time = 0f;
    float _saveForce ;
    public Vector3 Velocity
    {
        get
        {
            return transform.forward * WindForce;
        }
    }


    //public Vector3 WindSpeed = new Vector3(0.1f, 0, 0.1f);
    // Start is called before the first frame update
 

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
       //if(! WindZoneList.Instance.WindZoneLists.Contains(this.GetComponent<WindZone>()))
       //     WindZoneList.Instance.WindZoneLists.Add(this.GetComponent<WindZone>());
       if(other.name == "Player")
        {
            if (!WindZoneList.Instance.WindZoneLists.Contains(this))
            {
                WindZoneList.Instance.WindZoneLists.Add(this);
            }
        }



    }

    private void OnTriggerStay(Collider other)
    {
        //PlayerController.Instance._rigidbody.AddForce(PlayerController.Instance.WindSpeed, ForceMode.Force);
    }

    private void OnTriggerExit(Collider other)
    {
        //WindZoneList.Instance.WindZoneLists.Remove(this.GetComponent<WindZone>());

        //PlayerController.Instance._rigidbody.velocity -= PlayerController.Instance.WindSpeed;

        if (WindZoneList.Instance.WindZoneLists.Contains(this))
        {
            WindZoneList.Instance.WindZoneLists.Remove(this);
        }
    }
    private void Start()
    {
        _saveForce = WindForce;
    }
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= WaitTime && _time <= 2*WaitTime)
            WindForce = 0;
        else
            WindForce = _saveForce;

        if (_time > 20f)
            _time = 0f;
    }
}
