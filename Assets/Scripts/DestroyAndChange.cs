using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndChange : MonoBehaviour
{
    public bool Collid = false;
    // Start is called before the first frame update
    public GameObject invisibleCup,Ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Collid)
            CollidHappen();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerBall")
        {
            CollidHappen();

            Ground.tag = "Untagged";
        }
    }

    [ContextMenu("Test Collide")]
    void CollidHappen()
    {
        if (invisibleCup != null)
            invisibleCup.SetActive(true);
        Destroy(gameObject);
    }
}
