using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone_Monster : MonoBehaviour
{
    //by재은, 몬스터가 플레이어 때리는것 구현 - 230807
    //충돌체가 Player Collider일 때, 한대 때리기
    //몬스터 자체 Collider는 Player를 자동으로 따라가는 것으로 사용중이기 때문에
    //하위 오브젝트를 만들어줌 (HitZone_Monster)

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
