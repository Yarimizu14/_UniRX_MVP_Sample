using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class ScenePresenter : MonoBehaviour {

	[SerializeField]
	private MonsterListView monsterListView; 

	private MonsterListModel monsterListModel; 

	void Awake () {

		monsterListModel = new MonsterListModel();

		monsterListModel.monsters.ObserveAdd ().Subscribe (monsterListView.OnDeckMonsterAdd);

		monsterListModel.Initialize ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
