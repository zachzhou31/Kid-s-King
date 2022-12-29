using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject RealWorldGroup;
    public GameObject FantasyWorldGroup;
    public float DistanceSwitch;
    void Start()
    {
        WorldManager.Instance.AddSwitcher(this);
        //StartCoroutine(ISwitch());
    }

    //Update 里 判断（与角色的条件之类）
    //

    public void Switch()
    {
        DistanceSwitch = Mathf.Lerp(30f, 10f, WorldManager.Instance.CupCollectCount / 3);
        
        if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) > DistanceSwitch) //如果距离够远的会变成埃及样子 但是在身边的话 处于幻想和操作考虑 还是现实 ，后续这个值会越来愈小
            StartCoroutine(ISwitch());
    }

    IEnumerator ISwitch()
    {
        yield return new WaitForSeconds(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) / 50);
        if (RealWorldGroup)
            RealWorldGroup.SetActive(!WorldManager.Instance.IsFantasyWorld);

        if (FantasyWorldGroup)
            FantasyWorldGroup.SetActive(WorldManager.Instance.IsFantasyWorld);
    }
}
