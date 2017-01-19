/********************************************
-	    File Name: ActorManager
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameKit
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public enum ActorType
    {
        UNKNOWN = 0,
        HERO,                       //玩家控制的英雄
        MONSTER,                    //怪物
        SCENE_OBJ,					// 场景内可破坏物件（可破坏可点选）
        SCENE_SKILLDESTROY_OBJ,		// 场景内技能可破坏物件(可破坏不可点选)
        VIRSUAL_OBJ,                // 虚拟不可见的单位
        NONATTACK_OBJ,				// 不可攻击的中立物体
        COUNT,
    }

    /// <summary>
    /// 角色阵营
    /// </summary>
    public enum ActorGroup
    {
        UnKnown,
        Friend,             //本人的英雄或者怪物
        Enemy,              //敌方的英雄或者怪物
        Neutral,            //中立怪物，本人或者敌方都会攻击它
        COUNT,
    }

    public enum ActorAttribu
    {
        AA_HP,              // 当前生命值
        AA_MP,              // 当前魔法值
        AA_HPMAX,           // 生命最大值
        AA_MPMAX,           // 魔法最大值
        AA_RUNSPEED,        // 移动速度
        AA_STRENGTH,        // 力量
        AA_AGILITY,         // 敏捷
        AA_INTELLECT,       // 智力
        AA_PHYSICL_ATTACK,  // 物理攻击
        AA_MAGIC_ATTACK,    // 魔法攻击
        AA_PHYSICAL_DEFENCE,// 物理防御
        AA_MAGIC_DEFENCE,   // 魔法防御
        AA_COUNT,
    };

    public class ActorManager : MonoBehaviour
    {
        Dictionary<uint, ActorBehaviour> _actorsDic = new Dictionary<uint, ActorBehaviour>();

        ActorBehaviour _CurrentContorller = null;

        uint m_NextValidGameObjectID = 1;   //UID 生成计数器

        #region 接口

        public void RemoveAllActors()
        {

        }

        public void RemoveActor(uint uid)
        {

        }

        public void RemoveActor(ulong gid)
        {
            
        }

        public ActorBehaviour CurController
        {
            set
            {
                _CurrentContorller = value;
            }
            get
            {
                return _CurrentContorller;
            }
        }

        public ActorBehaviour GetActorByGid(ulong gid)
        {
            return null;
        }

        public ActorBehaviour GetActorByUID(uint uid)
        {
            return null;
        }

        public ActorBehaviour CreateActor(Property property, ActorType eType, ActorGroup Group)
        {
            return null;
        }

        public ActorBehaviour CreateActor(uint actorID,ActorType eType, ActorGroup Group)
        {
            return null;
        }

        #endregion

        ActorBehaviour CreateActorGameObject(uint actorID ,uint uid ,ActorType actorType)
        {
            GameObject model = null;

            switch (actorType)
            {
                case ActorType.UNKNOWN:
                    break;
                case ActorType.HERO:
                    model = CreateHeroGameObject(actorID);
                    break;
                case ActorType.MONSTER:
                    model = CreateMonsterGameObject(actorID);
                    break;
                case ActorType.SCENE_OBJ:
                    break;
                case ActorType.SCENE_SKILLDESTROY_OBJ:
                    break;
                case ActorType.VIRSUAL_OBJ:
                    break;
                case ActorType.NONATTACK_OBJ:
                    break;
                case ActorType.COUNT:
                    break;
                default:
                    break;
            }

            return null;
        }

        /// <summary>
        /// 读表创建英雄单位
        /// </summary>
        /// <param name="heroID"></param>
        /// <returns></returns>
        GameObject CreateHeroGameObject(uint heroID)
        {
            /* 预留读表
            wl_res.HeroBasicAttributes refHeroBasicAttributes;
            if (!m_refHeroBasicAttributesTable.GetData(HeroID, out refHeroBasicAttributes))
            {
                Debug.LogError("Can't find HeroID:" + HeroID + "in HeroBasicAttributesTable");
                return null;
            }

            wl_res.ResConfig refResConfig;
            if (!m_refResConfigTable.GetData(refHeroBasicAttributes.ResId, out refResConfig))
            {
                Debug.LogError("Can't find HeroID:" + HeroID + "'s ResId:" + refHeroBasicAttributes.ResId + "in ResConfigTable");
                return null;
            }

            string modelFile = StringUtility.UTF8BytesToString(ref refResConfig.ModelFile);
             */

            string modelFile = "";
            GameObject obj = CreateGameObjectByPrefabPath(modelFile);
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// 读表创建怪物
        /// </summary>
        /// <param name="monsterID"></param>
        /// <returns></returns>
        GameObject CreateMonsterGameObject(uint monsterID)
        {
            /* 预留读表
            wl_res.NPCBaseInfo refNPCBaseInfo;
            if (!m_refNPCBaseInfoTable.GetData(MonsterID, out refNPCBaseInfo))
            {
                Debuger.LogError("Can't find MonsterID:" + MonsterID + "in HeroBasicAttributesTable");
                return null;
            }

            wl_res.ResConfig refResConfig;
            if (!m_refResConfigTable.GetData(refNPCBaseInfo.ResID, out refResConfig))
            {
                Debuger.LogError("Can't find MonsterID:" + MonsterID + "'s ResId:" + refNPCBaseInfo.ResID + "in ResConfigTable");
                return null;
            }

            string modelFileStr = StringUtility.UTF8BytesToString(ref refResConfig.ModelFile);
             */
            string modelFile = "";
            GameObject obj = CreateGameObjectByPrefabPath(modelFile);
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// 根据预测路径创建对象
        /// </summary>
        /// <param name="prefabPath"></param>
        /// <returns></returns>
        GameObject CreateGameObjectByPrefabPath(string prefabPath)
        {
            return null;
        }


    }
}
