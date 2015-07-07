using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

public class ScenePresenter : MonoBehaviour
{
	#region View

	[SerializeField]
	private MonsterListView monsterListView; 

	[SerializeField]
	private FocusMonsterView focusMonsterView; 

	[SerializeField]
	private FocusMonsterIdView focusMonsterIdView;

	[SerializeField]
	private SelectDoneButtonView selectDoneButtonView;

	private ReactiveCollection<MonsterThumbView> monsterThumbViews;

	#endregion

	#region Models

	private MonsterListModel monsterListModel; 

	#endregion

	void Awake () {

		monsterListModel = new MonsterListModel();

		monsterListModel.monsters.ObserveAdd ().Subscribe ((CollectionAddEvent<MonsterModel> addEvent) => {
			MonsterModel model = addEvent.Value;
			var thumb = monsterListView.OnDeckMonsterAdd(addEvent);

			thumb.click.AsObservable().Subscribe((Unit _) => {
				monsterListModel.SetFocustMonster(addEvent.Value);
			});

			model.isSelected.Subscribe(thumb.OnMonsterSelecteStateChanged);
		});

		monsterListModel.focusMonster.Subscribe (focusMonsterView.OnFocusMonsterChanged);
		monsterListModel.focusMonster.Subscribe (focusMonsterIdView.OnFocusMonsterChanged);

		monsterListModel.selectDone.Subscribe (selectDoneButtonView.OnSelectDoneChaged);

		selectDoneButtonView.OnClickAsObservable ().Subscribe ((Unit _) => {
			Debug.Log("選択完了！！");
		});

		monsterListModel.Initialize ();
	}
}
