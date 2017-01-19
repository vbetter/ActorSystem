/********************************************
-	    File Name: ActorBehaviour
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public class ActorBehaviour : LogicBehaviour
    {
        static uint m_NextValidGameObjectID = 1;    // UID 生成计数器

        public uint UID { set; get; }

        public GameObject MyModel { set; get; }             // 表现模型，可以为空
        public ActorType ActorType = ActorType.UNKNOWN;     // 角色类型
        public ActorGroup ActorGroup = ActorGroup.UnKnown;  // 角色阵营
        public uint ActorID = 0;                            // 配表角色id，可以为0

        public static ActorBehaviour CreateActorBehaviour(string fileName, GameObject model, ActorType eType, ActorGroup actorGroup, uint actorID)
        {
            GameObject obj = new GameObject(fileName);
            ActorBehaviour refActorBehaviour = null;

            switch (eType)
            {
                case ActorType.UNKNOWN:
                    break;
                case ActorType.HERO:
                    break;
                case ActorType.MONSTER:
                    break;
                case ActorType.SCENE_OBJ:
                    break;
                case ActorType.SCENE_SKILLDESTROY_OBJ:
                    break;
                case ActorType.VIRSUAL_OBJ:
                    refActorBehaviour = Utils.AddMissComponent<ActorBehaviour_Virsual>(obj);
                    break;
                case ActorType.NONATTACK_OBJ:
                    break;
                case ActorType.TEST_OBJ:
                    refActorBehaviour = Utils.AddMissComponent<ActorBehaviour_Test>(obj);
                    break;
                case ActorType.COUNT:
                    break;
                default:
                    break;
            }
            if (refActorBehaviour == null) return null;

            refActorBehaviour.Init(model, eType, actorGroup, actorID);

            return refActorBehaviour;
        }

        void Init(GameObject model, ActorType eType, ActorGroup actorGroup, uint actorID)
        {
            m_NextValidGameObjectID++;
            UID = m_NextValidGameObjectID;

            MyModel = model;
            ActorID = actorID;
            ActorType = eType;
            ActorGroup = actorGroup;
        }


        #region 接口

        public virtual void InitBehaviour(Property property)
        {

        }

        public virtual void RemoveSelf()
        {
            if (MyModel != null)
            {
                PathologicalGames.SpawnPool spawnPool = ActorManager.Instance.EffectSpawnPool;
                if (spawnPool.IsSpawned(MyModel.transform))
                {
                    spawnPool.Despawn(MyModel.transform);
                    MyModel = null;
                }
                else
                {
                    Debug.LogError("检查一下为什么没有调用对象池");
                }
            }
        }

        public virtual void SetActiveMode(bool value)
        {
            if (MyModel != null && value !=MyModel.activeSelf)
            {
                MyModel.SetActive(value);
            }
        }

        #endregion

    }
}
