using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone_Monster : MonoBehaviour
{
    //by����, ���Ͱ� �÷��̾� �����°� ���� - 230807
    //�浹ü�� Player Collider�� ��, �Ѵ� ������
    //���� ��ü Collider�� Player�� �ڵ����� ���󰡴� ������ ������̱� ������
    //���� ������Ʈ�� ������� (HitZone_Monster)

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HitPlayer(collision.transform);
        }
    }

    private void HitPlayer(Transform pPlayer)
    {
        Player player = pPlayer.GetComponent<Player>();
        player.OnDamaged();
    }
    */
}
