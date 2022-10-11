using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeAttack : MonoBehaviour
{
    public float ChaseSpeed = 10f;

    private float SpellTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpellTimer += Time.deltaTime;
        if (SpellTimer > 15)
        {
            FAttack();
            SpellTimer = 0;
        }
            
 
    }



    void FAttack()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed * 2, ForceMode.Impulse);
    }


}
