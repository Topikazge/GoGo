using UnityEngine;

public class EnemyMeleeView : EnemyView
{
    private EnemyMeleeData _data;

    private SpriteRenderer _spriteRenderer;

    public EnemyMeleeData Data { get => _data;}
    public SpriteRenderer SpriteRenderer  => _spriteRenderer;

    public void Init(EnemyMeleeData data,SpriteRenderer spriteRenderer)
    {
        _data = data;
        _spriteRenderer = spriteRenderer;
    }

    public override void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void Flip(FlipSprite flipSprite)
    {
        if (flipSprite == FlipSprite.Left)
            _spriteRenderer.flipX = true;
       else
            _spriteRenderer.flipX = false;
    }
}
