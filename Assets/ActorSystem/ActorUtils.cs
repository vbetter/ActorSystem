/********************************************
-	    File Name: ActorUtils
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: Created by lijing on #CREATIONDATE#.
-Revision History: 
********************************************/

using UnityEngine;
using System.Collections;

namespace GameKit
{
    public enum FileNameType
    {
        NONE,               //不进行转换
        RESOURCE_NAME,      //获取相对Resources目录的相对路径名
        ASSET_BUNDLE_NAME,  //从AB文件中读取
        ASSET_NAME,         //获取相对Asset目录的相对路径名
        APP_NAME,           //获取当前运行目录的相对路径
        FULL_NAME,          //获取全路径
    }

    public class ActorUtils : MonoBehaviour
    {


    }
}
