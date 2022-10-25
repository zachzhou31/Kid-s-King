using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{
    public float Health = 100;
    public float ChaseSpeed = 5f;
    public float SpellWaitTime = 10f;
    public float SpellTimer = 0;
    public Text TextSubtitle;
    public GameObject DialogPicture,Rope;
    public GameObject Ground,EndPosition;
    public GameObject BossRound,FakeAttack,StageTwo,AttackFinger;


    public static BossMove Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance) Instance = this;
    }
    void Start()
    {
        //找到Bossround
       // BossRound = FindObjectOfType<GameObject>().name.Equals("BossRound");
        BossRound.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        SpellTimer += Time.deltaTime;

        if (SpellTimer > 10)
        {
            if (Health > 15)
            {
                AttackPose();
            }
                
            else
                Invoke("BossAttackFake", SpellWaitTime / 2);

            SpellTimer = 0;
        }



        if (Health <= 0)
        {
            WorldManager.Instance.CupCollectCount = 2;
            Ground.tag = "Ground";
            PlayerController.Instance.transform.position = EndPosition.transform.position;

            StageTwo.SetActive(true);
            ShowSubtitle();
            Rope.SetActive(true);
            FakeAttack.SetActive(false);
            BossRound.SetActive(false);
            this.gameObject.SetActive(false);

        }
        
    }

    void AttackPose()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        AttackFinger.transform.position = transform.position - direction * 5;
        AttackFinger.SetActive(true);

        StartCoroutine(FingerTo());

        Invoke("BossAttack", SpellWaitTime);
    }

    IEnumerator FingerTo()
    {
        float _sec = 0f;
        while (_sec < 5f)
        {
            _sec += Time.deltaTime;
            AttackFinger.transform.position = Vector3.MoveTowards(AttackFinger.transform.position, transform.position, 0.01f);
            yield return null;
        }


    }
    private void BossAttack()
    {
        
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed, ForceMode.Impulse);

        AttackFinger.SetActive(false);
    }

    private void BossAttackFake()
    {
        float _randomX = Random.Range(6f, 28f);
        float _randomZ = Random.Range(-20f, 5f);
        FakeAttack.SetActive(true);
        FakeAttack.transform.position = new Vector3(_randomX, transform.position.y, _randomZ);
        AttackPose();
    }

    void ShowSubtitle()
    {
        TextSubtitle.text = "只剩最后一个茶杯了，从讲台那里跳过去吧";
        Invoke("Disappear", 5f);
    }

    void Disappear()
    {
        DialogPicture.SetActive(false);
    }
}
