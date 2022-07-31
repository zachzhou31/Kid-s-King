using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float Health = 100;
    public float ChaseSpeed = 5f;
    public float SpellWaitTime = 10f;
    public GameObject BossRound,FakeAttack,StageTwo;

    private bool _attack = false;

    public static BossMove Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance) Instance = this;
    }
    void Start()
    {
        //’“µΩBossround
       // BossRound = FindObjectOfType<GameObject>().name.Equals("BossRound");
        BossRound.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_attack)
            if (Health > 15)
                Invoke("BossAttack",SpellWaitTime);
            else
                Invoke("BossAttackFake", SpellWaitTime/2);


        if(Health <= 0)
        {
            WorldManager.Instance.CupCollectCount += 1;
            StageTwo.SetActive(true);
            Destroy(gameObject);
            BossRound.SetActive(false);
        }

    }

    private void BossAttack()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed, ForceMode.Impulse);


    }

    private void BossAttackFake()
    {
        float _randomX = Random.Range(250f, 267f);
        float _randomZ = Random.Range(-213f, -230f);
        Instantiate(FakeAttack, new Vector3(_randomX, this.transform.position.y, _randomZ), FakeAttack.transform.rotation);
        BossAttack();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _attack = true;
    }
}
