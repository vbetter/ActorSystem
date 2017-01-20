/********************************************
-	    File Name: ActorSkill
-	  Description: 角色技能组件
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public class ActorSkill : LogicBehaviour
    {
        uint _actorID;

        public void Init(uint actorID)
        {
            _actorID = actorID;
        }
    }
}
