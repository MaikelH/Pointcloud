namespace PointCloud
{
    public class PointXY : PointT
    {
        private double _x;
        private double _y;
        
        public PointXY()
        {
            _x = _y = 0;
        }

        public PointXY(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
