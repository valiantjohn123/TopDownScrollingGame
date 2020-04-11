using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base movement node
/// </summary>
public abstract class MovementNodeBase : ScriptableObject
{
    public MovementNodeBase NextNode;
    public Entity ParentEntity;

    public Vector2 TargetPoint;

    public AnimationCurve EasingCurve;

    public float Speed = 1;
    public float Step;
    public float Delay;

    public bool IsElementSetupComplete;

    private float currentDelay;


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
    /// Update the target vector
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public MovementNodeBase UpdateTarget(Vector2 vector)
    {
        TargetPoint = vector;
        return this;
    }

    /// <summary>
    /// On movement execute
    /// </summary>
    public MovementNodeBase Execute(Entity entity)
    {
        //Set up object
        SetUp(entity);

        //Add listtle delay before starting
        if (currentDelay <= Delay)
        {
            currentDelay += Time.deltaTime;
            return this;
        }

        //Go to next node once this node is completed
        if (Step >= 1)
        {
            if (NextNode != null)
                NextNode.ResetNode();
            return NextNode;
        }

        OnStep(EasingCurve.Evaluate(Step));
        Step += Time.deltaTime * Speed;

        //Return the object
        return this;
    }

    /// <summary>
    /// Gets the delta time calculated with speed
    /// </summary>
    /// <returns></returns>
    public float GetDeltaTime()
    {
        return Time.deltaTime * Speed;
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
        currentDelay = 0;
        Step = 0;
        IsElementSetupComplete = false;
    }
}
