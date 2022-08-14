using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public GameObject DialogPicture;
    public float EnterFantasyWorldTime = 10;
    public bool m_IsFantsyWorld = false;
    public int CupCollectCount = 0;
    public Text CupSubtitle,TextSubtitle;
    float _stopTimeRecord = 0;
    public bool IsFantasyWorld
    {
        get => m_IsFantsyWorld;
        set
        {
            m_IsFantsyWorld = value;
            Switch();
        }
    }

    List<WorldSwitcher> m_Switchers = new List<WorldSwitcher>();

    private void Awake()
    {
        if (!Instance) Instance = this;
        
        TextSubtitle.text = "小子 我再重复一遍 我们玩弹珠讲究的就是公平，你只要弹进三个杯子口就算胜利了，明白了吗？";
        Invoke("Disappear", 4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if velocity = 0 持续5秒 IsFantasyWorld = false;
        if (PlayerController.Instance._rigidbody.velocity.magnitude <= 0.1)
        {
            IsFantasyWorld = false;
                
        }
        else
        {
            IsFantasyWorld = true;
        }
            
        

        if (CupCollectCount == 3)
            Win();

        CupSubtitle.text = "Cups: " + CupCollectCount;
    }
    void Disappear()
    {
        DialogPicture.SetActive(false);
    }
    public void Switch()
    {
        foreach (var switcher in m_Switchers)
            if (switcher)
                switcher.Switch();
    }

    public void AddSwitcher(WorldSwitcher sitwhcer)
    {
        m_Switchers.Add(sitwhcer);
    }

    public bool IsThinking()
    {
        if (_stopTimeRecord != 0)
            if (Time.time - _stopTimeRecord > EnterFantasyWorldTime)
            {
                _stopTimeRecord = 0;
                return false;
            }

            else
                return true;
        else
            return true;
    }

    public void Win()
    {
        Application.Quit();
    }
}
