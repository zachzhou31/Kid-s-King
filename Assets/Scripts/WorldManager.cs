using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public float EnterFantasyWorldTime = 10;
    bool m_IsFantsyWorld = false;
    public int CupCollectCount = 0;
    public Text CupSubtitle;
    float _stopTimeRecord;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if velocity = 0 ³ÖÐø5Ãë IsFantasyWorld = false;
        if (this.GetComponent<Rigidbody>().velocity.magnitude == 0)
            _stopTimeRecord = Time.time;
        IsFantasyWorld = IsThinking();

        if (CupCollectCount == 3)
            Win();

        CupSubtitle.text = "Cups: " + CupCollectCount;
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
                return false;
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
