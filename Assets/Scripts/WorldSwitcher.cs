using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject RealWorldGroup;
    public GameObject FantasyWorldGroup;

    void Start()
    {
        WorldManager.Instance.AddSwitcher(this);
        StartCoroutine(ISwitch());
    }


    public void Switch()
    {
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
