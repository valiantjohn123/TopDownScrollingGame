using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base structure for movement node
/// Bascially each movement is a node and every node is connected to next node. All those connected nodes makes a path
/// Those paths are attached to enemies, once they are instantiated, enemies follow the path they are assigned
/// </summary>
public abstract class MovementNodeBase : ScriptableObject
{
    /// <summary>
    /// Next linked node to move to
    /// </summary>
    public MovementNodeBase NextNode;
    /// <summary>
    /// Animation curve for easing the node starting and ending points
    /// </summary>
    public AnimationCurve EasingCurve;
    
    /// <summary>
    /// Speed multiplier, that defines how much time it takes for the node to complete executing
    /// </summary>
    public float Speed = 1;
    /// <summary>
    /// A short delay before starting the execution
    /// </summary>
    public float Delay;

    /// <summary>
    /// Target vector position, the attached entity will be moved to that point by the end of node
    /// </summary>
    [NonSerialized]
    public Vector2 TargetPoint;
    /// <summary>
    /// The parent entity, that this node belongs to
    /// </summary>
    [NonSerialized]
    public Entity ParentEntity;
    /// <summary>
    /// Step number, this tells how much node it executed
    /// </summary>
    [NonSerialized]
    public float Step;
    /// <summary>
    /// To make sure that node is done setting up
    /// </summary>
    [NonSerialized]
    public bool IsElementSetupComplete;
    /// <summary>
    /// Start delay timer variable
    /// </summary>
    [NonSerialized]
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
    /// Go to next node
    /// </summary>
    /// <returns></returns>
    public MovementNodeBase SkipToNextNode()
    {
        if (NextNode != null)
        {
            return NextNode.ResetNode();
        }
        else
            return this;
    }

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
            return SkipToNextNode();
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
    public MovementNodeBase ResetNode()
    {
        currentDelay = 0;
        Step = 0;
        IsElementSetupComplete = false;
        return Instantiate(this);
    }
}
