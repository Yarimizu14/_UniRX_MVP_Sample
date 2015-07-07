using UnityEngine;
using System.Collections;

public class FocusMonsterView : MonoBehaviour {

	public void OnFocusMonsterChanged(MonsterModel model)
	{
		if (model == null)
		{
			return;
		}
		var renderer = this.GetComponent<Renderer> ();
		renderer.material.color = model.materialColor;
	}
}

