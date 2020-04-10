using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base movement node
/// </summary>
public abstract class MovementNodeBase : ScriptableObject
{
    public MovementNodeBase NextNode;

    public float Speed = 1;

    public bool IsElementSetupComplete;
    public Entity ParentEntity;

    public float Step;

    /// <summary>
    /// On step update
    /// </summary>
    /// <param name="step"></param>
    public abstract void OnStep(float step);

    /// <summary>
    /// On setup trigger
    /// </summary>
    /// <param name="step"></param>
    public abstract void OnSetUp();

    /// <summary>
    /// On movement execute
    /// </summary>
    public MovementNodeBase Execute(Entity entity)
    {
        SetUp(entity);

        //Go to next node once this node is completed
        if (Step >= 1)
        {
            if (NextNode != null)
                NextNode.ResetNode();
            return NextNode;
        }

        OnStep(Step);
        Step += Time.deltaTime * Speed;
        return this;
    }

    /// <summary>
    /// Init the object
    /// </summary>
    /// <param name="entity"></param>
    public void SetUp(Entity entity)
    {
        if (!IsElementSetupComplete)
        {
            ResetNode();
            IsElementSetupComplete = true;
            ParentEntity = entity;
            OnSetUp();
        }
    }

    /// <summary>
    /// Reset the node to initial state
    /// </summary>
    public void ResetNode()
    {
        Step = 0;
        IsElementSetupComplete = false;
    }
}
