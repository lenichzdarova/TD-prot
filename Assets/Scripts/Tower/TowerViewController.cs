
public class TowerViewController
{
    private SpriteRendererHandler _spriteRendererHandler;
    private TowerAnimatorHandler _animatorHandler;
    private AudioSourceHandler _audioSourceHandler;
    private TowerAttackHandler _towerAttackHandler;

    public TowerViewController(SpriteRendererHandler spriteRendererHandler,TowerAnimatorHandler animatorHandler,
        AudioSourceHandler audioSourceHandler, TowerAttackHandler towerAttackHandler)
    {
        _spriteRendererHandler = spriteRendererHandler;
        _animatorHandler = animatorHandler;
        _audioSourceHandler = audioSourceHandler;
        _towerAttackHandler = towerAttackHandler;
    }
    public void Initialize()
    {
        _towerAttackHandler.Activation += OnTowerActivation;
        _towerAttackHandler.DirectionCheck += OnDirectionCheck;
        _animatorHandler.ActionAnimation += OnAnimatorAction;
        _animatorHandler.EndAnimation += OnEndAnimation;        
    }
    public void OnTowerActivation()
    {
        _animatorHandler.PlayAttackAnimation();
    }
    public void OnAnimatorAction()
    {
        _audioSourceHandler.PlayAudioClip();
        _towerAttackHandler.OnActionAnimation();
    }
    public void OnEndAnimation()
    {
        _animatorHandler.PlayIdleAnimation();
    }

    private void OnDirectionCheck(bool direction)
    {
        _spriteRendererHandler.SetDirection(direction);
    }
}
