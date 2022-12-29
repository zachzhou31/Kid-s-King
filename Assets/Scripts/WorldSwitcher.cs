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

    //Update �� �жϣ����ɫ������֮�ࣩ
    //

    public void Switch()
    {
        DistanceSwitch = Mathf.Lerp(30f, 10f, WorldManager.Instance.CupCollectCount / 3);
        
        if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) > DistanceSwitch) //������빻Զ�Ļ��ɰ������� ��������ߵĻ� ���ڻ���Ͳ������� ������ʵ ���������ֵ��Խ����С
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
