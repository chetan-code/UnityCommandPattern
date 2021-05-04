using UnityEngine;
using System.Collections;

/// <summary>
/// This iterface act as a template for a basic command interface
/// </summary>
public interface ICommand 
{

    bool IsExecuting {get; set; }

    void Execute();

    void Undo();

    void Redo();
}