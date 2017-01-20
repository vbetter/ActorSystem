/********************************************
-	    File Name: ActorMove
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public class ActorMove : LogicBehaviour
    {
        Vector3 _targetPos;
        bool _isMoving = false;
        /// <summary>
        /// 转身速度，单位：度/秒
        /// </summary>
        public float TurnSpeed = 500.0f;
        float time = 0;
        /// <summary>
        /// 角色转身是否平滑。
        /// True: 根据TurnSpeed平滑转身
        /// False: 直接转身
        /// </summary>
        public bool IsTurnSmoothly = true;

        bool _needReDirect = true;

        ActorBehaviour _actor;
        CharacterController _CharacterController;
        CharacterController MyCharacterController
        {
            get
            {
                if (_CharacterController==null)
                {
                    _CharacterController = gameObject.AddComponent<CharacterController>();
                }
                return _CharacterController;
            }
        }

        public void Init(ActorBehaviour actor)
        {
            _actor = actor;
            
        }

        public void MoveTo(Vector3 pos)
        {
            _isMoving = true;
            _targetPos = pos;
            //MyCharacterController.Move(pos);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

        }
    }
}
