using UnityEngine;

[RequireComponent(typeof(Animator),typeof(AudioSource),typeof(SpriteRenderer))]
[RequireComponent(typeof(TowerAttackHandler))]

public class Tower: MonoBehaviour
{
    private TowerViewController _towerViewController;
    private TowerAttackHandler _towerAttackHandler;
    [SerializeField]
    private TowerType _towerType;    

    public void Initialize()
    {
        var animatorHandler = new TowerAnimatorHandler(GetComponent<Animator>());
        var spriteRendererHandler = new SpriteRendererHandler(GetComponent<SpriteRenderer>());
        var audioSourceHandler = new AudioSourceHandler(GetComponent<AudioSource>());

        var _towerStats = new TowerStats(_towerType);
        _towerAttackHandler = GetComponent<TowerAttackHandler>();
        _towerAttackHandler.Initialize(_towerStats);
        _towerViewController = new TowerViewController(spriteRendererHandler, animatorHandler,
            audioSourceHandler, _towerAttackHandler);
        _towerViewController.Initialize();
    }    
}
