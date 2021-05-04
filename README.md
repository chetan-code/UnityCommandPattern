# Command Pattern Unity
### Basic implementation of command pattern in Unity3d.
### FREE Assets Reqired :
| Asset | Download Link |
| ------ | ------ |
| DOTween (HOTween v2) | [https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676][PlDb] |
| Gridbox Prototype Materials | [https://assetstore.unity.com/packages/2d/textures-materials/gridbox-prototype-materials-129127][PlGh] |

### How to use this package : 
- Import this package (Download zip --> unzip --> Assets --> Scene --> click on scene file // or // use packagae manager git import)

- You may find pink material - you can either import Grid Box protype materials from unity asset store to get the same look as mine or create and apply your own materials.

- Import DoTween Assets from unity asset store --> intially all DOTween code is commented out.

- Uncomment the code in _MovePlayerCommand.cs_
```sh
    public void Execute()
    {
        isExecuting = true;
        float time = Vector3.Distance(target.position, newPos) / 4f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(newPos, time)
        //    .OnComplete(() => isExecuting = false);
    }
```    

```sh

    public void Undo()
    {
        isExecuting = true;
        float time = Vector3.Distance(target.position, oldPos) / 10f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(oldPos, time)
        //    .OnComplete(() => isExecuting = false);
    }
```    

```sh
    public void Redo()
    {

        isExecuting = true;
        float time = Vector3.Distance(target.position, newPos) / 10f;

        //TODO Uncomment the code below after importing DoTween Free asset
        //Also add import state "using DG.Tweening" (use Alt+Enter for auto import)

        //target.DOMove(newPos, time)
        //    .OnComplete(() => isExecuting = false);
    }
```    

## License

MIT

**Free Software, Hell Yeah!**
