
using UnityEngine;

public class HollowSquareTile : Tile
{
    public override void TileEffect(Axis axis)
    {
        var coroutine = CoroutineFactory.GetInstance.CreateCoroutine(0.8f);            
        coroutine.EventArgs.thisCoroutine = coroutine;
        var transform1 = transform;
        coroutine.EventArgs.object1 = transform1;
        coroutine.EventArgs.vector1 = transform1.localScale;

        
        coroutine.SetAction(args =>
        {
            var trans = args.object1 as Transform;
            trans.localScale = args.thisCoroutine.Change(args.vector1, Vector3.zero);
        }).SetExitAction(args =>
        {
            var trans = args.object1 as Transform;
            trans.localScale = Vector3.zero;
        });
        coroutine.SetTrigger();
    }
}