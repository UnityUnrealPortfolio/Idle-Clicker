using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    private int walkAnimation = Animator.StringToHash("walk");
    private int mineAnimation = Animator.StringToHash("mine");
    private void Start()
    {
       
    }
    protected override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetTrigger(walkAnimation);
    }
    protected override void MineGold()
    {
        //do some mine gold stuff, then go back

        float waitTime = CarryingCapacity / MiningCapacityPaSecond;
        _animator.SetTrigger(mineAnimation);
        StartCoroutine(CollectGold(CarryingCapacity, waitTime));
    }
    protected override void DepositGold()
    {
        // do some deposit gold stuff
        _depositBox.DepositGold(_currentGoldAmount);
        _currentGoldAmount = 0; 
        SetFacingDirection(1);
        ChangeGoal();
        var modifiedPos = new Vector2(_miningLocation.position.x, transform.position.y);
        MoveMiner(modifiedPos);
    }
    protected override IEnumerator CollectGold(float _capacity,float _collectTime)
    {
        yield return new WaitForSeconds(_collectTime);
        SetFacingDirection(-1);
        _currentGoldAmount = _capacity;
        ChangeGoal();
        var modifiedPos = new Vector2(_depositLocation.position.x, transform.position.y);
        MoveMiner(modifiedPos);

    }
}
