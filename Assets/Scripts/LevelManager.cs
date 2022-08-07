using System;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    public int _blocksCount;

    public event Action OnAllBlocksDestroyed;

    protected  override void Awake ()
    {
        Block.OnCreated += BlockCreated;
        Block.OnDestroyed += BlockDestroyed;
    }

    private void OnDestroy()
    {
        Block.OnDestroyed -= BlockDestroyed;
        Block.OnCreated -= BlockCreated;
    }

    private void BlockCreated(Block block)
    {
        _blocksCount++;
    }

    private void BlockDestroyed(Block block, int score)
    {
        FindObjectOfType<GameManager>().ChangeScore(score: 0);
        _blocksCount--;

        if (_blocksCount == 0)
        {
            OnAllBlocksDestroyed?.Invoke();
        }
    }
}