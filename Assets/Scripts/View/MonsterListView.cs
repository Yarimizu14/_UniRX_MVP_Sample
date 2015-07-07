using UnityEngine;
using System.Collections;
using UniRx;

public class MonsterListView : MonoBehaviour {

	[SerializeField]
	private GameObject monsterThumbPrefab;

	/// <summary>
	/// Raises the deck monster add event.
	/// </summary>
	/// <param name="model">Model.</param>
	/// <param name="index">Index.</param>
	public void OnDeckMonsterAdd(CollectionAddEvent<MonsterModel> addEvent)
	{
		GameObject monsterThumbObj = Instantiate (monsterThumbPrefab) as GameObject;

		MonsterThumbView thumbView = monsterThumbObj.GetComponent<MonsterThumbView> ();
		thumbView.InitializeView (addEvent.Value);

		thumbView.gameObject.SetActive (true);
		thumbView.transform.Translate (new Vector3 (150f * addEvent.Index, 0, 0));
		monsterThumbObj.transform.SetParent (this.transform, false);
	}
}
