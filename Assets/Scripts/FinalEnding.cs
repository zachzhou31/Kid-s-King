using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalEnding : MonoBehaviour
{
    public bool IsEnd = false;
    public GameObject Cup;
    public Text TextSubtitle;
    public AudioSource TeacherSound;
    public Image BlackImage;
    private float _noisy = 0;
    private bool _isBlack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnd)
        {
            PlayerController.Instance.IsJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _noisy += 10;
                TeacherSound.Play();
            }
        }
            
       
                

        if (_noisy > 100)
            End2();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBall")
        {
            IsEnd = true;
            End();
        }
            
    }

    public void End()
    {
        Cup.transform.position = Vector3.zero;
        TextSubtitle.text = "������������Ҫ�Ĳ豭���㿩�� ��캢��������Ī����";
        Invoke("RemoveBlack", 5f);
        TextSubtitle.text = "��Ȼ�� ������ĩ������ʦҲûʲô����ѧУ���ˣ��ٺ٣����������������";

    }

    public void End2()
    {
        
        TextSubtitle.text = "����ʦ �����������������ڵ��Ұ������� ��ʦ ��Ҫ�мҳ�������";
        Destroy(Cup);
        Invoke("RemoveBlack", 10f);
        BlackImage.enabled = true;
        WorldManager.Instance.CupCollectCount += 1;

    }

    public void RemoveBlack()
    {
        if (!_isBlack)
        {
            BlackImage.enabled = true;
            _isBlack = true;
        }
            
        else
            BlackImage.enabled = false;



    }
}
