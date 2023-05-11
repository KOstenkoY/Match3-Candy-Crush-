namespace Match3
{
    internal class ClearLinePiece : ClearablePiece
    {
        public bool _isRow;

        public override void Clear()
        {
            base.Clear();

            if (_isRow)
            {            
                _piece.GameGridRef.ClearRow(_piece.Y);
            }
            else
            {            
                _piece.GameGridRef.ClearColumn(_piece.X);
            }
        }
    }
}
