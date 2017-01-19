/********************************************
-	    File Name: Property
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

public class Property  
{
    public Property()
    {
        Strength = 0;
        Agility = 0;
        Intellect = 0;

        StrengthStepLength = 0;
        AgilityStepLength = 0;
        IntellectStepLength = 0;

        HP = 0;
        FightCapacity = 0;
        BasicAttackLow = 0;
        BasicAttackHigh = 0;
        CriticalStrikeMultiple = 1.0f;

        PhysicalAttack = 0;
        PhysicalDefence = 0;
        MagicAttack = 0;
        MagicDefence = 0;
        CriticalStrike = 0;
        CriticalStrikeDefence = 0;
        Hit = 0;
        SideStep = 0;
        HolyHurt = 0;
    }

    public void Copy(Property other)
    {
        Strength = other.Strength;
        Agility = other.Agility;
        Intellect = other.Intellect;

        StrengthStepLength = other.StrengthStepLength;
        AgilityStepLength = other.AgilityStepLength;
        IntellectStepLength = other.IntellectStepLength;

        HP = other.HP;
        FightCapacity = other.FightCapacity;
        BasicAttackLow = other.BasicAttackLow;
        BasicAttackHigh = other.BasicAttackHigh;
        CriticalStrikeMultiple = other.CriticalStrikeMultiple;

        PhysicalAttack = other.PhysicalAttack;
        PhysicalDefence = other.PhysicalDefence;
        MagicAttack = other.MagicAttack;
        MagicDefence = other.MagicDefence;
        CriticalStrike = other.CriticalStrike;
        CriticalStrikeDefence = other.CriticalStrikeDefence;
        Hit = other.Hit;
        SideStep = other.SideStep;
        HolyHurt = other.HolyHurt;
    }

    public float Strength;                                        //力量
    public float Agility;                                         //敏捷
    public float Intellect;                                       //智力

    public float StrengthStepLength;                              //力量步长
    public float AgilityStepLength;                               //敏捷步长
    public float IntellectStepLength;                             //智力步长

    public long HP;                                              //生命
    public uint FightCapacity;                                    //战斗力
    public float BasicAttackLow;                                  //基础攻击下限
    public float BasicAttackHigh;                                 //基础攻击上限
    public float CriticalStrikeMultiple;                          //暴击倍数

    public float PhysicalAttack;                                  //物理攻击
    public float PhysicalDefence;                                 //物理防御
    public float MagicAttack;                                     //魔法攻击
    public float MagicDefence;                                    //魔法防御 
    public float CriticalStrike;                                  //暴击
    public float CriticalStrikeDefence;                           //暴击抵抗
    public float Hit;                                             //命中
    public float SideStep;                                        //闪避
    public uint HolyHurt;                                         //神圣伤害

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
