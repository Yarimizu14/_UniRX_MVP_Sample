using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class MonsterListModel
{
	public ReactiveCollection<MonsterModel> monsters;

	public ReactiveProperty<MonsterModel> focusMonster;

	public ReactiveCollection<MonsterModel> selectedMosnters;

	public ReactiveProperty<bool> selectDone;

	public MonsterListModel()
	{
		monsters = new ReactiveCollection<MonsterModel> ();
		focusMonster = new ReactiveProperty<MonsterModel> ();
		selectedMosnters = new ReactiveCollection<MonsterModel> ();
		selectDone = new ReactiveProperty<bool> ();

		selectedMosnters.ObserveAdd ().Subscribe (this.OnSelectedMonsterAdded);
		selectedMosnters.ObserveRemove ().Subscribe (this.OnSelectedMonsterRemoved);
	}

	public void Initialize()
	{
		for (var i = 0; i < 5; i++)
		{
			monsters.Add (new MonsterModel(i+1));
		}
	}

	public void SetFocustMonster(MonsterModel model)
	{
		if (model == focusMonster.Value)
		{
			if (!selectedMosnters.Contains (model)) {
				selectedMosnters.Add (model);
			} else {
				selectedMosnters.Remove (model);
			}
			return;
		}

		int index = monsters.IndexOf (model);

		this.focusMonster.Value = monsters[index];
	}

	public void OnSelectedMonsterAdded(CollectionAddEvent<MonsterModel> addEvent)
	{
		MonsterModel model = addEvent.Value;
		model.isSelected.Value = true;

		this.selectDone.Value = this.selectedMosnters.Count >= 3;
	}

	public void OnSelectedMonsterRemoved(CollectionRemoveEvent<MonsterModel> removedEvent)
	{
		MonsterModel model = removedEvent.Value;
		model.isSelected.Value = false;

		this.selectDone.Value = this.selectedMosnters.Count >= 3;
	}
}
