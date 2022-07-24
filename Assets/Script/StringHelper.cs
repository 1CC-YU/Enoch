using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHelper : MonoBehaviour
{
    #region ����
    public static readonly string FORMAT_AMOUNT = "x{0:n0}";
    #endregion

    #region ������
    public static readonly int HEALTH_CARE_20 = 20;
    public static readonly int HEALTH_CARE_50 = 50;
    public static readonly int HEALTH_CARE_80 = 80;

    public static readonly int HEALTH_PRICE_20 = 100;
    public static readonly int HEALTH_RRICE_50 = 200;
    public static readonly int HEALTH_PRICE_80 = 300;
    #endregion

    #region ��ȭ
    public static readonly string MSG_PURCHASE = "{0}�� {1}Cos�� �����Ͽ����ϴ�.";
    #endregion


    // ����� ENUM �ᵵ ��? �ƴϸ� ����Ʈ, �׷� LEVEL[1-10] ��������
    #region  ĳ���� ����
    // ���õ� ä��Ƚ��
    public static readonly int MASTERY_1_STONE = 5;
    public static readonly int MASTERY_1_COPPER = 6;
    public static readonly int MASTERY_1_STEEL = 7;

    public static readonly int MASTERY_2_STONE = 5;
    public static readonly int MASTERY_2_COPPER = 6;
    public static readonly int MASTERY_2_STEEL = 7;

    public static readonly int MASTERY_3_STONE = 4;
    public static readonly int MASTERY_3_COPPER = 5;
    public static readonly int MASTERY_3_STEEL = 6;

    public static readonly int MASTERY_4_STONE = 4;
    public static readonly int MASTERY_4_COPPER = 5;
    public static readonly int MASTERY_4_STEEL = 6;

    public static readonly int MASTERY_5_STONE = 3;
    public static readonly int MASTERY_5_COPPER = 4;
    public static readonly int MASTERY_5_STEEL = 5;
    public static readonly int MASTERY_5_RUBY = 7;

    public static readonly int MASTERY_6_STONE = 3;
    public static readonly int MASTERY_6_COPPER = 4;
    public static readonly int MASTERY_6_STEEL = 5;
    public static readonly int MASTERY_6_RUBY = 6;

    public static readonly int MASTERY_7_STONE = 2;
    public static readonly int MASTERY_7_COPPER = 3;
    public static readonly int MASTERY_7_STEEL = 4;
    public static readonly int MASTERY_7_RUBY = 6;

    public static readonly int MASTERY_8_STONE = 2;
    public static readonly int MASTERY_8_COPPER = 3;
    public static readonly int MASTERY_8_STEEL = 4;
    public static readonly int MASTERY_8_RUBY = 5;
    public static readonly int MASTERY_8_DIAMOND = 7;

    public static readonly int MASTERY_9_STONE = 1;
    public static readonly int MASTERY_9_COPPER = 2;
    public static readonly int MASTERY_9_STEEL = 3;
    public static readonly int MASTERY_9_RUBY = 5;
    public static readonly int MASTERY_9_DIAMOND = 6;

    public static readonly int MASTERY_10_STONE = 1;
    public static readonly int MASTERY_10_COPPER = 2;
    public static readonly int MASTERY_10_STEEL = 3;
    public static readonly int MASTERY_10_RUBY = 4;
    public static readonly int MASTERY_10_DIAMOND = 5;


    // �� ����ȹ�淮
    public static readonly int LUCK_1_STONE = 1;
    public static readonly int LUCK_1_COPPER = 1;
    public static readonly int LUCK_1_STEEL = 1;
    public static readonly int LUCK_1_RUBY = 1;
    public static readonly int LUCK_1_DIAMOND = 1;

    // �� ������ ���� ����


    #endregion
    #region ���� ����
    public static readonly float MONTER_MAX_VECTOR = 1f;
    public static readonly float MONTER_MIN_VECTOR = -1f;
    public static readonly float MONTER_STOP = 0f;
    #endregion
}
