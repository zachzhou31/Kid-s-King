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
    public GameObject DialogPicture;
    public GameObject Ground,EndPosition;
    public GameObject BossRound,FakeAttack,StageTwo;


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
                this.transform.localScale = new Vector3(3, 3, 3);
                Invoke("BossAttack", SpellWaitTime);
            }
                
            else
                Invoke("BossAttackFake", SpellWaitTime / 2);

            SpellTimer = 0;
        }


        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1, 1, 1), 1f);

        if (Health <= 0)
        {
            WorldManager.Instance.CupCollectCount = 2;
            Ground.tag = "Ground";
            PlayerController.Instance.transform.position = EndPosition.transform.position;
            StageTwo.SetActive(true);
            ShowSubtitle();
            
            FakeAttack.SetActive(false);
            BossRound.SetActive(false);
            this.gameObject.SetActive(false);

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
        FakeAttack.SetActive(true);
        FakeAttack.transform.position = new Vector3(_randomX, transform.position.y, _randomZ);
        BossAttack();
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
