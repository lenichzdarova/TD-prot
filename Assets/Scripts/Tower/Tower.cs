using UnityEngine;

[RequireComponent(typeof(Animator),typeof(AudioSource),typeof(SpriteRenderer))]
[RequireComponent(typeof(TowerAttackHandler),typeof(TowerAnimatorHandler))]

public class Tower: MonoBehaviour
{
    private TowerViewController _towerViewController;
    private TowerAttackHandler _towerAttackHandler;
    [SerializeField]
    private TowerType _towerType;

    //fortest
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        var animatorHandler = GetComponent<TowerAnimatorHandler>();
        animatorHandler.Initialization(GetComponent<Animator>());
        var spriteRendererHandler = new SpriteRendererHandler(GetComponent<SpriteRenderer>());
        var audioSourceHandler = new AudioSourceHandler(GetComponent<AudioSource>());

        var towerAttackStats = new BaseTowerAttackStats(_towerType);
        _towerAttackHandler = GetComponent<TowerAttackHandler>();
        _towerAttackHandler.Initialize(towerAttackStats.GetStats());
        _towerViewController = new TowerViewController(spriteRendererHandler, animatorHandler,
            audioSourceHandler, _towerAttackHandler);
        _towerViewController.Initialize();
    }    
}
