using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneList : MonoBehaviour
{
    // Start is called before the first frame update

    // Singleton µ¥Àý
    public static WindZoneList Instance;
    
    public List<WindZone> WindZoneLists = new List<WindZone>();
    void Start()
    {
        if (!Instance) Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _extraSpeed = Vector3.zero;
        foreach (WindZone windzone in WindZoneLists)
            _extraSpeed = new Vector3(_extraSpeed.x + windzone.WindSpeed.x, _extraSpeed.y + windzone.WindSpeed.y, _extraSpeed.z + windzone.WindSpeed.z);
        PlayerController.Instance.WindSpeed = _extraSpeed;
    }


}
