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
using PathologicalGames;
using Template;
using System.Text;

namespace GameKit
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public enum ActorType
    {
        UNKNOWN = 0,
        HERO,                       // 玩家控制的英雄
        MONSTER,                    // 怪物
        SCENE_OBJ,					// 场景内可破坏物件（可破坏可点选）
        SCENE_SKILLDESTROY_OBJ,		// 场景内技能可破坏物件(可破坏不可点选)
        VIRSUAL_OBJ,                // 虚拟不可见的单位
        NONATTACK_OBJ,				// 不可攻击的中立物体
        TEST_OBJ,                   // 测试对象
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

    public class ActorManager : MonoSingleton<ActorManager>
    {
        Dictionary<uint, ActorBehaviour> _actorsDic = new Dictionary<uint, ActorBehaviour>();

        ActorBehaviour _CurrentContorller = null;

        #region 接口

        public void RemoveAllActors()
        {
            Dictionary<uint, ActorBehaviour>.Enumerator A = _actorsDic.GetEnumerator();
            while (A.MoveNext())
            {
                if (A.Current.Value != null)
                {
                    A.Current.Value.RemoveSelf();
                    GameObject.Destroy(A.Current.Value.gameObject);
                }
            }
        }

        public bool RemoveActor(uint uid)
        {
            ActorBehaviour actor = null;

            if (!_actorsDic.TryGetValue(uid,out actor))
            {
                return false;
            }

            if(actor!=null)
            {
                _actorsDic.Remove(uid);

                actor.RemoveSelf();

                GameObject.Destroy(actor.gameObject);
            }

            return true;
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
            return CreateActorGameObject(actorID,eType, Group);
        }

        /// <summary>
        /// 一般测试用
        /// </summary>
        /// <param name="prefab_path"></param>
        /// <param name="eType"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        public ActorBehaviour CreateActor(string prefab_path, Property property, ActorType eType, ActorGroup Group)
        {
            return CreateActorGameObject(0, eType, Group, prefab_path, property);
        }

        #endregion

        /// <summary>
        /// 创建ActorBehaviour
        /// </summary>
        /// <param name="actorID">角色ID,读表用,不唯一</param>
        /// <param name="actorType"></param>
        /// <param name="prefab_path"> 测试用，正式用actorID创建</param>
        /// <returns></returns>
        ActorBehaviour CreateActorGameObject(uint actorID, ActorType actorType, ActorGroup actorGroup , string prefab_path = "", Property property = new Property())
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
                case ActorType.TEST_OBJ:
                    model = CreateGameObjectByPrefabPath(prefab_path, FileNameType.RESOURCE_NAME);
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

            if (model == null && actorType != ActorType.VIRSUAL_OBJ)
            {
                Debug.Log(string.Format("create actor Error , actorID :{0} , ActorType :{1}", actorID, actorType));
                return null;
            }

            string modelName = model == null ? "VIRSUAL" : model.name;
            string fileName = string.Format("[{0}].{1}.{2}", actorType, actorID, modelName);

            ActorBehaviour refActor = ActorBehaviour.CreateActorBehaviour(fileName, model, actorType, actorGroup, actorID);

            if (refActor != null)
            {
                if(!_actorsDic.ContainsKey(refActor.UID))
                {
                    _actorsDic.Add(refActor.UID, refActor);
                }
                else
                {
                    Debug.LogError("contain object");
                    refActor.RemoveSelf();
                    GameObject.Destroy(refActor.gameObject);
                }
            }

            return refActor;
        }

        /// <summary>
        /// 读表创建英雄单位
        /// </summary>
        /// <param name="heroID"></param>
        /// <returns></returns>
        GameObject CreateHeroGameObject(uint heroID, FileNameType fileNameType = FileNameType.ASSET_BUNDLE_NAME)
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
            GameObject obj = CreateGameObjectByPrefabPath(modelFile, fileNameType);
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
        GameObject CreateMonsterGameObject(uint monsterID ,FileNameType fileNameType = FileNameType.ASSET_BUNDLE_NAME)
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
            GameObject obj = CreateGameObjectByPrefabPath(modelFile, fileNameType);
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
        GameObject CreateGameObjectByPrefabPath(string prefab_path, FileNameType fileNameType = FileNameType.NONE)
        {
            string realName = GetNameWithRemovePath(prefab_path);
            GameObject go = null;
            if (PreloadModel(prefab_path, fileNameType))
            {
                Transform spawnGO = EffectSpawnPool.Spawn(realName);
                if (spawnGO != null)
                {
                    go = spawnGO.gameObject;
                }
            }
            return go;
        }

        SpawnPool _effectSpawnPool = null;
        public SpawnPool EffectSpawnPool
        {
            get
            {
                if (_effectSpawnPool == null)
                {
                    _effectSpawnPool = PoolManager.Pools.Create("ActorSys");
                    _effectSpawnPool.dontDestroyOnLoad = true;
                }

                return _effectSpawnPool;
            }
        }

        /// <summary>
        /// 预加载模型
        /// </summary>
        /// <param name="prefab_path"></param>
        /// <param name="resourceNameType"></param>
        public bool PreloadModel(string prefab_path, FileNameType fileNameType = FileNameType.NONE)
        {
            if (string.IsNullOrEmpty(prefab_path))
            {
                Debug.LogError("Effect_name is null");
                return false;
            }

            string effectprefab_path = FormatFileName(prefab_path, fileNameType);

            string realName = GetNameWithRemovePath(effectprefab_path);
            if (EffectSpawnPool.GetPrefabPool(realName) == null)
            {
                PrefabPool prefabPool = GetModelPrefabPool(effectprefab_path, fileNameType);

                if (prefabPool == null) return false;
#if UNITY_EDITOR
                if (!EffectSpawnPool._perPrefabPoolOptions.Contains(prefabPool)) EffectSpawnPool._perPrefabPoolOptions.Add(prefabPool);
#endif
                EffectSpawnPool.CreatePrefabPool(prefabPool);
            }
            return true;
        }

        /// <summary>
        /// 获取角色模型池
        /// </summary>
        /// <param name="prefab_path"></param>
        /// <returns></returns>
        PrefabPool GetModelPrefabPool(string prefab_path, FileNameType fileNameType = FileNameType.RESOURCE_NAME)
        {
            PrefabPool prefabPool = null;

            GameObject go = null;
            switch (fileNameType)
            {
                case FileNameType.NONE:
                    break;
                case FileNameType.RESOURCE_NAME:
                    {
                        GameObject res =Resources.Load<GameObject>(prefab_path);
                        if (res == null) return null;

                        go = Instantiate<GameObject>(res);
                    }
                    break;
                case FileNameType.ASSET_BUNDLE_NAME:
                    //go = ResManager.Instance.LoadMode(prefab_path);
                    break;
                case FileNameType.ASSET_NAME:
                    break;
                case FileNameType.APP_NAME:
                    break;
                case FileNameType.FULL_NAME:
                    break;
                default:
                    break;
            }

            if (go != null)
            {
                prefabPool = new PrefabPool(go.transform);

                if (prefabPool != null)
                {
                    prefabPool.preloadAmount = 1;
                    prefabPool.limitInstances = false;
                    prefabPool.limitFIFO = false;
                    prefabPool.limitAmount = 5;
                    prefabPool.cullDespawned = true;
                    prefabPool.cullAbove = 5;
                    prefabPool.cullDelay = 10;
                    prefabPool.cullMaxPerPass = 5;
                }
            }

            return prefabPool;
        }

        public static string FormatFileName(string strFileName, FileNameType t)
        {
            if (t == FileNameType.NONE)
            {
                return strFileName;
            }

            if (t == FileNameType.RESOURCE_NAME)
            {
                bool bOk = false;
                string strResourcePath = "Resources/";
                int index = strFileName.IndexOf(strResourcePath);
                if (index >= 0)
                {
                    strFileName = strFileName.Substring(strResourcePath.Length + index);
                    index = strFileName.LastIndexOf('.');
                    if (index >= 0)
                    {
                        strFileName = strFileName.Substring(0, index);
                        bOk = true;
                    }
                }

                if (!bOk)
                {
                    strResourcePath = "Resources\\";
                    index = strFileName.IndexOf(strResourcePath);
                    if (index >= 0)
                    {
                        strFileName = strFileName.Substring(strResourcePath.Length + index);
                        index = strFileName.LastIndexOf('.');
                        if (index >= 0)
                        {
                            strFileName = strFileName.Substring(0, index);
                            bOk = true;
                        }
                    }
                }
            }

            strFileName = strFileName.Replace('\\', '/');

            return strFileName;

        }

        /// <summary>
        /// 获取名字，去除路径
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public string GetNameWithRemovePath(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            int end = name.LastIndexOf("/") + 1;
            string newStr = name.Substring(end, name.Length - end);
            return newStr;
        }
    }
}
