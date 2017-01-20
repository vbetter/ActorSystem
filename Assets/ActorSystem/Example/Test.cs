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

        /*
        for (int i = 0; i < 3; i++)
        {
            CreateVirsualObject();
        }
         */

        CreateTestObject();
	}
	

    void CreateVirsualObject()
    {
        Property p = new Property();
        p.HP = 10;
        string path = "";
        ActorBehaviour actor = ActorManager.Instance.CreateActor(path, p, ActorType.VIRSUAL_OBJ, ActorGroup.FRIEND);
    }

    void CreateTestObject()
    {
        Property p = new Property();
        p.HP = 10;
        string path = "Player/Player_GA";
        ActorBehaviour actor = ActorManager.Instance.CreateActor(path, p, ActorType.TEST_OBJ, ActorGroup.FRIEND);
    }
}
