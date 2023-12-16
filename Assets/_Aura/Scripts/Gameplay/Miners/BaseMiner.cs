using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMiner : MonoBehaviour
{

	#region fields
	[Header("Mining and deposit locations")]
	[SerializeField] protected Transform _miningLocation;
	[SerializeField] protected Transform _depositLocation;
	[Header("Movement")]
	[SerializeField] protected float _moveSpeed;
	[SerializeField] protected Animator _animator;
	[Header("Initial Mining Properties")]
	[SerializeField] private float _carryingCapacity;
	[SerializeField] private float _miningCapacityPaSecond;
	[SerializeField] protected Deposit _depositBox;
	protected float _currentGoldAmount;


	protected bool _isTimeToCollect = true;
	protected int _facingDirection = 1;//1 = forward, -1 = back
    #endregion

    #region Properties
	public float CarryingCapacity { get; set; }
	public float MiningCapacityPaSecond { get; set; }
    #endregion

    private void Awake()
    {
		CarryingCapacity = _carryingCapacity;
		MiningCapacityPaSecond = _miningCapacityPaSecond;
    }
    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{

            var modifiedPos = new Vector2(_miningLocation.position.x, transform.position.y);
            MoveMiner(modifiedPos);
		}
    }
	protected virtual void MineGold()
	{

	}
	protected virtual void DepositGold()
	{

	}
	protected virtual void MoveMiner(Vector3 newPosition)
	{
		transform.DOMove(newPosition, _moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
		{
			if(_isTimeToCollect)
			{
				
				MineGold();
			}
			else
			{
				SetFacingDirection(1);
				DepositGold();
			}
		}).Play();
	}

	protected void ChangeGoal()
	{
		_isTimeToCollect = !_isTimeToCollect;
	}

	protected void SetFacingDirection(int direction)
	{
		if(direction == 1)
		{
			transform.localScale = new Vector3(1,1,1);
		}
		if(direction == -1)
		{
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

	protected virtual IEnumerator CollectGold(float capacity, float time)
	{
		yield return null;
	}
}
