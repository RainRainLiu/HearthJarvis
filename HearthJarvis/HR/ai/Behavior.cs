namespace HREngine.Bots
{

    public abstract class Behavior  //计算场面分值
    {
        public virtual float getPlayfieldValue(Playfield p)
        {
            return 0;
        }

        public virtual float getPlayfieldValueEnemy(Playfield p)
        {
            return getPlayfieldValue(p);
        }

        public virtual int getEnemyMinionValue(Minion m, Playfield p)
        {
            return 0;
        }

    }

}