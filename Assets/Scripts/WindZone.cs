using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public Vector3 WindSpeed = new Vector3(0.1f, 0, 0.1f);
    // Start is called before the first frame update
 

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
       if(! WindZoneList.Instance.WindZoneLists.Contains(this.GetComponent<WindZone>()))
            WindZoneList.Instance.WindZoneLists.Add(this.GetComponent<WindZone>());


    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController.Instance._rigidbody.AddForce(PlayerController.Instance.WindSpeed, ForceMode.VelocityChange);
    }

    private void OnTriggerExit(Collider other)
    {
        WindZoneList.Instance.WindZoneLists.Remove(this.GetComponent<WindZone>());

        PlayerController.Instance._rigidbody.velocity -= PlayerController.Instance.WindSpeed;
    }
}
