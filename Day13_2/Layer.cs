namespace Day13_2
{
    public class Layer
    {
        public int LayerDepth { get; set; }

        public int Position { get; set; }

        public int Range { get; set; }

        private bool MovingUp { get; set; }

        public void ChangePositionAfterPicosecond()
        {
            if (MovingUp)
            {
                if (Position - 1 == -1)
                {
                    Position = 1;
                    MovingUp = false;
                }
                else
                {
                    Position--;
                }
            }
            else
            {
                if (Position + 1 == Range)
                {
                    Position = Range - 2;
                    MovingUp = true;
                }
                else
                {
                    Position++;
                }
            }
        }
    }
}