using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// We can create different command classes extending the interface and implementing the
/// abstract variables and methods of interface
/// </summary>
public class MovePlayerCommand : ICommand
{
    //parameters
    Transform target;
    Vector3 oldPos;
    Vector3 newPos;

    bool isExecuting;

    //interface field
    public bool IsExecuting { get => isExecuting; set => isExecuting = value; }

    //constructor
    public MovePlayerCommand(Transform target, Vector3 oldPos, Vector3 newPos)
    {
        this.target = target;
        this.oldPos = oldPos;
        this.newPos = newPos;
    }

    //method implementations
    public void Execute()
    {
        isExecuting = true;
        float time = Vector3.Distance(target.position, newPos) / 4f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(newPos, time)
        //    .OnComplete(() => isExecuting = false);
    }

    public void Undo()
    {
        isExecuting = true;
        float time = Vector3.Distance(target.position, oldPos) / 10f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(oldPos, time)
        //    .OnComplete(() => isExecuting = false);
    }

    public void Redo()
    {

        isExecuting = true;
        float time = Vector3.Distance(target.position, newPos) / 10f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(newPos, time)
        //    .OnComplete(() => isExecuting = false);
    }
}