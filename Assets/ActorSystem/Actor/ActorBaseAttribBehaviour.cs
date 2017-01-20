/********************************************
-	    File Name: ActorBaseAttribBehaviour
-	  Description: 角色基础属性组件
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public class ActorBaseAttribBehaviour : LogicBehaviour
    {
        /// <summary>
        /// 角色类型
        /// </summary>
        public ActorType ActorType = ActorType.NONE;

        /// <summary>
        /// 角色阵营
        /// </summary>
        public ActorGroup ActorGroup = ActorGroup.NONE;

        /// <summary>
        /// 是否死亡
        /// </summary>
        public bool IsDead = false;

        /// <summary>
        /// 角色表里的ID,即heroid/monsterid
        /// </summary>
        public uint ActorID = 0;

        /// <summary>
        /// 移动速度/突进速度，对于基础移动速度的放大系数
        /// </summary>
        public float m_fMoveSpeedScale = 1.0f;

        /// <summary>
        /// 当前对象的真实朝向，用来影响跟随等问题
        /// </summary>
        public Vector3 ActualFoward;

        /// <summary>
        /// 当前血量
        /// </summary>
        public long m_mRealHP = 100;
        public long m_HP
        {//做个简单的数据打乱处理，让内存修改器搜不到该字段
            set
            {
                CurHP_str = value.ToString();
                m_mRealHP = ~value;
            }
            get { return ~m_mRealHP; }
        }

        /// <summary>
        /// 最大血量
        /// </summary>
        long _maxHp = 100;
        public long m_Max_HP
        {
            set
            {
                MaxHP_str = value.ToString();
                _maxHp = value;
            }
            get
            {
                return _maxHp;
            }
        }

        /// <summary>
        /// 因为int64和long都无法再inspector面板显示，但是string可以，所以这个字段仅仅用于Inspector显示
        /// </summary>
        public string CurHP_str
        {
            set
            {
                long tempHP = 0;
                if (long.TryParse(value, out tempHP))
                {
                    m_mRealHP = tempHP;
                }
            }
        }

        /// <summary>
        /// 因为int64和long都无法再inspector面板显示，但是string可以，所以这个字段仅仅用于Inspector显示
        /// </summary>
        public string MaxHP_str
        {
            set
            {
                long tempHP = 0;
                if (long.TryParse(value, out tempHP))
                {
                    _maxHp = tempHP;
                }
            }
        }

        public int m_MP;

        public int m_Max_MP;

        /// <summary>
        /// 胶囊碰撞体的高和半径，未缩放的值
        /// </summary>
        public float m_CapsuleHeight;

        /// <summary>
        /// 碰撞半径
        /// </summary>
        public float m_CapsuleRadius;

        /// <summary>
        /// 基础跑步速度，资源表中配置的美术制作模型时设计的跑步速度
        /// </summary>
        public float m_BasicRunSpeed;

        /// <summary>
        /// 是否有生命周期 如果是true 时间到了就死了
        /// </summary>
        public bool m_bHasActorLifeTime = false;
        public float m_fCurLiveTime = 0.0f;
        public float m_fLifeTime = 0.0f;

        /// <summary>
        /// 角色攻击速度（毫秒）
        /// </summary>
        public int m_NormalAttackInterval = 0;

        /// <summary>
        /// 角色追击范围
        /// </summary>
        public float m_ChaseRange = 0.0f;

        /// <summary>
        /// 重量
        /// </summary>
        public int m_Weight = 0;

        public Property MyProperty;     //基础属性


        public void Init(ActorType eType, ActorGroup actorGroup,uint actorID =0)
        {
            ActorType = eType;
            ActorGroup = actorGroup;
            ActorID = actorID;

        }

        public void SetProperty(Property property)
        {

        }
    }
}
