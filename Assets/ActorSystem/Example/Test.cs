/********************************************
-	    File Name: Test
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;
using GameKit;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ActorManager.Instance.Init();

        CreateVirsualObject();
	}
	

    void CreateVirsualObject()
    {
        Property p = new Property();
        p.HP = 10;
        string path = "";
        ActorBehaviour actor = ActorManager.Instance.CreateActor(path, p, ActorType.VIRSUAL_OBJ, ActorGroup.Friend);
    }

    void CreateTestObject()
    {

    }
}
