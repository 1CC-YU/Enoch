using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHelper : MonoBehaviour
{
    #region 서식
    public static readonly string FORMAT_AMOUNT = "x{0:n0}";
    #endregion

    #region 아이템
    public static readonly float BOOTS_ITEM_BUFF = 5f;
    #endregion

    #region 대화
    public static readonly string MSG_PURCHASE = "{0}를 {1}g에 구매하였습니다.";
    #endregion
}
