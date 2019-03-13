﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SceneExport{
	[System.Serializable]
	public class MeshIdData{
		public ResId meshId = ResId.invalid;
		public List<ResId> meshMaterials = new List<ResId>();
		public MeshIdData(){
		}
		public MeshIdData(GameObject srcObj, ResourceMapper resMap){
			if (!srcObj)
				return;
			var filter = srcObj.GetComponent<MeshFilter>();
			if (filter && filter.sharedMesh){
				meshId = resMap.getMeshId(filter.sharedMesh);
			}
			var renderer = srcObj.GetComponent<Renderer>();
			if (renderer){
				foreach(var cur in renderer.sharedMaterials){
					meshMaterials.Add(resMap.getMaterialId(cur));
				}
			}
		}
	}
}
