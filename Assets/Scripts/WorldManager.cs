using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    bool m_IsFantsyWorld = false;

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
        if (Input.GetKeyDown(KeyCode.O)) IsFantasyWorld = true;
        if (Input.GetKeyDown(KeyCode.P)) IsFantasyWorld = false;
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
}
