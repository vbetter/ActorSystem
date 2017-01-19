/********************************************
-	    File Name: Utils
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public class Utils : MonoBehaviour
    {
        public static T AddMissComponent<T>(GameObject go) where T : LogicBehaviour
        {
            if (go == null) return null;

            T t = null;
            t = go.GetComponent<T>();
            if (t == null)
            {
                t = go.AddComponent<T>();
            }

            return t;
        }
    }
}
