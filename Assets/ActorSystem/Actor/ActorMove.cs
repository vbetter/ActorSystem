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
        ActorBehaviour _actor;

        public void Init(ActorBehaviour actor)
        {
            _actor = actor;
        }

    }
}
