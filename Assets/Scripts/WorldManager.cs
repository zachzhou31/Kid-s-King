using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public float EnterFantasyWorldTime = 10;
    bool m_IsFantsyWorld = false;

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
}
