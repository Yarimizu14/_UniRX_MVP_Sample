using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FocusMonsterIdView : MonoBehaviour {

	public void OnFocusMonsterChanged(MonsterModel model)
	{
		if (model == null)
		{
			return;
		}
		var text = this.GetComponent<Text> ();
		text.text = "000" + model.monsterId;
	}
}
