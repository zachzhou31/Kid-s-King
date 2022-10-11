using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDetectBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TargetGameObject;
    public LayerMask LayerDetect;
    public Text TextSubtitle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _direction = (TargetGameObject.transform.position -Camera.main.transform.position);
        Ray _cameraRay = new Ray(transform.position, _direction);
        RaycastHit _cameraHit;
        if (Physics.Raycast(_cameraRay, out _cameraHit, Mathf.Infinity,LayerDetect))
        {
            TextSubtitle.text = "哦 古埃及建筑 最近美术课的主题是古埃及的冷兵器 冷兵器？哈哈 那当然还是坦克车更实在啦！！";
        }
    }
}
