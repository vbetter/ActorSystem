/********************************************
-	    File Name: BaseMonoMgr
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

public abstract class BaseMonoMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public abstract void Init();

    public abstract void Clear();

}
