namespace Tetris
{
    class Block
    {
        //public enum variant;
        public bool isActive = false;
        public bool isStable = false;
        public Block()
        {

        }
        public void setActive(bool state)
        {
            isActive = state;
        }
        public void setStable(bool state)
        {
            isStable = state;
        }
    }
}
